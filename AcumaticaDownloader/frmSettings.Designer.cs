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
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acumatica S3 URL";
            // 
            // txtAcumaticaURL
            // 
            this.txtAcumaticaURL.Location = new System.Drawing.Point(159, 15);
            this.txtAcumaticaURL.Name = "txtAcumaticaURL";
            this.txtAcumaticaURL.Size = new System.Drawing.Size(231, 20);
            this.txtAcumaticaURL.TabIndex = 1;
            this.txtAcumaticaURL.TextChanged += new System.EventHandler(this.TxtAcumaticaURL_TextChanged);
            // 
            // txtInstallPath
            // 
            this.txtInstallPath.Location = new System.Drawing.Point(159, 41);
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.Size = new System.Drawing.Size(231, 20);
            this.txtInstallPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path to Acumatica Installs";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(159, 67);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(231, 20);
            this.txtRootPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path to Acumatica Web Root";
            // 
            // btnOFDInstalls
            // 
            this.btnOFDInstalls.Location = new System.Drawing.Point(392, 39);
            this.btnOFDInstalls.Name = "btnOFDInstalls";
            this.btnOFDInstalls.Size = new System.Drawing.Size(28, 23);
            this.btnOFDInstalls.TabIndex = 6;
            this.btnOFDInstalls.Text = "...";
            this.btnOFDInstalls.UseVisualStyleBackColor = true;
            this.btnOFDInstalls.Click += new System.EventHandler(this.BtnOFDInstalls_Click);
            // 
            // btnOFDRoot
            // 
            this.btnOFDRoot.Location = new System.Drawing.Point(392, 65);
            this.btnOFDRoot.Name = "btnOFDRoot";
            this.btnOFDRoot.Size = new System.Drawing.Size(28, 23);
            this.btnOFDRoot.TabIndex = 7;
            this.btnOFDRoot.Text = "...";
            this.btnOFDRoot.UseVisualStyleBackColor = true;
            this.btnOFDRoot.Click += new System.EventHandler(this.BtnOFDRoot_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(264, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // picStatus
            // 
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(394, 14);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(22, 22);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatus.TabIndex = 8;
            this.picStatus.TabStop = false;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 136);
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
            this.Name = "frmSettings";
            this.Text = "Settings";
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
    }
}