using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmSettings : Form
    {
        //private Settings Settings;
        public frmSettings()
        {
            InitializeComponent();
            //Settings = new Settings();
            txtAcumaticaURL.Text = Settings.AcumaticaS3Url;
            txtInstallPath.Text = Settings.PathToInstalls;
            txtRootPath.Text = Settings.PathToAcumatica;
        }

        private void TxtAcumaticaURL_TextChanged(object sender, EventArgs e)
        {
            var test = Utils.GetResults(txtAcumaticaURL.Text);
            if (Utils.HasError)
                picStatus.Image = Properties.Resources.Err;
            else
                picStatus.Image = Properties.Resources.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Settings.AcumaticaS3Url = txtAcumaticaURL.Text;
            Settings.PathToInstalls = txtInstallPath.Text + (txtInstallPath.Text.EndsWith("\\") ? "" : "\\");
            Settings.PathToAcumatica = txtRootPath.Text + (txtRootPath.Text.EndsWith("\\")?"":"\\");
            Settings.DefaultDBUser = txtDBUser.Text;
            Settings.DefaultDBServer = txtDBServer.Text;
            Settings.DefaultDBPassword = txtDBPassword.Text;
            Settings.SaveSettings();
            this.Close();
        }

        private void BtnOFDInstalls_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog();
            ofd.SelectedPath = txtInstallPath.Text;
            ofd.Description = "Select path for Install Media";
            if (ofd.ShowDialog() == DialogResult.OK)
                txtInstallPath.Text = ofd.SelectedPath;
        }

        private void BtnOFDRoot_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog();
            ofd.SelectedPath = txtRootPath.Text;
            ofd.Description = "Select path to Acumatica Root folder";
            if (ofd.ShowDialog() == DialogResult.OK)
                txtRootPath.Text = ofd.SelectedPath;
        }
    }
}
