using AcumaticaDeployer.Objects;
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
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmDeploy : Form
    {
        private const string Title = "Acumatica Deployer";
        private Instance instance;
        private DownloadItemList Items { get { return Utils.Items; } }

        public frmDeploy()
        {
            InitializeComponent();
            Utils.DownloadCompleted += DownloadComplete;
            Utils.DownloadProgressChanged += DownloadProgress;
        }

        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            Utils.downloading = false;
        }

        private void FrmDeploy_Load(object sender, EventArgs e)
        {
            try
            {
                cboVersion.SelectedIndex = -1;
                cboVersion.Items.Clear();
                cboVersion.Items.AddRange(Items.Where(i => chkPreview.Checked || !i.Preview).OrderByDescending(i => i.AppVersion.Major).ThenByDescending(i => i.AppVersion.Minor).Select(i => i.Version).Distinct().ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls).Select(s => s.Replace(Settings.PathToInstalls, "")).Where(d => d.StartsWith("20")).ToArray<object>());
            }
            catch { }
            try
            {
                cboCustom.Items.Clear();
                cboCustom.Items.AddRange(Utils.Customizations);
            }
            catch { }
            this.Text = string.Format("{0} (Cache Date: {1})", Title, Items.FileDate.ToString("MM-dd-yyyy"));
            txtInstance.DataSource = Instances();
            txtInstance.SelectedIndex = -1;
            txtDBServer.Text = Settings.DefaultDBServer;
            txtDBUser.Text = Settings.DefaultDBUser;
            txtDBPass.Text = Settings.DefaultDBPassword;
            txtACUser.Text = Settings.DefaultAcumaticaAdmin;
            txtACPass.Text = Settings.DefaultAcumaticaPassword;
            if (Utils.HasError)
                this.lblMessage.Text += Utils.Error;
            FillOptions();
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPatch.SelectedIndex = -1;
            cboPatch.Items.Clear();
            if (cboVersion.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(cboVersion.Text))
                cboPatch.Items.AddRange(Items.Where(i => i.Version == cboVersion.Text).Where(i => chkPreview.Checked || !i.Preview).OrderByDescending(i => i.AppVersion).ToArray());//System.IO.Directory.GetDirectories(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString()).Select(s => s.Replace(Settings.PathToInstalls + @"\" + cboVersion.SelectedItem.ToString() + @"\", "")).ToArray<object>());
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


       

        private DevOptions GetOptions()
        {
            var retVal = new DevOptions();
            System.Diagnostics.Debug.WriteLine(OptionPanel.Controls.Count);
            foreach (Control control in OptionPanel.Controls)
            {
                var type = control.GetType().ToString();
                if (control.Tag != null)
                    System.Diagnostics.Debug.WriteLine(type + ":" + string.Join(",", ((string[])control.Tag)));
                DevOption item;
                switch (type)
                {
                    case "System.Windows.Forms.CheckBox":
                        var chk = (CheckBox)control;
                        item = retVal.First(f => f.Name == ((string[])chk.Tag)[1]);
                        item.Value = chk.Checked.ToString();
                        System.Diagnostics.Debug.WriteLine(item.Name + ":" + chk.Checked.ToString());
                        retVal.Add(item);
                        break;

                    case "System.Windows.Forms.NumericUpDown":
                        var num = (NumericUpDown)control;
                        item = retVal.First(f => f.Name == ((string[])num.Tag)[1]);
                        item.Value = num.Value.ToString();
                        System.Diagnostics.Debug.WriteLine(item.Name + ":" + num.Value.ToString());
                        retVal.Add(item);
                        break;

                    default:
                        System.Diagnostics.Debug.WriteLine(control.Name + ":" + type + ":" + control.Tag?.ToString());
                        break;
                }
            }
            return retVal;
        }

        private void FillOptions()
        {
            var list = new DevOptions();
            var row = 0;
            foreach (var option in list)
            {
                var lbl = new Label() { AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };

                switch (option.Type)
                {
                    case "System.Boolean":
                        var chk = new CheckBox()
                        {
                            Text = option.Label,
                            Checked = Boolean.Parse(option.Recommend),
                            Tag = new string[] { option.Area, option.Name },
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleLeft
                        };
                        toolTip1.SetToolTip(chk, option.Desc);
                        OptionPanel.Controls.Add(lbl);
                        OptionPanel.Controls.Add(chk);
                        OptionPanel.SetRow(lbl, row);
                        OptionPanel.SetColumn(lbl, 0);
                        OptionPanel.SetRow(chk, row);
                        OptionPanel.SetColumn(chk, 1);
                        break;

                    case "System.Int32":
                        var num = new NumericUpDown()
                        {
                            Value = int.Parse(option.Recommend),
                            Tag = new string[] { option.Area, option.Name },
                            AutoSize = true,
                        };
                        toolTip1.SetToolTip(num, option.Desc);
                        lbl.Text = option.Label;
                        OptionPanel.Controls.Add(lbl);
                        OptionPanel.Controls.Add(num);
                        OptionPanel.SetRow(lbl, row);
                        OptionPanel.SetColumn(lbl, 0);
                        OptionPanel.SetRow(num, row);
                        OptionPanel.SetColumn(num, 1);
                        break;

                    default:
                        break;
                }

                row += 1;
                OptionPanel.RowCount = row;
            }
        }

        private void txtInstance_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(ErpPath) && System.IO.Directory.Exists(ErpPath + "\\site"))
            {
                txtInstance_SelectedIndexChanged(sender, e);
                chkDemoData.Enabled = false;
                chkNewDB.Enabled = false;
                chkDemoData.Checked = false;
                chkNewDB.Checked = false;
                btnInstall.Enabled = false;
                if (cboPatch.SelectedIndex > -1 && !string.IsNullOrWhiteSpace(instance.siteVersion) && Version.Parse(((DownloadItem)cboPatch.SelectedItem).PatchVersion) >= Version.Parse(instance.siteVersion))
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
                btnInstall.Enabled = true;
                btnUpgrade.Enabled = false;
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
                if (cboPatch.SelectedItem != null)
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
                WriteOutput(string.Format("Downloading Acumatica install for version: {0}", ((DownloadItem)cboPatch.SelectedItem).PatchVersion), true);
                Utils.DownloadFile(SelectedVersion, OutputHandler);
            }
            if (!Directory.Exists(ErpPath))
                Directory.CreateDirectory(ErpPath);
            if (!Directory.Exists(ErpPath + @"\Scripts"))
                Directory.CreateDirectory(ErpPath + @"\Scripts");
            if (!Directory.Exists(ErpPath + @"\Scripts\Setup"))
                Directory.CreateDirectory(ErpPath + @"\Scripts\Setup");
            if (!Directory.Exists(ErpPath + @"\Mods"))
                Directory.CreateDirectory(ErpPath + @"\Mods");
            var data = File.ReadAllText(AppPath() + @"\Scripts\CreateNewSite.ps1");
            data = data.Replace("{Acumatica Source Directory}", SourcePath);
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\CreateNewSite.ps1", System.Text.Encoding.UTF8.GetBytes(data));
            data = "InstanceName=" + txtInstance.Text + "\r\nDatabaseServer=" + txtDBServer.Text + "\r\nDatabaseName=" + txtDBName.Text + "\r\nIsNewDatabase=" + chkNewDB.Checked.ToString() + "\r\nInsertDemoData=" + chkDemoData.Checked.ToString() + "\r\nAcumaticaERPInstallDirectory=" + SourcePath + "\r\nIsPortal=" + chkPortal.Checked.ToString() + "\r\n" + "DatabaseUser=" + txtDBUser.Text.ToString() + "\r\n" + "DatabasePass=" + txtDBPass.Text.ToString() + "\r\n";
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            data = RunScript(ErpPath + @"\Scripts\Setup\CreateNewSite.ps1", cboPatch.SelectedItem.ToString());
            BtnUpdateUser_Click(sender, e);
            btnInstallCustom_Click(sender, e);
            instance.UpdateWebConfig(GetOptions());
            if (string.IsNullOrWhiteSpace(txtSnapshot.Text))
                CreateSnapshotRecord();
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
                    var sqlCommand = new System.Data.SqlClient.SqlCommand("update users set username=@username, password=@password, PasswordChangeOnNextLogin=0 where companyid=2 and username=@username", sqlConn);
                    sqlCommand.Parameters.AddWithValue("@username", txtACUser.Text);
                    sqlCommand.Parameters.AddWithValue("@password", txtACPass.Text);
                    if (sqlCommand.ExecuteNonQuery() == 0)
                    {
                        sqlCommand.CommandText = "insert into users (CompanyID, PKID, Username, ExtRef, Source, FirstName, LastName, FullName, ApplicationName, Email, Phone, Comment, LoginTypeID, Password, PasswordChangeable, PasswordChangeOnNextLogin," +
                                   "PasswordNeverExpires, AllowPasswordRecovery, PasswordQuestion, PasswordAnswer, IsApproved, IsPendingActivation, IsHidden, Guest, LastActivityDate, LastLoginDate, LastPasswordChangedDate, CreationDate, IsOnLine, " +
                                   "IsAssigned, OverrideADRoles, LastHostName, LockedOutDate, LastLockedOutDate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, " +
                                   "FailedPasswordAnswerAttemptWindowStart, GroupMask, GuidForPasswordRecovery, PasswordRecoveryExpirationDate, DeletedDatabaseRecord, CompanyMask, PseudonymizationStatus, NoteID, MultiFactorType, " +
                                   "MultiFactorOverride, AllowedSessions)" +
                                   "Select CompanyID, newid() as pkid, @username as username , ExtRef, Source, FirstName, LastName, FullName, ApplicationName, Email, Phone, Comment, LoginTypeID, @password as password, PasswordChangeable, 0 as PasswordChangeOnNextLogin," +
                                   "PasswordNeverExpires, AllowPasswordRecovery, PasswordQuestion, PasswordAnswer, IsApproved, IsPendingActivation, IsHidden, Guest, LastActivityDate, LastLoginDate, LastPasswordChangedDate, CreationDate, IsOnLine, " +
                                   "IsAssigned, OverrideADRoles, LastHostName, LockedOutDate, LastLockedOutDate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, " +
                                   "FailedPasswordAnswerAttemptWindowStart, GroupMask, GuidForPasswordRecovery, PasswordRecoveryExpirationDate, DeletedDatabaseRecord, CompanyMask, PseudonymizationStatus, newid() as noteid, MultiFactorType, " +
                                   "MultiFactorOverride, AllowedSessions from users where companyid=2 and username='admin'";
                        System.Diagnostics.Debug.WriteLine(sqlCommand.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex)
            {
                WriteOutput(ex.Message);
            }
        }

        private SqlConnection CreateSQLConnection(SQLConnectionSettings connectionSettings)
        {
            var sb = new System.Data.SqlClient.SqlConnectionStringBuilder(instance.connectionString)
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
                    chkNewDB.Invoke(new Action(() => chkNewDB.Checked = false));
                    break;

                case ConnectionState.Connecting:
                    break;

                case ConnectionState.Executing:
                    break;

                case ConnectionState.Fetching:
                    break;

                case ConnectionState.Broken:
                    chkNewDB.Invoke(new Action(() => chkNewDB.Checked = true));
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
            retVal = OutputLog;
            return retVal;
        }

        private int GetProgress(string data)
        {
            var parse = data.Split(':');
            if (parse[parse.Length - 1].Contains("%"))
            {
                var value = (int)decimal.Parse(parse[parse.Length - 1].Split('%')[0]);
                return value > 100 ? 100 : value;
            }
            return 0;
        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine != null && outLine.Data != null)
                WriteOutput(outLine.Data);
        }

        private void WriteOutput(string outLine, bool header = false)
        {
            string line = "";
            if (header)
                line += new string('=', 20) + "\r\n";
            line += (outLine.Replace("\0", string.Empty)) + "\r\n";
            if (header)
                line += new string('=', 20);
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
            File.WriteAllBytes(ErpPath + @"\Scripts\Setup\SiteParameters.txt", System.Text.Encoding.UTF8.GetBytes(data));
            btnUnInstallCustom_Click(sender, e);
            data = RunScript(ErpPath + @"\Scripts\Setup\UpgradeSite.ps1", cboPatch.SelectedItem.ToString());
            BtnUpdateUser_Click(sender, e);
            btnInstallCustom_Click(sender, e);
            instance.UpdateWebConfig(GetOptions());
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
                FrmDeploy_Load(this, new EventArgs());
            }
        }

        private void cboVersion_TextUpdate(object sender, EventArgs e)
        {
            cboVersion_SelectedIndexChanged(sender, e);
        }

        private List<string> Instances()
        {
            var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Acumatica ERP");
            var retVal = key?.GetSubKeyNames().ToList();
            return retVal;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Items.RefreshData();
        }



        private void txtInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (instance == null)
                    instance = new Instance();
                instance.Name = txtInstance.Text;
                var cs = instance.connectionString;
                if (string.IsNullOrEmpty(cs))
                {
                    txtDBName.Text = "";
                    txtDBServer.Text = Settings.DefaultDBServer;
                    txtDBUser.Text = Settings.DefaultDBUser;
                    txtDBPass.Text = Settings.DefaultDBPassword;
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
            if (txtInstance.SelectedIndex > -1)
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
            WriteOutput("Publishing Packages", true);
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
                    File.Copy(item, ErpPath + @"\mods\" + fi.Name, true);
                    packages.Add(fi.Name);
                    client.UploadPackage(fi.Name, System.IO.File.ReadAllBytes(item), true);
                }
                IsPublishing = true;

                client.PublishPackagesAsync(packages.ToArray(), true);
                while (IsPublishing)
                    Application.DoEvents();
            }
            catch (Exception ex)
            {
                WriteOutput(ex.Message);
                IsPublishing = false;
            }
            WriteOutput("Publishing Packages Complete", true);
        }

        private void btnUnInstallCustom_Click(object sender, EventArgs e)
        {
            try
            {
                WriteOutput("Unpublishing Packages", true);
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
                WriteOutput("Unpublishing Packages Complete", true);
            }
            catch (Exception ex)
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
                WriteOutput("Unpublish Unsuccessful.", true);
            }
            else
            {
                WriteOutput("Unpublish Successful.", true);
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
                WriteOutput("Publish Error Log:", true);
                WriteOutput(custompublishtext);
                WriteOutput("Publish Unsuccessful.", true);
            }
            else
            {
                WriteOutput("Publish Successful.", true);
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
                SQLTask = sqlConn.OpenAsync(cts.Token);
                await SQLTask;
            }
            catch (TaskCanceledException ex)
            { System.Diagnostics.Debug.WriteLine(ex.Message); }
            catch (Exception ex)
            {
                if (connectionSettings == SQLConnectionSettings.Database)
                    chkNewDB.Checked = true;
                else
                {
                    System.Diagnostics.Debug.Print("TestSQLConnectionAsync:{0}", ex.Message);
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
            if (!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);
        }

        private async void txtDBName_TextChanged(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server);

            if (!string.IsNullOrWhiteSpace(txtDBName.Text))
                await TestSQLConnectionAsync(SQLConnectionSettings.Database);
        }

        private async void txtDBUser_TextChanged(object sender, EventArgs e)
        {
            await TestSQLConnectionAsync(SQLConnectionSettings.Server);
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

        private void btnSaveWebConfig_Click(object sender, EventArgs e)
        {
            instance.UpdateWebConfig(GetOptions());
        }

        private void btnOFDSnaphot_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                FileName = txtSnapshot.Text,
                Title = "Select path for Snapshot file"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtSnapshot.Text = ofd.FileName;
        }

        private void txtSnapshot_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(txtSnapshot.Text))
            {
                PackageManifest gi = GetManifest(txtSnapshot.Text);
                var item = Items.First(f => f.PatchVersion == gi.GeneralInfo.Version);
                if (item != null)
                {
                    cboVersion.SelectedItem = item.Version;
                    cboPatch.SelectedItem = item;
                }
            }
        }

        private PackageManifest GetManifest(string filename)
        {
            var zip = Ionic.Zip.ZipFile.Read(filename);
            var manifest = zip.Entries.First(f => f.FileName == "Manifest.xml");
            var reader = manifest.OpenReader();
            var str = new StreamReader(reader);
            var data = str.ReadToEnd();
            var sr = new StringReader(data);
            var ser = new System.Xml.Serialization.XmlSerializer(typeof(PackageManifest));

            var gi = (PackageManifest)ser.Deserialize(sr);
            return gi;
        }

        private void CreateSnapshotRecord()
        {
            WriteOutput("Staging Snapshot", true);
            try
            {
                using (SqlConnection sqlConn = CreateSQLConnection(SQLConnectionSettings.Database))
                {
                    var id = Guid.NewGuid().ToString();
                    var gi = GetManifest(txtSnapshot.Text)?.GeneralInfo;
                    if (gi != null)
                        sqlConn.Open();

                    {
                        var sqlCommand = new System.Data.SqlClient.SqlCommand("insert into UPSnapshot ( [CompanyID],[SnapshotID], [Date]" +
                                                                              ",[Version],[Host],[Name],[Description],[ExportMode],[Customization]" +
                                                                              ",[MasterCompany],[SourceCompany],[LinkedCompany],[CreatedByID],[CreatedByScreenID]" +
                                                                              ",[CreatedDateTime],[LastModifiedByID],[LastModifiedByScreenID],[LastModifiedDateTime]" +
                                                                              ",[DeletedDatabaseRecord],[NoteID],[IsSafe])" +
                                                                              "select 2, @id, @date, @version, @host, @name, @desc, @export," +
                                                                              "NULL,NULL,2,-100020001,'D2BCFE36-7938-4737-957B-CA648CEB88D0','SM203520'," +
                                                                              "@auditdate,'D2BCFE36-7938-4737-957B-CA648CEB88D0','SM203520'," +
                                                                              "@auditdate,0,newid(),@issafe"
                        , sqlConn);
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlCommand.Parameters.AddWithValue("@date", gi.Date);
                        sqlCommand.Parameters.AddWithValue("@version", gi.Version);
                        sqlCommand.Parameters.AddWithValue("@host", gi.Host);
                        sqlCommand.Parameters.AddWithValue("@name", gi.Name);
                        sqlCommand.Parameters.AddWithValue("@desc", gi.Description);
                        sqlCommand.Parameters.AddWithValue("@export", gi.ExportMode);
                        sqlCommand.Parameters.AddWithValue("@issafe", gi.IsSafe);
                        sqlCommand.Parameters.AddWithValue("@auditdate", DateTime.Now);
                        var result = sqlCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            File.Copy(txtSnapshot.Text, ErpPath + @"\ERP\Site\Snapshots\" + id + ".zip");
                        }
                    }
                    WriteOutput("Snapshot saved as " + id + ".zip", true);
                }
            }
            catch (Exception ex)
            {
                WriteOutput(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSnapshotRecord();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSnapshot.Text))
                CreateSnapshotRecord();
        }
    }
}