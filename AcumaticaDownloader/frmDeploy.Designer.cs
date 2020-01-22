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
            this.txtInstance = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // btnGetNewVersions
            // 
            this.btnGetNewVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetNewVersions.Location = new System.Drawing.Point(229, 299);
            this.btnGetNewVersions.Name = "btnGetNewVersions";
            this.btnGetNewVersions.Size = new System.Drawing.Size(113, 23);
            this.btnGetNewVersions.TabIndex = 0;
            this.btnGetNewVersions.Text = "Get New Versions";
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
            this.cboVersion.Size = new System.Drawing.Size(121, 21);
            this.cboVersion.TabIndex = 2;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            this.cboVersion.TextUpdate += new System.EventHandler(this.cboVersion_TextUpdate);
            // 
            // cboPatch
            // 
            this.cboPatch.FormattingEnabled = true;
            this.cboPatch.Location = new System.Drawing.Point(97, 43);
            this.cboPatch.Name = "cboPatch";
            this.cboPatch.Size = new System.Drawing.Size(121, 21);
            this.cboPatch.TabIndex = 4;
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
            // txtInstance
            // 
            this.txtInstance.Location = new System.Drawing.Point(97, 70);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(121, 20);
            this.txtInstance.TabIndex = 5;
            this.txtInstance.TextChanged += new System.EventHandler(this.txtInstance_TextChanged);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(97, 96);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(121, 20);
            this.txtDBName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
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
            this.chkNewDB.Location = new System.Drawing.Point(97, 122);
            this.chkNewDB.Name = "chkNewDB";
            this.chkNewDB.Size = new System.Drawing.Size(66, 17);
            this.chkNewDB.TabIndex = 9;
            this.chkNewDB.Text = "New DB";
            this.chkNewDB.UseVisualStyleBackColor = true;
            // 
            // chkDemoData
            // 
            this.chkDemoData.AutoSize = true;
            this.chkDemoData.Location = new System.Drawing.Point(182, 122);
            this.chkDemoData.Name = "chkDemoData";
            this.chkDemoData.Size = new System.Drawing.Size(80, 17);
            this.chkDemoData.TabIndex = 10;
            this.chkDemoData.Text = "Demo Data";
            this.chkDemoData.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(265, 16);
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
            this.btnUpgrade.Location = new System.Drawing.Point(265, 46);
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
            this.progressBar1.Location = new System.Drawing.Point(0, 328);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // rtbLogs
            // 
            this.rtbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogs.Location = new System.Drawing.Point(12, 145);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(330, 148);
            this.rtbLogs.TabIndex = 14;
            this.rtbLogs.Text = "";
            // 
            // chkPortal
            // 
            this.chkPortal.AutoSize = true;
            this.chkPortal.Location = new System.Drawing.Point(15, 122);
            this.chkPortal.Name = "chkPortal";
            this.chkPortal.Size = new System.Drawing.Size(53, 17);
            this.chkPortal.TabIndex = 15;
            this.chkPortal.Text = "Portal";
            this.chkPortal.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(265, 75);
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
            // frmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 351);
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
            this.Controls.Add(this.txtInstance);
            this.Controls.Add(this.cboPatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetNewVersions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(365, 390);
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
        private System.Windows.Forms.TextBox txtInstance;
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
    }
}