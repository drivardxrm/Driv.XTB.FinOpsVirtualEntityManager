﻿using Driv.XTB.FinOpsVirtualEntityManager.Entities;
using Driv.XTB.FinOpsVirtualEntityManager.Forms;
using Driv.XTB.FinOpsVirtualEntityManager.Helper;
using Driv.XTB.FinOpsVirtualEntityManager.Proxy;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using xrmtb.XrmToolBox.Controls;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using static ScintillaNET.Style;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Driv.XTB.FinOpsVirtualEntityManager
{
    public partial class FinOpsVirtualEntityManagerControl : PluginControlBase, IGitHubPlugin, IMessageBusHost
    {
        //private Settings mySettings;
        private Settings _globalsettings;
        private Settings _connectionsettings;
        private IOrganizationService _service;

        private EntityCollection _allFinOpsEntities = new EntityCollection();
        private EntityCollection _filteredFinOpsEntities = new EntityCollection();
        private FinOpsEntityProxy _selectedFinOpsEntity;
        private Entity _selectedVirtualEntityMetadata;

        public string RepositoryName => "Driv.XTB.FinOpsVirtualEntityManager";

        public string UserName => "drivardxrm";

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public FinOpsVirtualEntityManagerControl()
        {
            InitializeComponent();
        }

        private void FinOpsVirtualEntityManagerControl_Load(object sender, EventArgs e)
        {
            txtDataverseUrl.Text = ConnectionDetail?.WebApplicationUrl;
            
            btnPPAC.Enabled = true;
            btnDataverse.Enabled = !string.IsNullOrEmpty(txtDataverseUrl.Text);
            
            LoadGlobalSettings();
            LoadConnectionSettings();
            ExecuteMethod(InitializeService);
            ExecuteMethod(RetrieveFinanceAndOperationsIntegrationDetails);

        }

        private void LoadGlobalSettings()
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out _globalsettings))
            {
                _globalsettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void LoadConnectionSettings()
        {
            
            if (!SettingsManager.Instance.TryLoad(GetType(), out _connectionsettings, ConnectionDetail?.ConnectionId.ToString()))
            {
                _connectionsettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }





        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinOpsVirtualEntityManagerControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), _connectionsettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            txtDataverseUrl.Text = ConnectionDetail?.WebApplicationUrl;
            
            if (_globalsettings != null && detail != null)
            {
                LoadConnectionSettings();

                _globalsettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

                ExecuteMethod(InitializeService);

                _filteredFinOpsEntities = null;
                _selectedFinOpsEntity = null;
                SetSelectedEntity(Guid.Empty);
                gridAvailableEntities.DataSource = null;
                

                ExecuteMethod(RetrieveFinanceAndOperationsIntegrationDetails);

            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            _selectedFinOpsEntity = null;
            SetSelectedEntity(Guid.Empty);
            ExecuteMethod(LoadAvailableFinOpsEntities);
        }

        private void InitializeService()
        {
            gridAvailableEntities.OrganizationService = Service;
            txtPhysicalName.OrganizationService = Service;
            txtVirtualLogicalName.OrganizationService = Service;
            txtVirtualExternalName.OrganizationService = Service;
            txtVirtualLocalizedName.OrganizationService = Service;
            txtVirtualReportViewName.OrganizationService = Service;
            dlgLookupSelectedEntity.Service = Service;
        }

        private void RetrieveFinanceAndOperationsIntegrationDetails()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieve FinanceAndOperations Integration Details...",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveFinanceAndOperationsIntegrationDetails();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                        pnlFinOpsNotFound.Visible = true;
                        imgGroupEntities.Enabled = false;
                        txtFinOpsUrl.Text = string.Empty;
                        
                    }
                    else
                    {

                        if (args.Result is FinanceAndOperationsIntegrationDetails details)
                        {
                            pnlFinOpsNotFound.Visible = false;
                            imgGroupEntities.Enabled = true;
                            txtFinOpsUrl.Text = details.Url;
                            btnLoad.Select();
                            // Enable disable load entities button
                            
                        }
                    }
                    btnFinOps.Enabled = !string.IsNullOrEmpty(txtFinOpsUrl.Text);
                    
                }
            });

        }


        private void LoadAvailableFinOpsEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Finance and Operations available entities...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetFinOpsEntities();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is EntityCollection)
                        {

                            _allFinOpsEntities = (EntityCollection)args.Result;
                            //Find the index of the selected API in the list
                            FilterResults();
                            SetGridFinOpsEntitiesDataSource();
                            SetUpdateButtonEnabled();

                            //find the current selected entity in the list , if not found set to null
                            var index = _filteredFinOpsEntities.Entities.Select(e => e.Id).ToList().IndexOf(_selectedFinOpsEntity?.FinOpsEntityRow.Id ?? Guid.Empty);
                            if (index < 0)
                            {
                                SetSelectedEntity(Guid.Empty);
                            }
                            else 
                            {
                                //gridAvailableEntities.CurrentCell = gridAvailableEntities.Rows[index].Cells[0];
                                gridAvailableEntities.Rows[index].Selected = true;
                                gridAvailableEntities.CurrentCell = gridAvailableEntities[2, index];
                            }
                        }
                        else
                        {
                            _allFinOpsEntities = new EntityCollection();
                        }

                        

                        //refresh selected entity / will refresh the form after update
                        if (_selectedFinOpsEntity != null) 
                        {
                            SetSelectedEntity(_selectedFinOpsEntity.FinOpsEntityRow.Id);
                        }

                    }
                }
            });

        }

        private void SetGridFinOpsEntitiesDataSource()
        {
            gridAvailableEntities.RecordEnter -= new CRMRecordEventHandler(gridAvailableEntities_RecordEnter);
            gridAvailableEntities.DataSource = _filteredFinOpsEntities;
            gridAvailableEntities.RowHeadersWidth = 24;
            gridAvailableEntities.Columns[2].HeaderText = "Physical Name";
            gridAvailableEntities.Columns[2].Width = 280;
            
            gridAvailableEntities.Columns[3].HeaderText = "Visible (Virtual Enabled)";
            gridAvailableEntities.Columns[3].Width = 100;
            gridAvailableEntities.Columns[4].HeaderText = "Change Tracking Enabled";
            gridAvailableEntities.Columns[4].Width = 100;
            gridAvailableEntities.RecordEnter += new CRMRecordEventHandler(gridAvailableEntities_RecordEnter);
        }

        private void gridAvailableEntities_RecordEnter(object sender, CRMRecordEventArgs e)
        {
            SetSelectedEntity(e.Entity.Id);
        }

        private void SetSelectedEntity(Guid selectedEntityId)
        {
            
            var selectedEntity = Service.GetFinOpsEntity(selectedEntityId);


            imgBoxSelectedEntity.Enabled = selectedEntity != null;
            _selectedFinOpsEntity = selectedEntity != null ? new FinOpsEntityProxy(selectedEntity) : null;


            
            txtPhysicalName.Entity = _selectedFinOpsEntity?.FinOpsEntityRow;
            
            switchVisible.Checked = _selectedFinOpsEntity?.IsVisible ?? false;
            switchChangeTracking.Checked = _selectedFinOpsEntity?.ChangeTrackingEnabled ?? false;
            switchRefresh.Checked = _selectedFinOpsEntity?.Refresh ?? false;

            SetVirtalEntityMetadata();

            SetUpdateButtonEnabled();
        }

        private void SetVirtalEntityMetadata()
        {
            _selectedVirtualEntityMetadata = Service.GetVirtualEntityMetadataFor(txtPhysicalName.Text);
            txtVirtualLogicalName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualPluralName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualExternalName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualLocalizedName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualReportViewName.Entity = _selectedVirtualEntityMetadata;

            imgGroupVirtual.Enabled = _selectedVirtualEntityMetadata != null;
            imgGroupDeepLink.Enabled = _selectedVirtualEntityMetadata != null;

            dlgLookupSelectedEntity.LogicalName = txtVirtualLogicalName.Text;
            txtLookupSelectedRecordId.Text = Guid.Empty.ToString();

            SetDeepLink();
        }

        private void SetDeepLink()
        {
            var deepLink = _selectedVirtualEntityMetadata != null ?
                    $"{txtFinOpsUrl.Text}/?mi=action:SysEntityNavigation&entityName={txtVirtualPluralName.Text}&entityGuid={txtLookupSelectedRecordId.Text}" :
                    string.Empty;

            rtbDeepLink.Text = deepLink;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFinOpsEntity();
        }

        private void SetUpdateButtonEnabled()
        {
            btnUpdate.Enabled = switchVisible.Checked != _selectedFinOpsEntity?.IsVisible
                                || switchChangeTracking.Checked != _selectedFinOpsEntity?.ChangeTrackingEnabled
                                || switchRefresh.Checked != _selectedFinOpsEntity?.Refresh;

        }

        private void UpdateFinOpsEntity()
        {
            var finOpsEntityToUpdate = new Entity(FinOpsEntity.EntityName, _selectedFinOpsEntity.FinOpsEntityRow.Id);
            var shouldUpdate = false;
            //Update only if needed
            if (_selectedFinOpsEntity.IsVisible != switchVisible.Checked)
            {
                finOpsEntityToUpdate[FinOpsEntity.Visible] = switchVisible.Checked;
                shouldUpdate = true;
            };
            if (_selectedFinOpsEntity.ChangeTrackingEnabled != switchChangeTracking.Checked)
            {
                finOpsEntityToUpdate[FinOpsEntity.ChangeTracking] = switchChangeTracking.Checked;
                shouldUpdate = true;
            };
            if (_selectedFinOpsEntity.Refresh != switchRefresh.Checked)
            {
                finOpsEntityToUpdate[FinOpsEntity.Refresh] = switchRefresh.Checked;
                shouldUpdate = true;
            };
            if (shouldUpdate)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = $"Updating {txtPhysicalName.Text} Entity...",
                    Work = (worker, args) =>
                    {
                        Service.Update(finOpsEntityToUpdate);
                        args.Result = true;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.Message);
                        }
                        else
                        {
                            ExecuteMethod(LoadAvailableFinOpsEntities);
                        }
                    }
                });
            }
        }

        private void tslAbout_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.StartPosition = FormStartPosition.CenterParent;
            about.lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            about.ShowDialog();
        }

        private void FilterResults()
        {
            _filteredFinOpsEntities = _allFinOpsEntities;
            if (chkShowVisible.Checked)
            {
                _filteredFinOpsEntities = new EntityCollection(_filteredFinOpsEntities.Entities.Where(e => e.GetAttributeValue<bool>(FinOpsEntity.Visible)).ToList());
            }
            if (chkShowChangeTracking.Checked)
            {
                _filteredFinOpsEntities = new EntityCollection(_filteredFinOpsEntities.Entities.Where(e => e.GetAttributeValue<bool>(FinOpsEntity.ChangeTracking)).ToList());
            }
            if (txtFilter.Text.Length > 0)
            {
                _filteredFinOpsEntities = new EntityCollection(_filteredFinOpsEntities.Entities.Where(e => e.GetAttributeValue<string>(FinOpsEntity.PrimaryName).ToLower().Contains(txtFilter.Text.ToLower())).ToList());

            }

        }

        private void chkShowVisible_CheckedChanged(object sender, EventArgs e)
        {
            FilterResults();
            SetGridFinOpsEntitiesDataSource();
        }

        private void chkShowChangeTracking_CheckedChanged(object sender, EventArgs e)
        {
            FilterResults();
            SetGridFinOpsEntitiesDataSource();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterResults();
            SetGridFinOpsEntitiesDataSource();
        }


        private void switchVisible_OnCheckedChanged(object sender, EventArgs e)
        {
            SetUpdateButtonEnabled();
        }

        private void switchChangeTracking_OnCheckedChanged(object sender, EventArgs e)
        {
            SetUpdateButtonEnabled();
        }

        private void switchRefresh_OnCheckedChanged(object sender, EventArgs e)
        {
            SetUpdateButtonEnabled();
        }

        private void gridAvailableEntities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            

            // return if rowCount = 0
            if (this.gridAvailableEntities.Rows.Count == 0)
            {
                return;
            }

            if (e.Value is string v && v == "True")
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
           
        }

        private void btnMetadataBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OnOutgoingMessage(this, new MessageBusEventArgs("Metadata Browser Companion") { TargetArgument = txtVirtualLogicalName.Text, NewInstance = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSql4Cds_Click(object sender, EventArgs e)
        {
            


            try
            {
                var sql = $"select * from {txtVirtualLogicalName.Text}";
                OnOutgoingMessage(this, new MessageBusEventArgs("SQL 4 CDS") { TargetArgument = sql, NewInstance = false });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btnFetchXmlBuilder_Click(object sender, EventArgs e)
        {
            

            try
            {
                var fetchXml = $@"<fetch>
                                    <entity name='{txtVirtualLogicalName.Text}' />
                                 </fetch>";
                OnOutgoingMessage(this, new MessageBusEventArgs("FetchXML Builder") { TargetArgument = fetchXml, NewInstance = false });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            //pass through
        }

       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://learn.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/power-platform/virtual-entities-overview?WT.mc_id=DX-MVP-5004959");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void btnPPAC_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start($"https://admin.powerplatform.microsoft.com/environments/environment/{ConnectionDetail?.EnvironmentId}/hub");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void btnDataverse_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txtDataverseUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void btnFinOps_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txtFinOpsUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void btnLookupSelectedEntity_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupSelectedEntity.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupSelectedRecordId.Text = dlgLookupSelectedEntity.Entity?.Id.ToString() ?? Guid.Empty.ToString();
                    SetDeepLink();
                    break;
                case DialogResult.Abort:
                    //txtLookupPluginType.Entity = null;
                    break;
            }

            Cursor = Cursors.Default;
        }

        private void lnkInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://learn.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/user-interface/create-deep-links?WT.mc_id=DX-MVP-5004959");
        }
    }
}