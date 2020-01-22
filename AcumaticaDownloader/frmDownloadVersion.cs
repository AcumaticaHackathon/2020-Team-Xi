using CheckComboBoxTest;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AcumaticaDeployer
{
    public partial class frmDownloadVersion : Form
    {
        private Settings settings;
        private bool hasLoaded;
        public frmDownloadVersion()
        {
            InitializeComponent();
            settings = new Settings();
            Utils.DownloadCompleted += DownloadComplete;
            Utils.DownloadProgressChanged += DownloadProgress;
            Items = new BindingList<DownloadItem>();
            bs = new BindingSource();
            bs.DataSource = new BindingListView<DownloadItem>(Items);
            listBox1.DataSource = bs;
            hasLoaded = false;
        }
        BindingList<DownloadItem> Items;
        BindingSource bs;
        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.UseWaitCursor = true;
            Items.Clear();
            var url = settings.AcumaticaS3Url;
            var boolTruncated = true;
            while (boolTruncated)
            {
                var test = Utils.GetResults(url);
                var results = test.Contents;//.Where(s => s.Key.Contains(txtFilter.Text)).ToList();
                string lastKey="";
                foreach (var item in results)
                {
                    try
                    {
                        //lastKey = item.Key;
                        if (item.Key.Contains("AcumaticaERP") && item.Key.ToLower().Contains(".msi") && !CheckFile(item.Key))
                        {
                            var dl = new DownloadItem() { Filename = item.Key };
                            dl.Version = GetVersion2(GetVersion(dl));
                            Version ver ;
                            if (Version.TryParse(GetVersion(dl), out ver))
                                {
                                dl.AppVersion = ver;
                                 }
                            if (item.Key.ToLower().Contains("preview") || item.Key.ToLower().Contains("beta"))
                            {
                                dl.Preview = true;
                                Items.Add(dl);
                            }
                            else if (!(item.Key.ToLower().Contains("hotfix") || item.Key.ToLower().Contains("recalled") || item.Key.ToLower().Contains("rejected") || item.Key.ToLower().Contains("hidden")))
                            {
                                Items.Add(dl);
                            }
                        }
                    }
                    catch { }
                    Application.DoEvents();
                }
                boolTruncated = bool.Parse(test.IsTruncated);
                if(boolTruncated)
                {
                    lastKey = test.Contents.Last().Key;
                    url = settings.AcumaticaS3Url + "?marker=" + lastKey;
                }
            }
            this.Enabled = true ;
            this.UseWaitCursor = false;
            var vers = Items.OrderByDescending(i=>i.AppVersion).Select(i=>i.Version).Distinct().ToList();
            //vers.Insert(0, "");
            //var data = new List<CCBoxItem>();
            //data.AddRange(vers.Select(v => new CCBoxItem() { Name = v }));
            foreach(var item in vers)
            {
                cmbVersion.Items.Add(new CCBoxItem() { Name = item });
            }
            cmbVersion.SetCheckedItems(AcumaticaDeployer.Properties.Settings.Default.VersionFilter);
            chkPreview.Checked = AcumaticaDeployer.Properties.Settings.Default.IncludePreview;
            //cmbVersion.Refresh();
            Filter_Changed(sender, e);
            bs.ResetBindings(false);
        }
        private bool CheckFile(string key)
        {
            var parts = key.Split('/').ToList();
            parts[0] = settings.PathToInstalls;
            parts[1] = "20" + parts[1].Replace(".", "r");
            parts.RemoveAt(3);
            var filename2 = string.Join("\\", parts.ToArray());
            parts.RemoveAt(1);
            var filename1 = string.Join("\\", parts.ToArray());
            return System.IO.File.Exists(filename1) || System.IO.File.Exists(filename2);
        }
        private string GetVersion(DownloadItem item)//(string key)
        {
            var key = item.Filename;
            var parts = key.Split('/').ToList();
            if(item.Preview)
                return parts[2];
            else
                return parts[2];
        }
        private DownloadItem CurrentItem
        {
            get
            {
                if(listBox1.SelectedItem !=null)
                {
                    return ((Equin.ApplicationFramework.ObjectView<DownloadItem>)listBox1.SelectedItem).Object;
                }
                else
                {
                    return null;
                }
            }
        }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            downloading = false;
        }
        private bool downloading;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(!File.Exists(settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1"))
            {
                var data=File.ReadAllText(Application.StartupPath  + @"\scripts\ProcessAcumaticaInstaller.ps1");
                data = data.Replace("{targetFolder}", settings.PathToInstalls);
                File.WriteAllBytes(settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1", System.Text.Encoding.Default.GetBytes(data));
            }
            //var list = listBox1.Items.Cast<DownloadItem>().ToList();
            this.Enabled = false;
            this.UseWaitCursor = true;

            foreach (DownloadItem item in (BindingListView<DownloadItem>)bs.DataSource)
            {
                listBox1.SelectedItem = item;
                if (listBox1.GetItemChecked(listBox1.SelectedIndex))
                {
                    Application.DoEvents();
                    downloading = true;
                    //var file = Utils.GetFile(item);
                    CurrentItem.InProgress = true;
                    bs.ResetBindings(false);
                    Utils.GetFile(item.Filename, settings.PathToInstalls + "\\AcumaticaERPInstall.msi", settings.AcumaticaS3Url);
                    //System.IO.File.WriteAllBytes(settings.PathToInstalls + "\\AcumaticaERPInstall.msi", ((MemoryStream)file).ToArray());
                    while (downloading)
                        Application.DoEvents();

                    RunScript(GetVersion(item));//.Filename));
                    Application.DoEvents();
                    if (System.IO.File.Exists(settings.PathToInstalls + "\\AcumaticaERPInstall.msi"))
                    {
                        try
                        {
                            System.IO.File.Delete(settings.PathToInstalls + "\\AcumaticaERPInstall.msi");
                        }
                        catch { }
                    }
                    var releaseFolder = GetVersionFolder(GetVersion(item));//.Filename));
                    var installFolder = string.Format("{0}{1}", settings.PathToInstalls, GetVersion(item));//.Filename));
                    var destinationFolder = string.Format("{0}\\{1}", releaseFolder, GetVersion(item));//.Filename));
                    try
                    {
                        if (!Directory.Exists(releaseFolder))
                            Directory.CreateDirectory(releaseFolder);
                        Directory.Move(installFolder, destinationFolder);
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("There was an error moving the installation ({0}) \r\n into the release folder ({1}) \r\n you will need to move it manually.", GetVersion(item), releaseFolder), "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CurrentItem.Downloaded = true;
                    CurrentItem.InProgress = false;
                    bs.ResetBindings(false);
                    Application.DoEvents();
                }
            }
            this.Enabled = true;
            this.UseWaitCursor = false;
            if (Items.Count > 0)
                MessageBox.Show("Download(s) Complete.", "Acumatica Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GetVersionFolder(string version)
        {
            var retVal = string.Format("{0}\\{1}{2}", settings.PathToInstalls, version.IndexOf(".") > 1 ? "20" : "", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\",@"\");
            return retVal;
        }
        private string GetVersion2(string version)
        {
            var retVal = string.Format("{0}{1}", version.IndexOf(".")>1?"20":"", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\", @"\");
            return retVal;
        }
        private string RunScript(string version)
        {
            var ps1File = settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1";
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
            var results = new Process();
            results.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            results.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            results.StartInfo = startInfo;
            results.Start();
            results.BeginOutputReadLine();
            results.BeginErrorReadLine();
            while (!results.HasExited)
                Application.DoEvents();
            return OutputLog;
        }
        private string OutputLog;
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string line;
            if (outLine != null && outLine.Data != null)
            {
                line = (outLine.Data.ToString().Replace("\0", string.Empty));
                Debug.WriteLine(line);
                OutputLog += line + "\r\n";
                listBox2.Invoke(new Action(() => listBox2.Items.Add(line)));
                listBox2.Invoke(new Action(() => listBox2.SelectedIndex=listBox2.Items.Count-1));
            }
        }
        public frmDeploy FrmDeploy { get; set; }
        private void frmDownloadVersion_Load(object sender, EventArgs e)
        {
            //cmbVersion.SetCheckedItems( AcumaticaDeployer.Properties.Settings.Default.VersionFilter);
            FrmDeploy.lblMessage.Text = "Loading Download Tool";
            btnGet_Click(sender, e);
            FrmDeploy.lblMessage.Text = "";
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            var view = (BindingListView<DownloadItem>)bs.DataSource;
            ItemCheckEventArgs ea = null;
            var verTest = cmbVersion.CheckedItems.Cast<CCBoxItem>().Select(b => b.Name).ToList();
            if (e.GetType()==typeof(ItemCheckEventArgs))
            {
                ea = (ItemCheckEventArgs)e;
                var obj = ((CCBoxItem)cmbVersion.Items[ea.Index]).Name;
                if (verTest.Contains(obj) && ea.NewValue == CheckState.Unchecked)
                    verTest.Remove(obj);
                else if (!verTest.Contains(obj) && ea.NewValue == CheckState.Checked)
                    verTest.Add(obj);
            //    cmbVersion.SetItemChecked(ea.Index, (ea.NewValue==CheckState.Checked?true:false));
            }


            if (verTest.Count == 0 && !chkPreview.Checked)// && (ea?.NewValue??CheckState.Unchecked) != CheckState.Checked )|| (cmbVersion.CheckedItems.Count == 1 && ea?.NewValue == CheckState.Unchecked)) && !chkPreview.Checked)
                view.ApplyFilter(f => !f.Preview);
            else if (verTest.Count == 0 && chkPreview.Checked)
                view.RemoveFilter();
            else if (cmbVersion.CheckedItems.Count >= 0 && !chkPreview.Checked)// || ea?.NewValue==CheckState.Checked) && !chkPreview.Checked)
                view.ApplyFilter(f => !f.Preview && verTest.Contains(f.Version));// || (ea!=null && ea.NewValue==CheckState.Checked && ((CCBoxItem)cmbVersion.Items[ea.Index]).Name==f.Version)));
            else if (cmbVersion.CheckedItems.Count >= 0 && chkPreview.Checked) //|| ea?.NewValue == CheckState.Checked) && chkPreview.Checked)
                view.ApplyFilter(f => verTest.Contains(f.Version));

            //bs.Filter = "Filename like '*" + txtFilter.Text + "*'";
            //bs.ResetBindings(false);

            Application.DoEvents();
        }



        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            var list = (BindingListView<DownloadItem>)bs.DataSource;
            if (listBox1.CheckedItems.Count < listBox1.Items.Count)
                foreach (var item in list)
                    listBox1.SetItemChecked(listBox1.Items.IndexOf(item), true);
            else if(listBox1.CheckedItems.Count == listBox1.Items.Count)
                foreach (var item in list)
                    listBox1.SetItemChecked(listBox1.Items.IndexOf(item), false);

            if (listBox1.CheckedItems.Count == listBox1.Items.Count)
                btnCheckAll.Text = "Unselect All";
            else
                btnCheckAll.Text = "Select All";
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            if (splitContainer1.Panel2Collapsed)
                btnInfo.Text = "Show Info Panel";
            else
                btnInfo.Text = "Hide Info Panel";
        }

        private void cmbVersion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Filter_Changed(sender, e);
            
        }

        private void frmDownloadVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            AcumaticaDeployer.Properties.Settings.Default.VersionFilter = cmbVersion.Text;
            AcumaticaDeployer.Properties.Settings.Default.IncludePreview = chkPreview.Checked;
            AcumaticaDeployer.Properties.Settings.Default.Save();
        }

        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Changed(sender, e);
        }
    }
}

