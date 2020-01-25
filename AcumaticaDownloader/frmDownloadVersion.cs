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
        //private Settings Settings;
        private bool hasLoaded;
        
        public frmDownloadVersion()
        {
            InitializeComponent();
            //Settings = new Settings();
            Utils.DownloadCompleted += DownloadComplete;
            Utils.DownloadProgressChanged += DownloadProgress;
            //Items = DownloadItemList.GetList();
            bs = new BindingSource();
            bs.DataSource = new BindingListView<DownloadItem>(Utils.Items);
            listBox1.DataSource = bs;
            //hasLoaded = false;
        }
        //DownloadItemList Items;
        BindingSource bs;
        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.UseWaitCursor = true;
            //Items.Clear();
            if(hasLoaded)
                Utils.Items.RefreshData();
            //var url = Settings.AcumaticaS3Url;
            //var boolTruncated = true;
            //while (boolTruncated)
            //{
            //    var test = Utils.GetResults(url);
            //    var results = test.Contents;//.Where(s => s.Key.Contains(txtFilter.Text)).ToList();
            //    string lastKey="";
            //    foreach (var item in results)
            //    {
            //        try
            //        {
            //            //lastKey = item.Key;
            //            if (item.Key.Contains("AcumaticaERP") && item.Key.ToLower().Contains(".msi") && !CheckFile(item.Key))
            //            {
            //                var dl = new DownloadItem() { Filename = item.Key };
            //                dl.Version = GetVersion2(GetVersion(dl));
            //                Version ver ;
            //                if (Version.TryParse(GetVersion(dl), out ver))
            //                    {
            //                    dl.AppVersion = ver;
            //                     }
            //                if (item.Key.ToLower().Contains("preview") || item.Key.ToLower().Contains("beta"))
            //                {
            //                    dl.Preview = true;
            //                    Items.Add(dl);
            //                }
            //                else if (!(item.Key.ToLower().Contains("hotfix") || item.Key.ToLower().Contains("recalled") || item.Key.ToLower().Contains("rejected") || item.Key.ToLower().Contains("hidden")))
            //                {
            //                    Items.Add(dl);
            //                }
            //            }
            //        }
            //        catch { }
            //        Application.DoEvents();
            //    }
            //    boolTruncated = bool.Parse(test.IsTruncated);
            //    if(boolTruncated)
            //    {
            //        lastKey = test.Contents.Last().Key;
            //        url = Settings.AcumaticaS3Url + "?marker=" + lastKey;
            //    }
            //}
            this.Enabled = true ;
            this.UseWaitCursor = false;
            var vers = Utils.Items.OrderByDescending(i=>i.AppVersion.Major).ThenByDescending(i=>i.AppVersion.Minor).Select(i=>i.Version).Distinct().ToList();
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
            Utils.downloading = false;
        }
        
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(!File.Exists(Settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1"))
            {
                var data=File.ReadAllText(Application.StartupPath  + @"\scripts\ProcessAcumaticaInstaller.ps1");
                data = data.Replace("{targetFolder}", Settings.PathToInstalls);
                File.WriteAllBytes(Settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1", System.Text.Encoding.Default.GetBytes(data));
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
                    Utils.downloading = true;
                    //var file = Utils.GetFile(item);
                    CurrentItem.InProgress = true;
                    bs.ResetBindings(false);
                    Utils.DownloadFile(item,OutputHandler);
                    CurrentItem.Downloaded = true;
                    CurrentItem.InProgress = false;
                    bs.ResetBindings(false);
                    Application.DoEvents();
                }
            }
            this.Enabled = true;
            this.UseWaitCursor = false;
            if (Utils.Items.Count > 0)
                MessageBox.Show("Download(s) Complete.", "Acumatica Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        
        private string OutputLog;
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string line;
            if (outLine != null && outLine.Data != null && listBox2?.Items?.Count>0)
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
            hasLoaded = true;
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
                view.ApplyFilter(f => !f.Preview && !f.Cached);
            else if (verTest.Count == 0 && chkPreview.Checked)
            {
                view.RemoveFilter();
                view.ApplyFilter(f => !f.Cached);
            }
            else if (cmbVersion.CheckedItems.Count >= 0 && !chkPreview.Checked)// || ea?.NewValue==CheckState.Checked) && !chkPreview.Checked)
                view.ApplyFilter(f => !f.Preview && verTest.Contains(f.Version) && !f.Cached);// || (ea!=null && ea.NewValue==CheckState.Checked && ((CCBoxItem)cmbVersion.Items[ea.Index]).Name==f.Version)));
            else if (cmbVersion.CheckedItems.Count >= 0 && chkPreview.Checked) //|| ea?.NewValue == CheckState.Checked) && chkPreview.Checked)
                view.ApplyFilter(f => verTest.Contains(f.Version) && !f.Cached);

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

