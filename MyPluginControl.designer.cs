namespace Entity_Security_Plugin
{
    partial class MyPluginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGetData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabSecurities = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbRoles = new System.Windows.Forms.DataGridView();
            this.clRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCreate = new System.Windows.Forms.DataGridViewImageColumn();
            this.clRead = new System.Windows.Forms.DataGridViewImageColumn();
            this.clWrite = new System.Windows.Forms.DataGridViewImageColumn();
            this.clDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.clApend = new System.Windows.Forms.DataGridViewImageColumn();
            this.clAppendTo = new System.Windows.Forms.DataGridViewImageColumn();
            this.clAssign = new System.Windows.Forms.DataGridViewImageColumn();
            this.clShare = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetRoles = new System.Windows.Forms.Button();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabSecurities.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbGetData,
            this.toolStripSeparator1,
            this.btnExport});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1385, 27);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(49, 24);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbGetData
            // 
            this.tsbGetData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsbGetData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGetData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbGetData.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetData.Image")));
            this.tsbGetData.Name = "tsbGetData";
            this.tsbGetData.Size = new System.Drawing.Size(72, 24);
            this.tsbGetData.Text = "Get Data";
            this.tsbGetData.Click += new System.EventHandler(this.tbsGetData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(56, 24);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightYellow;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.84948F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.15052F));
            this.tableLayoutPanel1.Controls.Add(this.tabSecurities, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1385, 432);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tabSecurities
            // 
            this.tabSecurities.Controls.Add(this.tabPage1);
            this.tabSecurities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSecurities.Location = new System.Drawing.Point(431, 44);
            this.tabSecurities.Margin = new System.Windows.Forms.Padding(4);
            this.tabSecurities.Name = "tabSecurities";
            this.tabSecurities.SelectedIndex = 0;
            this.tabSecurities.Size = new System.Drawing.Size(950, 384);
            this.tabSecurities.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.tbRoles);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(942, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Security Roles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbRoles
            // 
            this.tbRoles.AllowUserToAddRows = false;
            this.tbRoles.AllowUserToDeleteRows = false;
            this.tbRoles.AllowUserToResizeColumns = false;
            this.tbRoles.AllowUserToResizeRows = false;
            this.tbRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbRoles.BackgroundColor = System.Drawing.Color.Ivory;
            this.tbRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clRole,
            this.clCreate,
            this.clRead,
            this.clWrite,
            this.clDelete,
            this.clApend,
            this.clAppendTo,
            this.clAssign,
            this.clShare});
            this.tbRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRoles.Location = new System.Drawing.Point(4, 4);
            this.tbRoles.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoles.Name = "tbRoles";
            this.tbRoles.ReadOnly = true;
            this.tbRoles.RowHeadersWidth = 51;
            this.tbRoles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbRoles.Size = new System.Drawing.Size(934, 347);
            this.tbRoles.TabIndex = 0;
            // 
            // clRole
            // 
            this.clRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clRole.DataPropertyName = "Role";
            this.clRole.HeaderText = "Security Roles";
            this.clRole.MinimumWidth = 6;
            this.clRole.Name = "clRole";
            this.clRole.ReadOnly = true;
            this.clRole.Width = 123;
            // 
            // clCreate
            // 
            this.clCreate.DataPropertyName = "Create";
            this.clCreate.HeaderText = "Create";
            this.clCreate.MinimumWidth = 6;
            this.clCreate.Name = "clCreate";
            this.clCreate.ReadOnly = true;
            this.clCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clRead
            // 
            this.clRead.DataPropertyName = "Read";
            this.clRead.HeaderText = "Read";
            this.clRead.MinimumWidth = 6;
            this.clRead.Name = "clRead";
            this.clRead.ReadOnly = true;
            this.clRead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clWrite
            // 
            this.clWrite.DataPropertyName = "Write";
            this.clWrite.HeaderText = "Write";
            this.clWrite.MinimumWidth = 6;
            this.clWrite.Name = "clWrite";
            this.clWrite.ReadOnly = true;
            this.clWrite.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDelete
            // 
            this.clDelete.DataPropertyName = "Delete";
            this.clDelete.HeaderText = "Delete";
            this.clDelete.MinimumWidth = 6;
            this.clDelete.Name = "clDelete";
            this.clDelete.ReadOnly = true;
            this.clDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clApend
            // 
            this.clApend.DataPropertyName = "Append";
            this.clApend.HeaderText = "Append";
            this.clApend.MinimumWidth = 6;
            this.clApend.Name = "clApend";
            this.clApend.ReadOnly = true;
            this.clApend.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clAppendTo
            // 
            this.clAppendTo.DataPropertyName = "AppendTo";
            this.clAppendTo.HeaderText = "Append To";
            this.clAppendTo.MinimumWidth = 6;
            this.clAppendTo.Name = "clAppendTo";
            this.clAppendTo.ReadOnly = true;
            this.clAppendTo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clAssign
            // 
            this.clAssign.DataPropertyName = "Assign";
            this.clAssign.HeaderText = "Assign";
            this.clAssign.MinimumWidth = 6;
            this.clAssign.Name = "clAssign";
            this.clAssign.ReadOnly = true;
            this.clAssign.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clShare
            // 
            this.clShare.DataPropertyName = "Share";
            this.clShare.HeaderText = "Share";
            this.clShare.MinimumWidth = 6;
            this.clShare.Name = "clShare";
            this.clShare.ReadOnly = true;
            this.clShare.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnGetRoles);
            this.panel1.Controls.Add(this.cbEntities);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 48);
            this.panel1.TabIndex = 9;
            // 
            // btnGetRoles
            // 
            this.btnGetRoles.Location = new System.Drawing.Point(280, 16);
            this.btnGetRoles.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetRoles.Name = "btnGetRoles";
            this.btnGetRoles.Size = new System.Drawing.Size(100, 28);
            this.btnGetRoles.TabIndex = 9;
            this.btnGetRoles.Text = "Get Roles";
            this.btnGetRoles.UseVisualStyleBackColor = true;
            this.btnGetRoles.Click += new System.EventHandler(this.btnGetRoles_Click);
            // 
            // cbEntities
            // 
            this.cbEntities.FormattingEnabled = true;
            this.cbEntities.Location = new System.Drawing.Point(64, 18);
            this.cbEntities.Margin = new System.Windows.Forms.Padding(4);
            this.cbEntities.Name = "cbEntities";
            this.cbEntities.Size = new System.Drawing.Size(207, 24);
            this.cbEntities.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entity:";
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1385, 432);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabSecurities.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbRoles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbGetData;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabSecurities;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView tbRoles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetRoles;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRole;
        private System.Windows.Forms.DataGridViewImageColumn clCreate;
        private System.Windows.Forms.DataGridViewImageColumn clRead;
        private System.Windows.Forms.DataGridViewImageColumn clWrite;
        private System.Windows.Forms.DataGridViewImageColumn clDelete;
        private System.Windows.Forms.DataGridViewImageColumn clApend;
        private System.Windows.Forms.DataGridViewImageColumn clAppendTo;
        private System.Windows.Forms.DataGridViewImageColumn clAssign;
        private System.Windows.Forms.DataGridViewImageColumn clShare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        // private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
