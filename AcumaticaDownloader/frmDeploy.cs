using AcumaticaDeployer.ServiceGate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmDeploy : Form
    {
        private const string Title = "Acumatica Deployer";
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
                cboVersion.SelectedIndex = -1;
                cboVersion.Items.Clear();
                cboVersion.Items.AddRange(Items.Where(i=>chkPreview.Checked || !i.Preview).OrderByDescending(i=>i.AppVersion.Major).ThenByDescending(i=>i.AppVersion.Minor).Select(i => i.Version).Distinct().ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls).Select(s => s.Replace(Settings.PathToInstalls, "")).Where(d => d.StartsWith("20")).ToArray<object>());
            }
            catch { }
            try
            {
               cboCustom.Items.Clear();
                cboCustom.Items.AddRange(Utils.Customizations);
            }
            catch { }
            this.Text =  string.Format("{0} (Cache Date: {1})",Title, Items.FileDate.ToString("MM-dd-yyyy")) ;
            txtInstance.DataSource = Instances();
            txtInstance.SelectedIndex = -1;
            txtDBServer.Text  = Settings.DefaultDBServer;
            txtDBUser.Text = Settings.DefaultDBUser;
            txtDBPass.Text = Settings.DefaultDBPassword;
            txtACUser.Text = Settings.DefaultAcumaticaAdmin;
            txtACPass.Text = Settings.DefaultAcumaticaPassword;
            if (Utils.HasError)
                this.lblMessage.Text += Utils.Error;
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPatch.SelectedIndex = -1;
            cboPatch.Items.Clear();
            if (cboVersion.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(cboVersion.Text))
                cboPatch.Items.AddRange(Items.Where(i=>i.Version==cboVersion.Text).Where(i => chkPreview.Checked || !i.Preview).OrderByDescending(i => i.AppVersion).ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString()).Select(s => s.Replace(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString() + @"\", "")).ToArray<object>());
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
                if (cboPatch.SelectedIndex > -1 && !string.IsNullOrWhiteSpace(siteVersion) && Version.Parse(((DownloadItem)cboPatch.SelectedItem).PatchVersion) >= Version.Parse(siteVersion))
                    btnUpgrade.Enabled = true;
                else
                    btnUpgrade.Enabled = false;
            }
            else
            {
                txtDBName.Text = txtInstance.Text;
                txtDBServer.Text = Settings.DefaultDBServer;
                txtDBUser.Text = Settings.DefaultDBUser;
                txtDBPass.Text = Settings.DefaultDBPassword;
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
                WriteOutput(string.Format("Downloading Acumatica install for version: {0}", ((DownloadItem)cboPatch.SelectedItem).PatchVersion));
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
            data = "InstanceName=" + txtInstance.Text + "\r\nDatabaseServer=" + txtDBServer.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\nIsPortal=" + chkPortal.Checked.ToString() + "\r\n" + "DatabaseUser=" + txtDBUser.Text.ToString() + "\r\n" + "DatabasePass=" + txtDBPass.Text.ToString() + "\r\n";
            File.WriteAllBytes(ErpPath  + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            data=RunScript(ErpPath + @"\Scripts\Setup\CreateNewSite.ps1", cboPatch.SelectedItem.ToString());
            BtnUpdateUser_Click(sender, e);
            btnInstallCustom_Click(sender, e);
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\InstallLog.txt", System.Text.Encoding.UTF8.GetBytes(OutputLog));
            MessageBox.Show("Install Done", "Install Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = CreateSQLConnection(SQLConnectionSettings.Database))
                {
                    sqlConn.Open();
                    var sqlCommand = new System.Data.SqlClient.SqlCommand("update users set username='" + txtACUser.Text + "', password='" + txtACPass.Text + "', PasswordChangeOnNextLogin=0 where companyid=2 and username='" + txtACUser.Text + "'", sqlConn);
                    if (sqlCommand.ExecuteNonQuery() == 0)
                    {
                        sqlCommand.CommandText = "insert into users (CompanyID, PKID, Username, ExtRef, Source, FirstName, LastName, FullName, ApplicationName, Email, Phone, Comment, LoginTypeID, Password, PasswordChangeable, PasswordChangeOnNextLogin," +
                                   "PasswordNeverExpires, AllowPasswordRecovery, PasswordQuestion, PasswordAnswer, IsApproved, IsPendingActivation, IsHidden, Guest, LastActivityDate, LastLoginDate, LastPasswordChangedDate, CreationDate, IsOnLine, " +
                                   "IsAssigned, OverrideADRoles, LastHostName, LockedOutDate, LastLockedOutDate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, " +
                                   "FailedPasswordAnswerAttemptWindowStart, GroupMask, GuidForPasswordRecovery, PasswordRecoveryExpirationDate, DeletedDatabaseRecord, CompanyMask, PseudonymizationStatus, NoteID, MultiFactorType, " +
                                   "MultiFactorOverride, AllowedSessions)" +
                                   "Select CompanyID, newid() as pkid, '" + txtACUser.Text + "' as username , ExtRef, Source, FirstName, LastName, FullName, ApplicationName, Email, Phone, Comment, LoginTypeID, '" + txtACPass.Text + "' as password, PasswordChangeable, 0 as PasswordChangeOnNextLogin," +
                                   "PasswordNeverExpires, AllowPasswordRecovery, PasswordQuestion, PasswordAnswer, IsApproved, IsPendingActivation, IsHidden, Guest, LastActivityDate, LastLoginDate, LastPasswordChangedDate, CreationDate, IsOnLine, " +
                                   "IsAssigned, OverrideADRoles, LastHostName, LockedOutDate, LastLockedOutDate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, " +
                                   "FailedPasswordAnswerAttemptWindowStart, GroupMask, GuidForPasswordRecovery, PasswordRecoveryExpirationDate, DeletedDatabaseRecord, CompanyMask, PseudonymizationStatus, newid() as noteid, MultiFactorType, " +
                                   "MultiFactorOverride, AllowedSessions from users where companyid=2 and username='admin'";
                        System.Diagnostics.Debug.WriteLine(sqlCommand.ExecuteNonQuery());
                    }
                }
            }
            catch(Exception ex)
            {
                WriteOutput(ex.Message);
            }
        }

        private SqlConnection CreateSQLConnection(SQLConnectionSettings connectionSettings)
        {
            var sb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString)
            {
                DataSource = txtDBServer.Text
            };
            if (connectionSettings == SQLConnectionSettings.Database)
            {
                sb.InitialCatalog = txtDBName.Text;
            }
            else
            {
                sb.InitialCatalog = "";
            }
            sb.IntegratedSecurity = false;
            sb.UserID = txtDBUser.Text;
            sb.Password = txtDBPass.Text;
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(sb.ConnectionString);
            if (connectionSettings == SQLConnectionSettings.Database)
            {
                sqlConn.InfoMessage += SqlConn_InfoMessage;
                sqlConn.StateChange += SqlConnDB_StateChange;
            }
            else
            {
                sqlConn.StateChange += SqlConn_StateChange;
                sqlConn.InfoMessage += SqlConn_InfoMessage;
            }

            return sqlConn;
        }

        private void SqlConn_StateChange(object sender, StateChangeEventArgs e)
        {
            switch (e.CurrentState)
            {
                case ConnectionState.Closed:
                    break;
                case ConnectionState.Open:
                        picStatus.Invoke(new Action(() => picStatus.Image = Properties.Resources.OK));
                    break;
                case ConnectionState.Connecting:
                    break;
                case ConnectionState.Executing:
                    break;
                case ConnectionState.Fetching:
                    break;
                case ConnectionState.Broken:
                    picStatus.Invoke(new Action(() => picStatus.Image = Properties.Resources.Err));
                    break;
                default:
                    picStatus.Invoke(new Action(() => picStatus.Image = Properties.Resources.Err));
                    break;
            }
        }
        private void SqlConnDB_StateChange(object sender, StateChangeEventArgs e)
        {
            switch (e.CurrentState)
            {
                case ConnectionState.Closed:
                    break;
                case ConnectionState.Open:
                    chkNewDB.Invoke(new Action(() => chkNewDB.Checked = false)) ;
                    break;
                case ConnectionState.Connecting:
                    break;
                case ConnectionState.Executing:
                    break;
                case ConnectionState.Fetching:
                    break;
                case ConnectionState.Broken:
                    chkNewDB.Invoke(new Action(() => chkNewDB.Checked = true)) ;
                    break;
                default:
                    chkNewDB.Invoke(new Action(() => chkNewDB.Checked = true));
                    break;
            }
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

            Process results = new Process
            {
                StartInfo = startInfo
            };
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
            if (outLine != null && outLine.Data != null)
                WriteOutput(outLine.Data);
        }

        private void WriteOutput(string outLine)
        {
            string line;
                line = (outLine.Replace("\0", string.Empty));
                Debug.WriteLine(line);
                OutputLog += line + "\r\n";
                var progress = GetProgress(line);
                if (progress > 0)
                    progressBar1.Invoke(new Action(() => progressBar1.Value = progress));
                rtbLogs.Invoke(new Action(() => rtbLogs.AppendText(line + "\r\n")));
                rtbLogs.Invoke(new Action(() => rtbLogs.ScrollToCaret()));
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
            data = "InstanceName=" + txtInstance.Text + "\r\nDatabaseServer=" + txtDBServer.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\nIsPortal=" + chkPortal.Checked.ToString() + "\r\n" + "DatabaseUser=" + txtDBUser.Text.ToString() + "\r\n" + "DatabasePass=" + txtDBPass.Text.ToString() + "\r\n";
            //"InstanceName=" + txtInstance.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\n";
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            btnUnInstallCustom_Click(sender, e);
            data=RunScript(ErpPath + @"\Scripts\Setup\UpgradeSite.ps1", cboPatch.SelectedItem.ToString());
            BtnUpdateUser_Click(sender, e);
            btnInstallCustom_Click(sender, e);
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\UpgradeLog.txt", System.Text.Encoding.UTF8.GetBytes(OutputLog));
            MessageBox.Show("Upgrade Done", "Install Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGetNewVersions_Click(object sender, EventArgs e)
        {
            var frm = new frmDownloadVersion
            {
                FrmDeploy = this
            };
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
        private string connectionString
        {
            get
            {
                Configuration config = webConfig();
                var test = config.ConnectionStrings.ConnectionStrings.GetEnumerator();
                while (test.Current == null || ((ConnectionStringSettings)test.Current)?.Name != "ProjectX")
                    if (!test.MoveNext())
                        break;
                ConnectionStringSettings item = (ConnectionStringSettings)test.Current;
                if (item.Name != "ProjectX")
                    return "";
                else
                    return item.ConnectionString;
            }
        }
        private string siteVersion
        {
            get
            {
                string retVal="";
                Configuration config = webConfig();
                if (config.AppSettings.Settings.AllKeys.Contains("Version"))
                    retVal=config.AppSettings.Settings["Version"].Value;
                return retVal;
            }
        }

        private Configuration webConfig()
        {
            var configFile = new FileInfo(ErpPath + @"\site\web.config");
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            var config = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
            return config;
        }

        private void txtInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cs = connectionString;
                if(string.IsNullOrEmpty(cs))
                {
                    txtDBName.Text ="";
                    txtDBServer.Text = Settings.DefaultDBServer;
                    txtDBUser.Text = Settings.DefaultDBUser ;
                    txtDBPass.Text = Settings.DefaultDBPassword ;
                }
                else
                {
                    txtDBName.Text = cs.Split(';').FirstOrDefault(s => s.ToLower().Contains("initial catalog"))?.Split('=').Last();
                    txtDBServer.Text = cs.Split(';').FirstOrDefault(s => s.ToLower().Contains("data source"))?.Split('=').Last();
                    txtDBUser.Text = cs.Split(';').FirstOrDefault(s => s.ToLower().Contains("user"))?.Split('=').Last();
                    txtDBPass.Text = cs.Split(';').FirstOrDefault(s => s.ToLower().Contains("password"))?.Split('=').Last();

                }
            }
            catch
            {
                txtDBName.Text = "";
                txtDBServer.Text = Settings.DefaultDBServer;
                txtDBUser.Text = Settings.DefaultDBUser;
                txtDBPass.Text = Settings.DefaultDBPassword;
            }
                if(txtInstance.SelectedIndex>-1)
                {
                    chkPortal.Checked = File.Exists(ErpPath + @"\site\bin\SP.Objects.dll");
                }
                    
        }

        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            FrmDeploy_Load(sender, e);
        }
        private bool IsPublishing;
        private void btnInstallCustom_Click(object sender, EventArgs e)
        {
            WriteOutput("Publishing Packages");
            try
            {
                ServiceGate.ServiceGate client = new ServiceGate.ServiceGate
                {
                    CookieContainer = new System.Net.CookieContainer()
                };
                client.PublishPackagesCompleted += Client_PublishPackagesCompleted;
                client.Url = string.Format("http://localhost/{0}/api/ServiceGate.asmx", txtInstance.Text);
                LoginResult lr = client.Login(txtACUser.Text, txtACPass.Text);
                List<string> packages = new List<string>();
                foreach (string item in cboCustom.CheckedItems)
                {
                    var fi = new FileInfo(item);
                    packages.Add(fi.Name);
                    client.UploadPackage(fi.Name, System.IO.File.ReadAllBytes(item), true);
                }
                IsPublishing = true;
                client.PublishPackagesAsync(packages.ToArray(), true);

                while (IsPublishing)
                    Application.DoEvents();
            }catch(Exception ex)
            {
                WriteOutput(ex.Message);
                IsPublishing = false;
            }
        }
        private void btnUnInstallCustom_Click(object sender, EventArgs e)
        {
            try
            {
                WriteOutput("Unpublishing Packages");
                ServiceGate.ServiceGate client = new ServiceGate.ServiceGate
                {
                    CookieContainer = new System.Net.CookieContainer()
                };
                client.UnpublishAllPackagesCompleted += Client_UnpublishAllPackagesCompleted;
                client.Url = string.Format("http://localhost/{0}/api/ServiceGate.asmx", txtInstance.Text);
                LoginResult lr = client.Login(txtACUser.Text, txtACPass.Text);
                List<string> packages = new List<string>();
                IsPublishing = true;

                client.UnpublishAllPackagesAsync();

                while (IsPublishing)
                    Application.DoEvents();
            }
            catch(Exception ex)
            {
                WriteOutput(ex.Message);
                IsPublishing = false;
            }
        }

        private void Client_UnpublishAllPackagesCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var pos = e.Error?.Message?.IndexOf("Validation log:");
            if (pos.HasValue && pos.Value > 0)
            {
                custompublishtext = e.Error.Message.Substring(pos.Value);
                
                
                WriteOutput(custompublishtext);
            }
            else
            {
                WriteOutput("Unpublish Successful.");
            }
            IsPublishing = false;
        }

        private string custompublishtext;
        private void Client_PublishPackagesCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var pos = e.Error?.Message?.IndexOf("Validation log:");
            if (pos.HasValue && pos.Value > 0)
            {
                custompublishtext = e.Error.Message.Substring(pos.Value);
                WriteOutput( custompublishtext);
            }
            else
            {
                WriteOutput( "Publish Successful.");
            }
            IsPublishing = false;

        }
        private SqlConnection sqlConn;
        private enum SQLConnectionSettings
        {
            Database,
            Server
        }
        private Task SQLTask;
        private CancellationTokenSource cts;
        private async Task TestSQLConnectionAsync(SQLConnectionSettings connectionSettings)
        {
            try
            {
                sqlConn = CreateSQLConnection(connectionSettings);
                if (SQLTask != null && !SQLTask.IsCompleted)
                {
                    try
                    {
                        cts.Cancel();
                        while (!SQLTask.IsCanceled && !SQLTask.IsCompleted)
                            Application.DoEvents();
                        SQLTask.Dispose();
                    }
                    catch { }
                }
                cts = new CancellationTokenSource();
                 SQLTask= sqlConn.OpenAsync(cts.Token);
                await SQLTask;
                
                //picStatus.Image = Properties.Resources.OK;
            }
            catch(TaskCanceledException ex)
            { }
            catch(Exception ex)
            {
                if (connectionSettings == SQLConnectionSettings.Database)
                    chkNewDB.Checked = true;
                else
                {
                    System.Diagnostics.Debug.Print("TestSQLConnectionAsync:{0}",ex.Message);
                    picStatus.Image = Properties.Resources.Err;
                }
            }
        }

        private void SqlConn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (e.Errors?.Count > 0)
            {
                System.Diagnostics.Debug.Print("SqlConn_InfoMessage");
                picStatus.Invoke(new Action(() => picStatus.Image = Properties.Resources.Err));
            }
            else
                picStatus.Invoke(new Action(() => picStatus.Image = Properties.Resources.OK));
        }

        private async void txtDBServer_TextChangedAsync(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server);
            if(!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);
        }

        private async void txtDBName_TextChanged(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server);

            if (!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);
            //chkNewDB.Checked = (picStatus.Image == Properties.Resources.Err);
        }

        private async void txtDBUser_TextChanged(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server );
            if (!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);

        }

        private async void txtDBPass_TextChanged(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server);
            if (!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);

        }

        private void cboPatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInstance_TextChanged(sender, e);
        }
    }
}
