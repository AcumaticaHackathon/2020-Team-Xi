namespace AcumaticaDeployer
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAcumaticaURL = new System.Windows.Forms.TextBox();
            this.txtInstallPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOFDInstalls = new System.Windows.Forms.Button();
            this.btnOFDRoot = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCustPath = new System.Windows.Forms.Button();
            this.txtCustomizationPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtACPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtACUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acumatica S3 URL";
            // 
            // txtAcumaticaURL
            // 
            this.txtAcumaticaURL.Location = new System.Drawing.Point(240, 18);
            this.txtAcumaticaURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAcumaticaURL.Name = "txtAcumaticaURL";
            this.txtAcumaticaURL.Size = new System.Drawing.Size(307, 22);
            this.txtAcumaticaURL.TabIndex = 1;
            this.txtAcumaticaURL.TextChanged += new System.EventHandler(this.TxtAcumaticaURL_TextChanged);
            // 
            // txtInstallPath
            // 
            this.txtInstallPath.Location = new System.Drawing.Point(240, 50);
            this.txtInstallPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.Size = new System.Drawing.Size(307, 22);
            this.txtInstallPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path to Acumatica Installs";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(240, 82);
            this.txtRootPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(307, 22);
            this.txtRootPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path to Acumatica Web Root";
            // 
            // btnOFDInstalls
            // 
            this.btnOFDInstalls.Location = new System.Drawing.Point(551, 48);
            this.btnOFDInstalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOFDInstalls.Name = "btnOFDInstalls";
            this.btnOFDInstalls.Size = new System.Drawing.Size(37, 28);
            this.btnOFDInstalls.TabIndex = 6;
            this.btnOFDInstalls.Text = "...";
            this.btnOFDInstalls.UseVisualStyleBackColor = true;
            this.btnOFDInstalls.Click += new System.EventHandler(this.BtnOFDInstalls_Click);
            // 
            // btnOFDRoot
            // 
            this.btnOFDRoot.Location = new System.Drawing.Point(551, 80);
            this.btnOFDRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOFDRoot.Name = "btnOFDRoot";
            this.btnOFDRoot.Size = new System.Drawing.Size(37, 28);
            this.btnOFDRoot.TabIndex = 7;
            this.btnOFDRoot.Text = "...";
            this.btnOFDRoot.UseVisualStyleBackColor = true;
            this.btnOFDRoot.Click += new System.EventHandler(this.BtnOFDRoot_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(487, 318);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(379, 318);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // picStatus
            // 
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(553, 17);
            this.picStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(29, 27);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatus.TabIndex = 8;
            this.picStatus.TabStop = false;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(240, 178);
            this.txtDBPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Size = new System.Drawing.Size(307, 22);
            this.txtDBPassword.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Default DB Password";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(240, 146);
            this.txtDBUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(307, 22);
            this.txtDBUser.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Default DB User";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(240, 114);
            this.txtDBServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(307, 22);
            this.txtDBServer.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Default DB Server";
            // 
            // btnCustPath
            // 
            this.btnCustPath.Location = new System.Drawing.Point(551, 208);
            this.btnCustPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustPath.Name = "btnCustPath";
            this.btnCustPath.Size = new System.Drawing.Size(37, 28);
            this.btnCustPath.TabIndex = 19;
            this.btnCustPath.Text = "...";
            this.btnCustPath.UseVisualStyleBackColor = true;
            this.btnCustPath.Click += new System.EventHandler(this.btnCustPath_Click);
            // 
            // txtCustomizationPath
            // 
            this.txtCustomizationPath.Location = new System.Drawing.Point(240, 210);
            this.txtCustomizationPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomizationPath.Name = "txtCustomizationPath";
            this.txtCustomizationPath.Size = new System.Drawing.Size(307, 22);
            this.txtCustomizationPath.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Path to Customizations";
            // 
            // txtACPass
            // 
            this.txtACPass.Location = new System.Drawing.Point(240, 276);
            this.txtACPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtACPass.Name = "txtACPass";
            this.txtACPass.Size = new System.Drawing.Size(307, 22);
            this.txtACPass.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Default DB Password";
            // 
            // txtACUser
            // 
            this.txtACUser.Location = new System.Drawing.Point(240, 244);
            this.txtACUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtACUser.Name = "txtACUser";
            this.txtACUser.Size = new System.Drawing.Size(307, 22);
            this.txtACUser.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 242);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Default DB User";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 370);
            this.Controls.Add(this.txtACPass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtACUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCustPath);
            this.Controls.Add(this.txtCustomizationPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDBPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDBUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDBServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.btnOFDRoot);
            this.Controls.Add(this.btnOFDInstalls);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInstallPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAcumaticaURL);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(621, 409);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAcumaticaURL;
        private System.Windows.Forms.TextBox txtInstallPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOFDInstalls;
        private System.Windows.Forms.Button btnOFDRoot;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCustPath;
        private System.Windows.Forms.TextBox txtCustomizationPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtACPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtACUser;
        private System.Windows.Forms.Label label9;
    }
}