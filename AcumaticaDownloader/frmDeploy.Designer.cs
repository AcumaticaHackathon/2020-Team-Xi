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
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDBPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetNewVersions
            // 
            this.btnGetNewVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetNewVersions.Location = new System.Drawing.Point(372, 487);
            this.btnGetNewVersions.Name = "btnGetNewVersions";
            this.btnGetNewVersions.Size = new System.Drawing.Size(113, 23);
            this.btnGetNewVersions.TabIndex = 0;
            this.btnGetNewVersions.Text = "Bulk Downloads";
            this.btnGetNewVersions.UseVisualStyleBackColor = true;
            this.btnGetNewVersions.Click += new System.EventHandler(this.BtnGetNewVersions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Major Version";
            // 
            // cboVersion
            // 
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(97, 16);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(269, 21);
            this.cboVersion.TabIndex = 2;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            this.cboVersion.TextUpdate += new System.EventHandler(this.cboVersion_TextUpdate);
            // 
            // cboPatch
            // 
            this.cboPatch.DisplayMember = "Label";
            this.cboPatch.FormattingEnabled = true;
            this.cboPatch.Location = new System.Drawing.Point(97, 43);
            this.cboPatch.Name = "cboPatch";
            this.cboPatch.Size = new System.Drawing.Size(269, 21);
            this.cboPatch.TabIndex = 4;
            this.cboPatch.ValueMember = "AppVersion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patch Level";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(97, 121);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(269, 20);
            this.txtDBName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DB Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instance Name";
            // 
            // chkNewDB
            // 
            this.chkNewDB.AutoSize = true;
            this.chkNewDB.Location = new System.Drawing.Point(97, 199);
            this.chkNewDB.Name = "chkNewDB";
            this.chkNewDB.Size = new System.Drawing.Size(66, 17);
            this.chkNewDB.TabIndex = 9;
            this.chkNewDB.Text = "New DB";
            this.chkNewDB.UseVisualStyleBackColor = true;
            // 
            // chkDemoData
            // 
            this.chkDemoData.AutoSize = true;
            this.chkDemoData.Location = new System.Drawing.Point(182, 199);
            this.chkDemoData.Name = "chkDemoData";
            this.chkDemoData.Size = new System.Drawing.Size(80, 17);
            this.chkDemoData.TabIndex = 10;
            this.chkDemoData.Text = "Demo Data";
            this.chkDemoData.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(405, 36);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 11;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Enabled = false;
            this.btnUpgrade.Location = new System.Drawing.Point(405, 66);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnUpgrade.TabIndex = 12;
            this.btnUpgrade.Text = "Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.BtnUpgrade_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 516);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(492, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // rtbLogs
            // 
            this.rtbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogs.Location = new System.Drawing.Point(12, 222);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(473, 259);
            this.rtbLogs.TabIndex = 14;
            this.rtbLogs.Text = "";
            // 
            // chkPortal
            // 
            this.chkPortal.AutoSize = true;
            this.chkPortal.Location = new System.Drawing.Point(15, 199);
            this.chkPortal.Name = "chkPortal";
            this.chkPortal.Size = new System.Drawing.Size(53, 17);
            this.chkPortal.TabIndex = 15;
            this.chkPortal.Text = "Portal";
            this.chkPortal.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(405, 95);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(148, 333);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 17;
            // 
            // txtInstance
            // 
            this.txtInstance.FormattingEnabled = true;
            this.txtInstance.Location = new System.Drawing.Point(97, 70);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(269, 21);
            this.txtInstance.TabIndex = 18;
            this.txtInstance.SelectedIndexChanged += new System.EventHandler(this.txtInstance_SelectedIndexChanged);
            this.txtInstance.TextChanged += new System.EventHandler(this.txtInstance_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(253, 487);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh Cache";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Location = new System.Drawing.Point(372, 18);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(102, 17);
            this.chkPreview.TabIndex = 20;
            this.chkPreview.Text = "Include Preview";
            this.chkPreview.UseVisualStyleBackColor = true;
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "DB Server";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(97, 95);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(269, 20);
            this.txtDBServer.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "DB User";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(97, 147);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(269, 20);
            this.txtDBUser.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "DB Pass";
            // 
            // txtDBPass
            // 
            this.txtDBPass.Location = new System.Drawing.Point(97, 173);
            this.txtDBPass.Name = "txtDBPass";
            this.txtDBPass.Size = new System.Drawing.Size(269, 20);
            this.txtDBPass.TabIndex = 23;
            // 
            // frmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 539);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDBUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDBPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDBServer);
            this.Controls.Add(this.chkPreview);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtInstance);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.chkPortal);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.chkDemoData);
            this.Controls.Add(this.chkNewDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.cboPatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetNewVersions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmDeploy";
            this.Text = "Acumatica Deployer";
            this.Load += new System.EventHandler(this.FrmDeploy_Load);
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
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDBPass;
    }
}