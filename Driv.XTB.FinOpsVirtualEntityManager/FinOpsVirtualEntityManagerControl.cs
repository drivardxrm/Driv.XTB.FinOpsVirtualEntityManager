using Driv.XTB.FinOpsVirtualEntityManager.Entities;
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

namespace Driv.XTB.FinOpsVirtualEntityManager
{
    public partial class FinOpsVirtualEntityManagerControl : PluginControlBase, IGitHubPlugin, IMessageBusHost
    {
        //private Settings mySettings;
        private Settings _globalsettings;
        private Settings _connectionsettings;

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
            LoadGlobalSettings();
            LoadConnectionSettings();
            ExecuteMethod(InitializeService);
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
            if (!SettingsManager.Instance.TryLoad(GetType(), out _connectionsettings, ConnectionDetail.ConnectionId.ToString()))
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


            if (_globalsettings != null && detail != null)
            {
                LoadConnectionSettings();

                _globalsettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);




                //ExecuteMethod(InitializeService);



            }
        }

        private void menuLoad_Click(object sender, EventArgs e)
        {
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
                            SetUpdateButtonVisible();

                            //hack to force a refresh... must be a better way
                            var index = _filteredFinOpsEntities.Entities.Select(e => e.Id).ToList().IndexOf(_selectedFinOpsEntity?.FinOpsEntityRow.Id ?? Guid.Empty);
                            //if (gridAvailableEntities.SelectedRows.Contains().SelectedIndex == index)
                            //{
                            //    cdsCboCustomApi.SelectedIndex = -1;
                            //}
                            //cdsCboCustomApi.SelectedIndex = index;
                            //cdsCboCustomApi.Enabled = true;
                        }
                        else
                        {
                            _allFinOpsEntities = new EntityCollection();
                        }

                        if (_allFinOpsEntities.TotalRecordCount == 0)
                        {
                            pnlFinOpsNotFound.Visible = true;
                            imgGroupEntities.Enabled = false;
                        }
                        else 
                        {
                            pnlFinOpsNotFound.Visible = false;
                            imgGroupEntities.Enabled= true;
                        }

                    }
                }
            });

        }

        private void SetGridFinOpsEntitiesDataSource()
        {
            gridAvailableEntities.RecordEnter -= new CRMRecordEventHandler(gridAvailableEntities_RecordEnter);
            gridAvailableEntities.DataSource = _filteredFinOpsEntities;

            gridAvailableEntities.Columns[1].Width = 25;
            gridAvailableEntities.Columns[2].HeaderText = "Physical Name";
            gridAvailableEntities.Columns[2].Width = 250;
            
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

            SetUpdateButtonVisible();
        }

        private void SetVirtalEntityMetadata()
        {
            _selectedVirtualEntityMetadata = Service.GetVirtualEntityMetadataFor(txtPhysicalName.Text);
            txtVirtualLogicalName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualExternalName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualLocalizedName.Entity = _selectedVirtualEntityMetadata;
            txtVirtualReportViewName.Entity = _selectedVirtualEntityMetadata;

            imgGroupVirtual.Enabled = _selectedVirtualEntityMetadata != null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFinOpsEntity();
        }

        private void SetUpdateButtonVisible()
        {
            btnUpdate.Visible = switchVisible.Checked != _selectedFinOpsEntity?.IsVisible
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
            SetUpdateButtonVisible();
        }

        private void switchChangeTracking_OnCheckedChanged(object sender, EventArgs e)
        {
            SetUpdateButtonVisible();
        }

        private void switchRefresh_OnCheckedChanged(object sender, EventArgs e)
        {
            SetUpdateButtonVisible();
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

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            throw new NotImplementedException();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited
                // to true.
                linkLabel1.LinkVisited = true;
                //Call the Process.Start method to open the default browser
                //with a URL:
                System.Diagnostics.Process.Start("https://learn.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/power-platform/virtual-entities-overview?WT.mc_id=DX-MVP-5004959");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }
    }
}