using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmDeploy : Form
    {
        private Settings settings;
        public frmDeploy()
        {
            InitializeComponent();
            settings = new Settings();
        }

        private void FrmDeploy_Load(object sender, EventArgs e)
        {
            try
            {
                cboVersion.Items.AddRange(System.IO.Directory.GetDirectories(settings.PathToInstalls).Select(s => s.Replace(settings.PathToInstalls, "")).Where(d => d.StartsWith("20")).ToArray<object>());
            }
            catch { }
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPatch.Items.Clear();
            if(cboVersion.SelectedIndex>=0 && !string.IsNullOrWhiteSpace(cboVersion.Text))
                cboPatch.Items.AddRange(System.IO.Directory.GetDirectories(settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString()).Select(s => s.Replace(settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString() + @"\", "")).ToArray<object>());
        }
        private string SourcePath
        {
            get
            {
                return InstallPath + cboVersion.SelectedItem.ToString() + @"\" + cboPatch.SelectedItem.ToString() + @"\Acumatica ERP";
            }
        }
        private string InstallPath
        {
            get
            {
                return settings.PathToInstalls + (settings.PathToInstalls.EndsWith("\\") ? "" : "\\");
            }
        }
        private string ErpPath
        {
            get
            {
                return string.Format("{0}{1}", settings.PathToAcumatica, txtInstance.Text);
            }
        }

        private void txtInstance_TextChanged(object sender, EventArgs e)
        {
            if(System.IO.Directory.Exists(ErpPath) && System.IO.Directory.Exists(ErpPath + "\\site"))
            {
                chkDemoData.Enabled = false;
                chkNewDB.Enabled = false;
                chkDemoData.Checked = false;
                chkNewDB.Checked = false;
                btnInstall.Enabled = false;
                btnUpgrade.Enabled = true;
            }
            else
            {
                chkDemoData.Enabled = true;
                chkNewDB.Enabled = true;
                btnInstall.Enabled = true ;
                btnUpgrade.Enabled = false ;

                //chkDemoData.Checked = false;
                //chkNewDB.Checked = true;

            }
        }
        private string AppPath()
        {
            return Application.StartupPath;
        }
        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(ErpPath))
                Directory.CreateDirectory(ErpPath );
            if (!Directory.Exists(ErpPath + @"\Scripts"))
                Directory.CreateDirectory(ErpPath  + @"\Scripts");
            if (!Directory.Exists(ErpPath + @"\Scripts\Setup"))
                Directory.CreateDirectory(ErpPath  + @"\Scripts\Setup");
            var data = File.ReadAllText(AppPath() + @"\Scripts\CreateNewSite.ps1");
            data=data.Replace("{Acumatica Source Directory}", SourcePath);
            File.WriteAllBytes(ErpPath  + @"\Scripts\Setup\CreateNewSite.ps1", System.Text.Encoding.UTF8.GetBytes(data));
            data = "InstanceName=" + txtInstance.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\nIsPortal=" + chkPortal.Checked.ToString() + "\r\n";
            File.WriteAllBytes(ErpPath  + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            data=RunScript(ErpPath + @"\Scripts\Setup\CreateNewSite.ps1", cboPatch.SelectedItem.ToString());
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\InstallLog.txt", System.Text.Encoding.UTF8.GetBytes(data));
            MessageBox.Show("Install Done", "Install Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string OutputLog = "";
        private string RunScript(string ps1File, string version)
        {
            OutputLog = "";
            //var ps1File = settings.PathToInstalls + @"ProcessAcumaticaInstaller.ps1";
            string retVal;
            var startInfo = new ProcessStartInfo()
            {
                FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe",
                Arguments = $" -ExecutionPolicy unrestricted -file \"{ps1File}\" {version}",
                UseShellExecute = false,
                Verb = "runas",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            
            Process results = new Process();
            results.StartInfo = startInfo;
            results.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            results.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            results.Start();
            results.BeginOutputReadLine();
            results.BeginErrorReadLine();
            while (!results.HasExited)
                Application.DoEvents();
            //string output = results.StandardOutput.ReadToEnd();
            //Debug.Print(output);
            
            // catch error information

            //string errors = results.StandardError.ReadToEnd();
            //Debug.Print(errors);
            retVal = OutputLog;
            return retVal;
        }
        private int GetProgress(string data)
        {
            var parse = data.Split(':');
            if(parse[parse.Length-1].Contains("%"))
            {
                var value= (int)decimal.Parse(parse[parse.Length-1].Split('%')[0]);
                return value > 100 ? 100 : value;
            }
            return 0;
        }
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string line;
            if (outLine != null && outLine.Data != null)
            {
                line = (outLine.Data.ToString().Replace("\0",string.Empty));
                Debug.WriteLine(line);
                OutputLog += line + "\r\n";
                var progress = GetProgress(line);
                if(progress>0)
                    progressBar1.Invoke(new Action(() => progressBar1.Value = progress));
                rtbLogs.Invoke(new Action(() => rtbLogs.AppendText(line + "\r\n")));
                rtbLogs.Invoke(new Action(() => rtbLogs.ScrollToCaret()));
            }
        }
        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ErpPath))
                Directory.CreateDirectory(ErpPath);
            if (!Directory.Exists(ErpPath + @"\Scripts"))
                Directory.CreateDirectory(ErpPath + @"\Scripts");
            if (!Directory.Exists(ErpPath + @"\Scripts\Setup"))
                Directory.CreateDirectory(ErpPath + @"\Scripts\Setup");
            var data = File.ReadAllText(AppPath() + @"\Scripts\UpgradeSite.ps1");
            data = data.Replace("{Acumatica Source Directory}", SourcePath);
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\UpgradeSite.ps1", System.Text.Encoding.UTF8.GetBytes(data));
            data = "InstanceName=" + txtInstance.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\n";
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            data=RunScript(ErpPath + @"\Scripts\Setup\UpgradeSite.ps1", cboPatch.SelectedItem.ToString());
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\UpgradeLog.txt", System.Text.Encoding.UTF8.GetBytes(data));
            MessageBox.Show("Upgrade Done", "Install Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGetNewVersions_Click(object sender, EventArgs e)
        {
            var frm = new frmDownloadVersion();
            frm.FrmDeploy = this;
            frm.ShowDialog();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //ConfigurationManager.RefreshSection("applicationSettings");
                settings = new Settings();
                FrmDeploy_Load(this, new EventArgs());
            }
        }

        private void cboVersion_TextUpdate(object sender, EventArgs e)
        {
            cboVersion_SelectedIndexChanged(sender, e);
        }
    }
}
