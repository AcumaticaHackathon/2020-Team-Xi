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
        private Settings settings;
        public frmSettings()
        {
            InitializeComponent();
            settings = new Settings();
            txtAcumaticaURL.Text = settings.AcumaticaS3Url;
            txtInstallPath.Text = settings.PathToInstalls;
            txtRootPath.Text = settings.PathToAcumatica;
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
            settings.AcumaticaS3Url = txtAcumaticaURL.Text;
            settings.PathToInstalls = txtInstallPath.Text;
            settings.PathToAcumatica = txtRootPath.Text + (txtRootPath.Text.EndsWith("\\")?"":"\\");
            settings.SaveSettings();
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
