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
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.switchChangeTracking = new Driv.XTB.FinOpsVirtualEntityManager.SwitchControl();
            this.switchRefresh = new Driv.XTB.FinOpsVirtualEntityManager.SwitchControl();
            this.switchVisible = new Driv.XTB.FinOpsVirtualEntityManager.SwitchControl();
            this.imageGroupBox1 = new Driv.XTB.FinOpsVirtualEntityManager.ImageGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowVisible = new System.Windows.Forms.CheckBox();
            this.gridAvailableEntities = new xrmtb.XrmToolBox.Controls.CRMGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.imgBoxSelectedEntity = new Driv.XTB.FinOpsVirtualEntityManager.ImageGroupBox();
            this.txtPhysicalName = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuLoad = new System.Windows.Forms.ToolStripButton();
            this.tslAbout = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMenu.SuspendLayout();
            this.imageGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableEntities)).BeginInit();
            this.imgBoxSelectedEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.toolStripMenu.Size = new System.Drawing.Size(973, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 17);
            this.label1.TabIndex = 112;
            this.label1.Text = "Visible (Virtual Entity Enabled)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 115;
            this.label4.Text = "Change Tracking Enabled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 117;
            this.label3.Text = "Refresh Metadata";
            // 
            // switchChangeTracking
            // 
            this.switchChangeTracking.Checked = false;
            this.switchChangeTracking.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchChangeTracking.Location = new System.Drawing.Point(247, 106);
            this.switchChangeTracking.Margin = new System.Windows.Forms.Padding(4);
            this.switchChangeTracking.Name = "switchChangeTracking";
            this.switchChangeTracking.Size = new System.Drawing.Size(90, 32);
            this.switchChangeTracking.TabIndex = 111;
            this.switchChangeTracking.OnCheckedChanged += new System.EventHandler(this.switchChangeTracking_OnCheckedChanged);
            // 
            // switchRefresh
            // 
            this.switchRefresh.Checked = false;
            this.switchRefresh.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchRefresh.Location = new System.Drawing.Point(247, 139);
            this.switchRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.switchRefresh.Name = "switchRefresh";
            this.switchRefresh.Size = new System.Drawing.Size(90, 32);
            this.switchRefresh.TabIndex = 110;
            this.switchRefresh.OnCheckedChanged += new System.EventHandler(this.switchRefresh_OnCheckedChanged);
            // 
            // switchVisible
            // 
            this.switchVisible.Checked = false;
            this.switchVisible.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchVisible.Location = new System.Drawing.Point(247, 72);
            this.switchVisible.Margin = new System.Windows.Forms.Padding(4);
            this.switchVisible.Name = "switchVisible";
            this.switchVisible.Size = new System.Drawing.Size(90, 32);
            this.switchVisible.TabIndex = 109;
            this.switchVisible.OnCheckedChanged += new System.EventHandler(this.switchVisible_OnCheckedChanged);
            // 
            // imageGroupBox1
            // 
            this.imageGroupBox1.Controls.Add(this.label2);
            this.imageGroupBox1.Controls.Add(this.chkShowVisible);
            this.imageGroupBox1.Controls.Add(this.gridAvailableEntities);
            this.imageGroupBox1.Controls.Add(this.pictureBox1);
            this.imageGroupBox1.Controls.Add(this.txtFilter);
            this.imageGroupBox1.Icon = ((System.Drawing.Icon)(resources.GetObject("imageGroupBox1.Icon")));
            this.imageGroupBox1.Location = new System.Drawing.Point(10, 53);
            this.imageGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.imageGroupBox1.Name = "imageGroupBox1";
            this.imageGroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.imageGroupBox1.Size = new System.Drawing.Size(534, 613);
            this.imageGroupBox1.TabIndex = 108;
            this.imageGroupBox1.TabStop = false;
            this.imageGroupBox1.Text = "Finance and Operations Available entities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Filter by name";
            // 
            // chkShowVisible
            // 
            this.chkShowVisible.AutoSize = true;
            this.chkShowVisible.Location = new System.Drawing.Point(305, 38);
            this.chkShowVisible.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowVisible.Name = "chkShowVisible";
            this.chkShowVisible.Size = new System.Drawing.Size(219, 17);
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
            this.gridAvailableEntities.Location = new System.Drawing.Point(9, 60);
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
            this.gridAvailableEntities.Size = new System.Drawing.Size(505, 534);
            this.gridAvailableEntities.TabIndex = 6;
            this.gridAvailableEntities.RecordEnter += new xrmtb.XrmToolBox.Controls.CRMRecordEventHandler(this.gridAvailableEntities_RecordEnter);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(101, 37);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(200, 20);
            this.txtFilter.TabIndex = 104;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // imgBoxSelectedEntity
            // 
            this.imgBoxSelectedEntity.Controls.Add(this.txtPhysicalName);
            this.imgBoxSelectedEntity.Controls.Add(this.label3);
            this.imgBoxSelectedEntity.Controls.Add(this.label7);
            this.imgBoxSelectedEntity.Controls.Add(this.pictureBox4);
            this.imgBoxSelectedEntity.Controls.Add(this.btnUpdate);
            this.imgBoxSelectedEntity.Controls.Add(this.label4);
            this.imgBoxSelectedEntity.Controls.Add(this.pictureBox2);
            this.imgBoxSelectedEntity.Controls.Add(this.switchVisible);
            this.imgBoxSelectedEntity.Controls.Add(this.pictureBox3);
            this.imgBoxSelectedEntity.Controls.Add(this.switchRefresh);
            this.imgBoxSelectedEntity.Controls.Add(this.switchChangeTracking);
            this.imgBoxSelectedEntity.Controls.Add(this.label1);
            this.imgBoxSelectedEntity.Enabled = false;
            this.imgBoxSelectedEntity.Icon = ((System.Drawing.Icon)(resources.GetObject("imgBoxSelectedEntity.Icon")));
            this.imgBoxSelectedEntity.Location = new System.Drawing.Point(549, 53);
            this.imgBoxSelectedEntity.Margin = new System.Windows.Forms.Padding(2);
            this.imgBoxSelectedEntity.Name = "imgBoxSelectedEntity";
            this.imgBoxSelectedEntity.Padding = new System.Windows.Forms.Padding(2);
            this.imgBoxSelectedEntity.Size = new System.Drawing.Size(361, 225);
            this.imgBoxSelectedEntity.TabIndex = 107;
            this.imgBoxSelectedEntity.TabStop = false;
            this.imgBoxSelectedEntity.Text = "Selected Entity";
            // 
            // txtPhysicalName
            // 
            this.txtPhysicalName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhysicalName.DisplayFormat = "mserp_physicalname";
            this.txtPhysicalName.Entity = null;
            this.txtPhysicalName.EntityReference = null;
            this.txtPhysicalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysicalName.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtPhysicalName.Location = new System.Drawing.Point(92, 39);
            this.txtPhysicalName.LogicalName = "mserp_financeandoperationsentity";
            this.txtPhysicalName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhysicalName.Name = "txtPhysicalName";
            this.txtPhysicalName.OrganizationService = null;
            this.txtPhysicalName.Size = new System.Drawing.Size(248, 23);
            this.txtPhysicalName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Physical Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_filter_20;
            this.pictureBox1.Location = new System.Drawing.Point(82, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 19);
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_refresh_32;
            this.pictureBox4.Location = new System.Drawing.Point(17, 137);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 34);
            this.pictureBox4.TabIndex = 116;
            this.pictureBox4.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_update_32;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(246, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 39);
            this.btnUpdate.TabIndex = 101;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_visible_32;
            this.pictureBox2.Location = new System.Drawing.Point(17, 70);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 34);
            this.pictureBox2.TabIndex = 107;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_change_32;
            this.pictureBox3.Location = new System.Drawing.Point(17, 104);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 34);
            this.pictureBox3.TabIndex = 114;
            this.pictureBox3.TabStop = false;
            // 
            // menuLoad
            // 
            this.menuLoad.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_load_32;
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(142, 28);
            this.menuLoad.Text = "Load FinOps Entities";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // tslAbout
            // 
            this.tslAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAbout.Image = global::Driv.XTB.FinOpsVirtualEntityManager.Properties.Resources.icons8_vr_20;
            this.tslAbout.IsLink = true;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.Size = new System.Drawing.Size(113, 28);
            this.tslAbout.Text = "by David Rivard";
            this.tslAbout.Click += new System.EventHandler(this.tslAbout_Click);
            // 
            // FinOpsVirtualEntityManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageGroupBox1);
            this.Controls.Add(this.imgBoxSelectedEntity);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "FinOpsVirtualEntityManagerControl";
            this.Size = new System.Drawing.Size(973, 710);
            this.Load += new System.EventHandler(this.FinOpsVirtualEntityManagerControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.imageGroupBox1.ResumeLayout(false);
            this.imageGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableEntities)).EndInit();
            this.imgBoxSelectedEntity.ResumeLayout(false);
            this.imgBoxSelectedEntity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkShowVisible;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ImageGroupBox imgBoxSelectedEntity;
        private ImageGroupBox imageGroupBox1;
        private SwitchControl switchVisible;
        private SwitchControl switchRefresh;
        private SwitchControl switchChangeTracking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
    }
}
