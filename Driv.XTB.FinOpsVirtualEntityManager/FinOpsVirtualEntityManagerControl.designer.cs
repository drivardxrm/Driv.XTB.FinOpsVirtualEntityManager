namespace Driv.XTB.FinOpsVirtualEntityManager
{
    partial class FinOpsVirtualEntityManagerControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinOpsVirtualEntityManagerControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.menuLoad = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslAbout = new System.Windows.Forms.ToolStripLabel();
            this.imageGroupBox1 = new Driv.XTB.FinOpsVirtualEntityManager.ImageGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowVisible = new System.Windows.Forms.CheckBox();
            this.gridAvailableEntities = new xrmtb.XrmToolBox.Controls.CRMGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.imgBoxSelectedEntity = new Driv.XTB.FinOpsVirtualEntityManager.ImageGroupBox();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.txtPhysicalName = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkChangeTracking = new System.Windows.Forms.CheckBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.imageGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.imgBoxSelectedEntity.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoad,
            this.tssSeparator1,
            this.tslAbout});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1261, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // menuLoad
            // 
            this.menuLoad.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_load_32;
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(171, 36);
            this.menuLoad.Text = "Load FinOps Entities";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tslAbout
            // 
            this.tslAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAbout.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_vr_20;
            this.tslAbout.IsLink = true;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.Size = new System.Drawing.Size(138, 36);
            this.tslAbout.Text = "by David Rivard";
            this.tslAbout.Click += new System.EventHandler(this.tslAbout_Click);
            // 
            // imageGroupBox1
            // 
            this.imageGroupBox1.Controls.Add(this.label2);
            this.imageGroupBox1.Controls.Add(this.chkShowVisible);
            this.imageGroupBox1.Controls.Add(this.gridAvailableEntities);
            this.imageGroupBox1.Controls.Add(this.pictureBox1);
            this.imageGroupBox1.Controls.Add(this.txtFilter);
            this.imageGroupBox1.Icon = ((System.Drawing.Icon)(resources.GetObject("imageGroupBox1.Icon")));
            this.imageGroupBox1.Location = new System.Drawing.Point(14, 65);
            this.imageGroupBox1.Name = "imageGroupBox1";
            this.imageGroupBox1.Size = new System.Drawing.Size(712, 755);
            this.imageGroupBox1.TabIndex = 108;
            this.imageGroupBox1.TabStop = false;
            this.imageGroupBox1.Text = "Finance and Operations Available entities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 105;
            this.label2.Text = "Filter by name";
            // 
            // chkShowVisible
            // 
            this.chkShowVisible.AutoSize = true;
            this.chkShowVisible.Location = new System.Drawing.Point(407, 47);
            this.chkShowVisible.Name = "chkShowVisible";
            this.chkShowVisible.Size = new System.Drawing.Size(273, 20);
            this.chkShowVisible.TabIndex = 103;
            this.chkShowVisible.Text = "Show Visible (Virtual Entity Enabled) Only";
            this.chkShowVisible.UseVisualStyleBackColor = true;
            this.chkShowVisible.CheckedChanged += new System.EventHandler(this.chkShowVisible_CheckedChanged);
            // 
            // gridAvailableEntities
            // 
            this.gridAvailableEntities.AllowUserToOrderColumns = true;
            this.gridAvailableEntities.AllowUserToResizeRows = false;
            this.gridAvailableEntities.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAvailableEntities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAvailableEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAvailableEntities.ColumnOrder = "mserp_physicalname, mserp_hasbeengenerated, mserp_changetrackingenabled";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAvailableEntities.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridAvailableEntities.FilterColumns = "";
            this.gridAvailableEntities.Location = new System.Drawing.Point(12, 74);
            this.gridAvailableEntities.Margin = new System.Windows.Forms.Padding(4);
            this.gridAvailableEntities.MultiSelect = false;
            this.gridAvailableEntities.Name = "gridAvailableEntities";
            this.gridAvailableEntities.OrganizationService = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAvailableEntities.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridAvailableEntities.RowHeadersWidth = 51;
            this.gridAvailableEntities.ShowAllColumnsInColumnOrder = true;
            this.gridAvailableEntities.ShowColumnsNotInColumnOrder = false;
            this.gridAvailableEntities.ShowIdColumn = false;
            this.gridAvailableEntities.ShowIndexColumn = false;
            this.gridAvailableEntities.Size = new System.Drawing.Size(673, 657);
            this.gridAvailableEntities.TabIndex = 6;
            this.gridAvailableEntities.RecordEnter += new xrmtb.XrmToolBox.Controls.CRMRecordEventHandler(this.gridAvailableEntities_RecordEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_filter_20;
            this.pictureBox1.Location = new System.Drawing.Point(110, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 23);
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(135, 45);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(266, 22);
            this.txtFilter.TabIndex = 104;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // imgBoxSelectedEntity
            // 
            this.imgBoxSelectedEntity.Controls.Add(this.chkRefresh);
            this.imgBoxSelectedEntity.Controls.Add(this.txtPhysicalName);
            this.imgBoxSelectedEntity.Controls.Add(this.label7);
            this.imgBoxSelectedEntity.Controls.Add(this.chkChangeTracking);
            this.imgBoxSelectedEntity.Controls.Add(this.chkVisible);
            this.imgBoxSelectedEntity.Controls.Add(this.btnUpdate);
            this.imgBoxSelectedEntity.Enabled = false;
            this.imgBoxSelectedEntity.Icon = ((System.Drawing.Icon)(resources.GetObject("imgBoxSelectedEntity.Icon")));
            this.imgBoxSelectedEntity.Location = new System.Drawing.Point(732, 65);
            this.imgBoxSelectedEntity.Name = "imgBoxSelectedEntity";
            this.imgBoxSelectedEntity.Size = new System.Drawing.Size(481, 209);
            this.imgBoxSelectedEntity.TabIndex = 107;
            this.imgBoxSelectedEntity.TabStop = false;
            this.imgBoxSelectedEntity.Text = "Selected Entity";
            // 
            // chkRefresh
            // 
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.Location = new System.Drawing.Point(22, 137);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(136, 20);
            this.chkRefresh.TabIndex = 99;
            this.chkRefresh.Text = "Refresh Metadata";
            this.chkRefresh.UseVisualStyleBackColor = true;
            this.chkRefresh.CheckedChanged += new System.EventHandler(this.chkRefresh_CheckedChanged);
            // 
            // txtPhysicalName
            // 
            this.txtPhysicalName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhysicalName.DisplayFormat = "mserp_physicalname";
            this.txtPhysicalName.Entity = null;
            this.txtPhysicalName.EntityReference = null;
            this.txtPhysicalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysicalName.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtPhysicalName.Location = new System.Drawing.Point(123, 48);
            this.txtPhysicalName.LogicalName = "mserp_financeandoperationsentity";
            this.txtPhysicalName.Name = "txtPhysicalName";
            this.txtPhysicalName.OrganizationService = null;
            this.txtPhysicalName.Size = new System.Drawing.Size(329, 22);
            this.txtPhysicalName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 96;
            this.label7.Text = "Physical Name";
            // 
            // chkChangeTracking
            // 
            this.chkChangeTracking.AutoSize = true;
            this.chkChangeTracking.Location = new System.Drawing.Point(22, 111);
            this.chkChangeTracking.Name = "chkChangeTracking";
            this.chkChangeTracking.Size = new System.Drawing.Size(186, 20);
            this.chkChangeTracking.TabIndex = 97;
            this.chkChangeTracking.Text = "Change Tracking Enabled";
            this.chkChangeTracking.UseVisualStyleBackColor = true;
            this.chkChangeTracking.CheckedChanged += new System.EventHandler(this.chkChangeTracking_CheckedChanged);
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(22, 79);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(207, 20);
            this.chkVisible.TabIndex = 98;
            this.chkVisible.Text = "Visible (Virtual Entity Enabled)";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.chkVisible_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_update_20;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(22, 164);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 32);
            this.btnUpdate.TabIndex = 101;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FinOpsVirtualEntityManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageGroupBox1);
            this.Controls.Add(this.imgBoxSelectedEntity);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FinOpsVirtualEntityManagerControl";
            this.Size = new System.Drawing.Size(1009, 658);
            this.Load += new System.EventHandler(this.FinOpsVirtualEntityManagerControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.imageGroupBox1.ResumeLayout(false);
            this.imageGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.imgBoxSelectedEntity.ResumeLayout(false);
            this.imgBoxSelectedEntity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton menuLoad;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private xrmtb.XrmToolBox.Controls.CRMGridView gridAvailableEntities;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtPhysicalName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkChangeTracking;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkShowVisible;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ImageGroupBox imgBoxSelectedEntity;
        private ImageGroupBox imageGroupBox1;
    }
}
