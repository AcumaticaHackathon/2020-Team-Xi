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
            this.btnCustom = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtACUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtACPass = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOFDSnaphot = new System.Windows.Forms.Button();
            this.txtSnapshot = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboCustom = new CheckComboBox.CheckedComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.OptionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveWebConfig = new System.Windows.Forms.Button();
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
            this.btnGetNewVersions.Location = new System.Drawing.Point(512, 401);
            this.btnGetNewVersions.Name = "btnGetNewVersions";
            this.btnGetNewVersions.Size = new System.Drawing.Size(113, 23);
            this.btnGetNewVersions.TabIndex = 22;
            this.btnGetNewVersions.Text = "Bulk Downloads";
            this.btnGetNewVersions.UseVisualStyleBackColor = true;
            this.btnGetNewVersions.Click += new System.EventHandler(this.BtnGetNewVersions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Major Version";
            // 
            // cboVersion
            // 
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(135, 55);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(269, 21);
            this.cboVersion.TabIndex = 3;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            this.cboVersion.TextUpdate += new System.EventHandler(this.cboVersion_TextUpdate);
            // 
            // cboPatch
            // 
            this.cboPatch.DisplayMember = "Label";
            this.cboPatch.FormattingEnabled = true;
            this.cboPatch.Location = new System.Drawing.Point(135, 82);
            this.cboPatch.Name = "cboPatch";
            this.cboPatch.Size = new System.Drawing.Size(269, 21);
            this.cboPatch.TabIndex = 4;
            this.cboPatch.ValueMember = "AppVersion";
            this.cboPatch.SelectedIndexChanged += new System.EventHandler(this.cboPatch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patch Level";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(135, 32);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(229, 20);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.TextChanged += new System.EventHandler(this.txtDBName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DB Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instance Name";
            // 
            // chkNewDB
            // 
            this.chkNewDB.AutoSize = true;
            this.chkNewDB.Location = new System.Drawing.Point(135, 110);
            this.chkNewDB.Name = "chkNewDB";
            this.chkNewDB.Size = new System.Drawing.Size(66, 17);
            this.chkNewDB.TabIndex = 14;
            this.chkNewDB.Text = "New DB";
            this.chkNewDB.UseVisualStyleBackColor = true;
            // 
            // chkDemoData
            // 
            this.chkDemoData.AutoSize = true;
            this.chkDemoData.Location = new System.Drawing.Point(219, 110);
            this.chkDemoData.Name = "chkDemoData";
            this.chkDemoData.Size = new System.Drawing.Size(80, 17);
            this.chkDemoData.TabIndex = 15;
            this.chkDemoData.Text = "Demo Data";
            this.chkDemoData.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(512, 34);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(108, 23);
            this.btnInstall.TabIndex = 16;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Enabled = false;
            this.btnUpgrade.Location = new System.Drawing.Point(512, 64);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(108, 23);
            this.btnUpgrade.TabIndex = 17;
            this.btnUpgrade.Text = "Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.BtnUpgrade_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 433);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(633, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // rtbLogs
            // 
            this.rtbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogs.Location = new System.Drawing.Point(12, 270);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(612, 125);
            this.rtbLogs.TabIndex = 14;
            this.rtbLogs.Text = "";
            // 
            // chkPortal
            // 
            this.chkPortal.AutoSize = true;
            this.chkPortal.Location = new System.Drawing.Point(409, 9);
            this.chkPortal.Name = "chkPortal";
            this.chkPortal.Size = new System.Drawing.Size(53, 17);
            this.chkPortal.TabIndex = 5;
            this.chkPortal.Text = "Portal";
            this.chkPortal.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(512, 93);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(108, 23);
            this.btnSettings.TabIndex = 18;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(148, 433);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 17;
            // 
            // txtInstance
            // 
            this.txtInstance.FormattingEnabled = true;
            this.txtInstance.Location = new System.Drawing.Point(135, 6);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(269, 21);
            this.txtInstance.TabIndex = 6;
            this.txtInstance.SelectedIndexChanged += new System.EventHandler(this.txtInstance_SelectedIndexChanged);
            this.txtInstance.TextChanged += new System.EventHandler(this.txtInstance_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(392, 401);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh Cache";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "DB Server";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(135, 6);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(229, 20);
            this.txtDBServer.TabIndex = 10;
            this.txtDBServer.TextChanged += new System.EventHandler(this.txtDBServer_TextChangedAsync);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "DB User";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(135, 58);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(229, 20);
            this.txtDBUser.TabIndex = 12;
            this.txtDBUser.TextChanged += new System.EventHandler(this.txtDBUser_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "DB Pass";
            // 
            // txtDBPass
            // 
            this.txtDBPass.Location = new System.Drawing.Point(135, 84);
            this.txtDBPass.Name = "txtDBPass";
            this.txtDBPass.Size = new System.Drawing.Size(229, 20);
            this.txtDBPass.TabIndex = 13;
            this.txtDBPass.TextChanged += new System.EventHandler(this.txtDBPass_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Customizations";
            // 
            // btnCustom
            // 
            this.btnCustom.Enabled = false;
            this.btnCustom.Location = new System.Drawing.Point(512, 124);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(108, 42);
            this.btnCustom.TabIndex = 19;
            this.btnCustom.Text = "Install Customizations";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnInstallCustom_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Acumatica User";
            // 
            // txtACUser
            // 
            this.txtACUser.Location = new System.Drawing.Point(135, 61);
            this.txtACUser.Name = "txtACUser";
            this.txtACUser.Size = new System.Drawing.Size(269, 20);
            this.txtACUser.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Acumatica Pass";
            // 
            // txtACPass
            // 
            this.txtACPass.Location = new System.Drawing.Point(135, 87);
            this.txtACPass.Name = "txtACPass";
            this.txtACPass.Size = new System.Drawing.Size(269, 20);
            this.txtACPass.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 252);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOFDSnaphot);
            this.tabPage1.Controls.Add(this.txtSnapshot);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.chkPreview);
            this.tabPage1.Controls.Add(this.cboVersion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboPatch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Select Version";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOFDSnaphot
            // 
            this.btnOFDSnaphot.Location = new System.Drawing.Point(408, 3);
            this.btnOFDSnaphot.Name = "btnOFDSnaphot";
            this.btnOFDSnaphot.Size = new System.Drawing.Size(28, 23);
            this.btnOFDSnaphot.TabIndex = 9;
            this.btnOFDSnaphot.Text = "...";
            this.btnOFDSnaphot.UseVisualStyleBackColor = true;
            this.btnOFDSnaphot.Click += new System.EventHandler(this.btnOFDSnaphot_Click);
            // 
            // txtSnapshot
            // 
            this.txtSnapshot.Location = new System.Drawing.Point(135, 6);
            this.txtSnapshot.Margin = new System.Windows.Forms.Padding(2);
            this.txtSnapshot.Name = "txtSnapshot";
            this.txtSnapshot.Size = new System.Drawing.Size(269, 20);
            this.txtSnapshot.TabIndex = 8;
            this.txtSnapshot.TextChanged += new System.EventHandler(this.txtSnapshot_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Snapshot File (optional)";
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Location = new System.Drawing.Point(17, 33);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(102, 17);
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
            this.tabPage2.Controls.Add(this.txtACPass);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.chkPortal);
            this.tabPage2.Controls.Add(this.cboCustom);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 226);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Instance Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboCustom
            // 
            this.cboCustom.CheckOnClick = true;
            this.cboCustom.DisplayMember = "Name";
            this.cboCustom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCustom.DropDownHeight = 1;
            this.cboCustom.FormattingEnabled = true;
            this.cboCustom.IntegralHeight = false;
            this.cboCustom.Location = new System.Drawing.Point(135, 33);
            this.cboCustom.Name = "cboCustom";
            this.cboCustom.Size = new System.Drawing.Size(269, 21);
            this.cboCustom.TabIndex = 7;
            this.cboCustom.ValueSeparator = ", ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkIntegratedSecurity);
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(487, 226);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Database Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(369, 60);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.chkIntegratedSecurity.TabIndex = 28;
            this.chkIntegratedSecurity.Text = "Integrated Security";
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChangedAsync);
            // 
            // picStatus
            // 
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(370, 6);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(22, 22);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatus.TabIndex = 27;
            this.picStatus.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.OptionPanel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(487, 226);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dev Options";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.OptionPanel.Location = new System.Drawing.Point(2, 2);
            this.OptionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.RowCount = 1;
            this.OptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.OptionPanel.Size = new System.Drawing.Size(483, 222);
            this.OptionPanel.TabIndex = 0;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Enabled = false;
            this.btnUpdateUser.Location = new System.Drawing.Point(512, 172);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(108, 42);
            this.btnUpdateUser.TabIndex = 20;
            this.btnUpdateUser.Text = "Create/Update Acumatica User";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.BtnUpdateUser_Click);
            // 
            // btnSaveWebConfig
            // 
            this.btnSaveWebConfig.Enabled = false;
            this.btnSaveWebConfig.Location = new System.Drawing.Point(512, 221);
            this.btnSaveWebConfig.Name = "btnSaveWebConfig";
            this.btnSaveWebConfig.Size = new System.Drawing.Size(108, 42);
            this.btnSaveWebConfig.TabIndex = 23;
            this.btnSaveWebConfig.Text = "Save Dev Ops to Web.Config";
            this.btnSaveWebConfig.UseVisualStyleBackColor = true;
            this.btnSaveWebConfig.Click += new System.EventHandler(this.btnSaveWebConfig_Click);
            // 
            // frmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 456);
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
            this.MinimumSize = new System.Drawing.Size(649, 495);
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
        private CheckComboBox.CheckedComboBox cboCustom;
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
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
    }
}