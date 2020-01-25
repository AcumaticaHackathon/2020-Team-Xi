using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmDeploy : Form
    {
        //private Settings Settings;
        private DownloadItemList Items{ get { return Utils.Items; } }
        public frmDeploy()
        {
            InitializeComponent();
            Utils.DownloadCompleted += DownloadComplete;
            Utils.DownloadProgressChanged += DownloadProgress;

            //Settings = new Settings();
            //Items = DownloadItemList.GetList();
            
        }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            Utils.downloading = false;
        }
        //private bool downloading;
        private void FrmDeploy_Load(object sender, EventArgs e)
        {
            try
            {
                cboVersion.Items.AddRange(Items.OrderByDescending(i=>i.AppVersion.Major).ThenByDescending(i=>i.AppVersion.Minor).Select(i => i.Version).Distinct().ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls).Select(s => s.Replace(Settings.PathToInstalls, "")).Where(d => d.StartsWith("20")).ToArray<object>());
            }
            catch { }
            this.Text += string.Format(" (Cache Date: {0})", Items.FileDate.ToString("MM-dd-yyyy")) ;
            txtInstance.DataSource = Instances();
            txtInstance.SelectedIndex = -1;
            if (Utils.HasError)
                this.lblMessage.Text += Utils.Error;
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPatch.Items.Clear();
            if (cboVersion.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(cboVersion.Text))
                cboPatch.Items.AddRange(Items.Where(i=>i.Version==cboVersion.Text).OrderByDescending(i => i.AppVersion).ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString()).Select(s => s.Replace(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString() + @"\", "")).ToArray<object>());
        }
        private string SourcePath
        {
            get
            {
                return InstallPath + cboVersion.SelectedItem.ToString() + @"\" + ((DownloadItem)cboPatch.SelectedItem).PatchVersion.ToString() + @"\Acumatica ERP";
            }
        }
        private string InstallPath
        {
            get
            {
                return Settings.PathToInstalls + (Settings.PathToInstalls.EndsWith("\\") ? "" : "\\");
            }
        }
        private string ErpPath
        {
            get
            {
                return string.Format("{0}{1}", Settings.PathToAcumatica, txtInstance.Text);
            }
        }

        private void txtInstance_TextChanged(object sender, EventArgs e)
        {
            if(System.IO.Directory.Exists(ErpPath) && System.IO.Directory.Exists(ErpPath + "\\site"))
            {
                txtInstance_SelectedIndexChanged(sender, e);
                chkDemoData.Enabled = false;
                chkNewDB.Enabled = false;
                chkDemoData.Checked = false;
                chkNewDB.Checked = false;
                btnInstall.Enabled = false;
                btnUpgrade.Enabled = true;
            }
            else
            {
                txtDBName.Text = "";
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
        private DownloadItem SelectedVersion
        {
            get
            {
                if(cboPatch.SelectedItem !=null)
                {
                    return (DownloadItem)cboPatch.SelectedItem;
                }
                return null;
            }
        }
        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if (!SelectedVersion.Cached)
            {
                Utils.DownloadFile(SelectedVersion,OutputHandler );
                
            }
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
            //var ps1File = Settings.PathToInstalls + @"ProcessAcumaticaInstaller.ps1";
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
                //Settings = new Settings();
                FrmDeploy_Load(this, new EventArgs());
            }
        }

        private void cboVersion_TextUpdate(object sender, EventArgs e)
        {
            cboVersion_SelectedIndexChanged(sender, e);
        }
        private List<string> Instances()
        {
            var key=Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Acumatica ERP");
            var retVal= key?.GetSubKeyNames().ToList();
            return retVal;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Items.RefreshData();
        }

        private void txtInstance_SelectedIndexChanged(object sender, EventArgs e)
        {

            var configFile = new FileInfo(ErpPath + @"\site\web.config");
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            var config= WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
            var test = config.ConnectionStrings.ConnectionStrings.GetEnumerator();
            while (test.Current == null || ((ConnectionStringSettings)test.Current)?.Name != "ProjectX")
                if (!test.MoveNext())
                    break;
            ConnectionStringSettings item =(ConnectionStringSettings)test.Current;
            if (item.Name != "ProjectX")
                txtDBName.Text = "";
            else
                txtDBName.Text = item.ConnectionString.Split(';').FirstOrDefault(s=>s.Contains("Initial Catalog")).Split('=').Last();
        }


    }
}
