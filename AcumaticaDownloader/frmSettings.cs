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
            txtDBUser.Text = Settings.DefaultDBUser;
            txtDBServer.Text=Settings.DefaultDBServer  ;
            txtDBPassword.Text=Settings.DefaultDBPassword ;
            txtCustomizationPath.Text=Settings.CustomizationPath ;
            txtACUser.Text=Settings.DefaultAcumaticaAdmin;
            txtACPass.Text=Settings.DefaultAcumaticaPassword ;
        }

        private void TxtAcumaticaURL_TextChanged(object sender, EventArgs e)
        {
            Utils.GetResults(txtAcumaticaURL.Text);
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
            Settings.CustomizationPath = txtCustomizationPath.Text;
            Settings.DefaultAcumaticaAdmin = txtACUser.Text;
            Settings.DefaultAcumaticaPassword = txtACPass.Text;
            Settings.SaveSettings();
            this.Close();
        }

        private void BtnOFDInstalls_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog
            {
                SelectedPath = txtInstallPath.Text,
                Description = "Select path for Install Media"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtInstallPath.Text = ofd.SelectedPath;
        }

        private void BtnOFDRoot_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog
            {
                SelectedPath = txtRootPath.Text,
                Description = "Select path to Acumatica Root folder"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtRootPath.Text = ofd.SelectedPath;
        }

        private void btnCustPath_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog
            {
                SelectedPath = txtCustomizationPath.Text,
                Description = "Select path to Acumatica Customization folder"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtCustomizationPath.Text = ofd.SelectedPath;

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
