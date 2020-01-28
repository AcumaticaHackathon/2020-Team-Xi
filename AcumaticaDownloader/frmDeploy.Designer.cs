namespace AcumaticaDeployer
{
    partial class frmDeploy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeploy));
            this.btnGetNewVersions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.cboPatch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNewDB = new System.Windows.Forms.CheckBox();
            this.chkDemoData = new System.Windows.Forms.CheckBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.chkPortal = new System.Windows.Forms.CheckBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtInstance = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDBPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCustom = new CheckComboBoxTest.CheckedComboBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtACUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtACPass = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveWebConfig = new System.Windows.Forms.Button();
            this.OptionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSnapshot = new System.Windows.Forms.TextBox();
            this.btnOFDSnaphot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetNewVersions
            // 
            this.btnGetNewVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetNewVersions.Location = new System.Drawing.Point(682, 494);
            this.btnGetNewVersions.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetNewVersions.Name = "btnGetNewVersions";
            this.btnGetNewVersions.Size = new System.Drawing.Size(151, 28);
            this.btnGetNewVersions.TabIndex = 22;
            this.btnGetNewVersions.Text = "Bulk Downloads";
            this.btnGetNewVersions.UseVisualStyleBackColor = true;
            this.btnGetNewVersions.Click += new System.EventHandler(this.BtnGetNewVersions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Major Version";
            // 
            // cboVersion
            // 
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(180, 78);
            this.cboVersion.Margin = new System.Windows.Forms.Padding(4);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(357, 24);
            this.cboVersion.TabIndex = 3;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            this.cboVersion.TextUpdate += new System.EventHandler(this.cboVersion_TextUpdate);
            // 
            // cboPatch
            // 
            this.cboPatch.DisplayMember = "Label";
            this.cboPatch.FormattingEnabled = true;
            this.cboPatch.Location = new System.Drawing.Point(180, 111);
            this.cboPatch.Margin = new System.Windows.Forms.Padding(4);
            this.cboPatch.Name = "cboPatch";
            this.cboPatch.Size = new System.Drawing.Size(357, 24);
            this.cboPatch.TabIndex = 4;
            this.cboPatch.ValueMember = "AppVersion";
            this.cboPatch.SelectedIndexChanged += new System.EventHandler(this.cboPatch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patch Level";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(135, 52);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(357, 22);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.TextChanged += new System.EventHandler(this.txtDBName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "DB Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instance Name";
            // 
            // chkNewDB
            // 
            this.chkNewDB.AutoSize = true;
            this.chkNewDB.Location = new System.Drawing.Point(135, 148);
            this.chkNewDB.Margin = new System.Windows.Forms.Padding(4);
            this.chkNewDB.Name = "chkNewDB";
            this.chkNewDB.Size = new System.Drawing.Size(80, 21);
            this.chkNewDB.TabIndex = 14;
            this.chkNewDB.Text = "New DB";
            this.chkNewDB.UseVisualStyleBackColor = true;
            // 
            // chkDemoData
            // 
            this.chkDemoData.AutoSize = true;
            this.chkDemoData.Location = new System.Drawing.Point(247, 148);
            this.chkDemoData.Margin = new System.Windows.Forms.Padding(4);
            this.chkDemoData.Name = "chkDemoData";
            this.chkDemoData.Size = new System.Drawing.Size(101, 21);
            this.chkDemoData.TabIndex = 15;
            this.chkDemoData.Text = "Demo Data";
            this.chkDemoData.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(682, 42);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(144, 28);
            this.btnInstall.TabIndex = 16;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Enabled = false;
            this.btnUpgrade.Location = new System.Drawing.Point(682, 79);
            this.btnUpgrade.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(144, 28);
            this.btnUpgrade.TabIndex = 17;
            this.btnUpgrade.Text = "Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.BtnUpgrade_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 530);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(842, 28);
            this.progressBar1.TabIndex = 13;
            // 
            // rtbLogs
            // 
            this.rtbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogs.Location = new System.Drawing.Point(16, 332);
            this.rtbLogs.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(815, 153);
            this.rtbLogs.TabIndex = 14;
            this.rtbLogs.Text = "";
            // 
            // chkPortal
            // 
            this.chkPortal.AutoSize = true;
            this.chkPortal.Location = new System.Drawing.Point(20, 12);
            this.chkPortal.Margin = new System.Windows.Forms.Padding(4);
            this.chkPortal.Name = "chkPortal";
            this.chkPortal.Size = new System.Drawing.Size(67, 21);
            this.chkPortal.TabIndex = 5;
            this.chkPortal.Text = "Portal";
            this.chkPortal.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(682, 114);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(144, 28);
            this.btnSettings.TabIndex = 18;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(197, 533);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 17;
            // 
            // txtInstance
            // 
            this.txtInstance.FormattingEnabled = true;
            this.txtInstance.Location = new System.Drawing.Point(180, 43);
            this.txtInstance.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(357, 24);
            this.txtInstance.TabIndex = 6;
            this.txtInstance.SelectedIndexChanged += new System.EventHandler(this.txtInstance_SelectedIndexChanged);
            this.txtInstance.TextChanged += new System.EventHandler(this.txtInstance_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(523, 494);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(151, 28);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh Cache";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "DB Server";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(135, 20);
            this.txtDBServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(357, 22);
            this.txtDBServer.TabIndex = 10;
            this.txtDBServer.TextChanged += new System.EventHandler(this.txtDBServer_TextChangedAsync);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "DB User";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(135, 84);
            this.txtDBUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(357, 22);
            this.txtDBUser.TabIndex = 12;
            this.txtDBUser.TextChanged += new System.EventHandler(this.txtDBUser_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 121);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "DB Pass";
            // 
            // txtDBPass
            // 
            this.txtDBPass.Location = new System.Drawing.Point(135, 116);
            this.txtDBPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBPass.Name = "txtDBPass";
            this.txtDBPass.Size = new System.Drawing.Size(357, 22);
            this.txtDBPass.TabIndex = 13;
            this.txtDBPass.TextChanged += new System.EventHandler(this.txtDBPass_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Customizations";
            // 
            // cboCustom
            // 
            this.cboCustom.CheckOnClick = true;
            this.cboCustom.DisplayMember = "Name";
            this.cboCustom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCustom.DropDownHeight = 1;
            this.cboCustom.FormattingEnabled = true;
            this.cboCustom.IntegralHeight = false;
            this.cboCustom.Location = new System.Drawing.Point(180, 76);
            this.cboCustom.Margin = new System.Windows.Forms.Padding(4);
            this.cboCustom.Name = "cboCustom";
            this.cboCustom.Size = new System.Drawing.Size(357, 23);
            this.cboCustom.TabIndex = 7;
            this.cboCustom.ValueSeparator = ", ";
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(682, 153);
            this.btnCustom.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(144, 52);
            this.btnCustom.TabIndex = 19;
            this.btnCustom.Text = "Install Customizations";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnInstallCustom_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 113);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "Acumatica User";
            // 
            // txtACUser
            // 
            this.txtACUser.Location = new System.Drawing.Point(180, 110);
            this.txtACUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtACUser.Name = "txtACUser";
            this.txtACUser.Size = new System.Drawing.Size(357, 22);
            this.txtACUser.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 145);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "Acumatica Pass";
            // 
            // txtACPass
            // 
            this.txtACPass.Location = new System.Drawing.Point(180, 142);
            this.txtACPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtACPass.Name = "txtACPass";
            this.txtACPass.Size = new System.Drawing.Size(357, 22);
            this.txtACPass.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 310);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnOFDSnaphot);
            this.tabPage1.Controls.Add(this.txtSnapshot);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.chkPreview);
            this.tabPage1.Controls.Add(this.cboVersion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboPatch);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(652, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Select Version";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Location = new System.Drawing.Point(23, 51);
            this.chkPreview.Margin = new System.Windows.Forms.Padding(4);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(128, 21);
            this.chkPreview.TabIndex = 2;
            this.chkPreview.Text = "Include Preview";
            this.chkPreview.UseVisualStyleBackColor = true;
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtInstance);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtACUser);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cboCustom);
            this.tabPage2.Controls.Add(this.txtACPass);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.chkPortal);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(652, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Instance Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picStatus);
            this.tabPage3.Controls.Add(this.txtDBServer);
            this.tabPage3.Controls.Add(this.txtDBName);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtDBPass);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtDBUser);
            this.tabPage3.Controls.Add(this.chkDemoData);
            this.tabPage3.Controls.Add(this.chkNewDB);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(652, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Database Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // picStatus
            // 
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(501, 20);
            this.picStatus.Margin = new System.Windows.Forms.Padding(4);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(29, 27);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatus.TabIndex = 27;
            this.picStatus.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.OptionPanel);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(652, 281);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dev Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(682, 212);
            this.btnUpdateUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(144, 52);
            this.btnUpdateUser.TabIndex = 20;
            this.btnUpdateUser.Text = "Create/Update Acumatica User";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.BtnUpdateUser_Click);
            // 
            // btnSaveWebConfig
            // 
            this.btnSaveWebConfig.Location = new System.Drawing.Point(682, 272);
            this.btnSaveWebConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveWebConfig.Name = "btnSaveWebConfig";
            this.btnSaveWebConfig.Size = new System.Drawing.Size(144, 52);
            this.btnSaveWebConfig.TabIndex = 23;
            this.btnSaveWebConfig.Text = "Save Dev Ops to Web.Config";
            this.btnSaveWebConfig.UseVisualStyleBackColor = true;
            this.btnSaveWebConfig.Click += new System.EventHandler(this.btnSaveWebConfig_Click);
            // 
            // OptionPanel
            // 
            this.OptionPanel.AutoScroll = true;
            this.OptionPanel.AutoSize = true;
            this.OptionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionPanel.ColumnCount = 2;
            this.OptionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.80495F));
            this.OptionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.19505F));
            this.OptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionPanel.Location = new System.Drawing.Point(3, 3);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.RowCount = 1;
            this.OptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.OptionPanel.Size = new System.Drawing.Size(646, 275);
            this.OptionPanel.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Snapshot File (optional)";
            // 
            // txtSnapshot
            // 
            this.txtSnapshot.Location = new System.Drawing.Point(180, 17);
            this.txtSnapshot.Name = "txtSnapshot";
            this.txtSnapshot.Size = new System.Drawing.Size(357, 22);
            this.txtSnapshot.TabIndex = 8;
            this.txtSnapshot.TextChanged += new System.EventHandler(this.txtSnapshot_TextChanged);
            // 
            // btnOFDSnaphot
            // 
            this.btnOFDSnaphot.Location = new System.Drawing.Point(544, 14);
            this.btnOFDSnaphot.Margin = new System.Windows.Forms.Padding(4);
            this.btnOFDSnaphot.Name = "btnOFDSnaphot";
            this.btnOFDSnaphot.Size = new System.Drawing.Size(37, 28);
            this.btnOFDSnaphot.TabIndex = 9;
            this.btnOFDSnaphot.Text = "...";
            this.btnOFDSnaphot.UseVisualStyleBackColor = true;
            this.btnOFDSnaphot.Click += new System.EventHandler(this.btnOFDSnaphot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 558);
            this.Controls.Add(this.btnSaveWebConfig);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnGetNewVersions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmDeploy";
            this.Text = "Acumatica Deployer";
            this.Load += new System.EventHandler(this.FrmDeploy_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetNewVersions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVersion;
        private System.Windows.Forms.ComboBox cboPatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNewDB;
        private System.Windows.Forms.CheckBox chkDemoData;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.CheckBox chkPortal;
        private System.Windows.Forms.Button btnSettings;
        public System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox txtInstance;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDBPass;
        private System.Windows.Forms.Label label8;
        private CheckComboBoxTest.CheckedComboBox cboCustom;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtACUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtACPass;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSaveWebConfig;
        private System.Windows.Forms.TableLayoutPanel OptionPanel;
        private System.Windows.Forms.TextBox txtSnapshot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOFDSnaphot;
        private System.Windows.Forms.Button button1;
    }
}