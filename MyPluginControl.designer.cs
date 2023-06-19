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
            this.tbRoleDefinition = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetRoles = new System.Windows.Forms.Button();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabSecurities.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoles)).BeginInit();
            this.panel1.SuspendLayout();
            this.tbRoleDefinition.SuspendLayout();
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
            this.btnExport,
            this.toolStripButton1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1038, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbGetData
            // 
            this.tsbGetData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsbGetData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGetData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbGetData.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetData.Image")));
            this.tsbGetData.Name = "tsbGetData";
            this.tsbGetData.Size = new System.Drawing.Size(56, 22);
            this.tsbGetData.Text = "Get Data";
            this.tsbGetData.Click += new System.EventHandler(this.tbsGetData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(45, 22);
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 350);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tabSecurities
            // 
            this.tabSecurities.Controls.Add(this.tabPage1);
            this.tabSecurities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSecurities.Location = new System.Drawing.Point(323, 35);
            this.tabSecurities.Name = "tabSecurities";
            this.tabSecurities.SelectedIndex = 0;
            this.tabSecurities.Size = new System.Drawing.Size(712, 312);
            this.tabSecurities.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.tbRoles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(704, 286);
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
            this.tbRoles.Location = new System.Drawing.Point(3, 3);
            this.tbRoles.Name = "tbRoles";
            this.tbRoles.ReadOnly = true;
            this.tbRoles.RowHeadersWidth = 51;
            this.tbRoles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbRoles.Size = new System.Drawing.Size(698, 280);
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
            this.panel1.Controls.Add(this.tbRoleDefinition);
            this.panel1.Controls.Add(this.btnGetRoles);
            this.panel1.Controls.Add(this.cbEntities);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 256);
            this.panel1.TabIndex = 9;
            // 
            // tbRoleDefinition
            // 
            this.tbRoleDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRoleDefinition.BackColor = System.Drawing.Color.Ivory;
            this.tbRoleDefinition.ColumnCount = 2;
            this.tbRoleDefinition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbRoleDefinition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.Controls.Add(this.label3, 0, 1);
            this.tbRoleDefinition.Controls.Add(this.label2, 0, 0);
            this.tbRoleDefinition.Controls.Add(this.label4, 0, 2);
            this.tbRoleDefinition.Controls.Add(this.label5, 0, 3);
            this.tbRoleDefinition.Controls.Add(this.label6, 0, 4);
            this.tbRoleDefinition.Location = new System.Drawing.Point(8, 72);
            this.tbRoleDefinition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRoleDefinition.Name = "tbRoleDefinition";
            this.tbRoleDefinition.RowCount = 5;
            this.tbRoleDefinition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbRoleDefinition.Size = new System.Drawing.Size(179, 132);
            this.tbRoleDefinition.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "1. User Level";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "0. No Access";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "2. Business Unit Level";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "3. Child Business Unit Level";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "4. Organization";
            // 
            // btnGetRoles
            // 
            this.btnGetRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRoles.Location = new System.Drawing.Point(210, 15);
            this.btnGetRoles.Name = "btnGetRoles";
            this.btnGetRoles.Size = new System.Drawing.Size(75, 20);
            this.btnGetRoles.TabIndex = 9;
            this.btnGetRoles.Text = "Get Roles";
            this.btnGetRoles.UseVisualStyleBackColor = true;
            this.btnGetRoles.Click += new System.EventHandler(this.btnGetRoles_Click);
            // 
            // cbEntities
            // 
            this.cbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntities.FormattingEnabled = true;
            this.cbEntities.Location = new System.Drawing.Point(48, 15);
            this.cbEntities.Name = "cbEntities";
            this.cbEntities.Size = new System.Drawing.Size(156, 21);
            this.cbEntities.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entity:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, -81);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton1.Text = "Test";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1038, 350);
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
            this.tbRoleDefinition.ResumeLayout(false);
            this.tbRoleDefinition.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tbRoleDefinition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        // private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
