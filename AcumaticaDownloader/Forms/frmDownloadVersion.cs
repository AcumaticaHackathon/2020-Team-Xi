using CheckComboBoxTest;
using Equin.ApplicationFramework;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public partial class frmDownloadVersion : Form
    {
        private bool hasLoaded;

        public frmDownloadVersion()
        {
            InitializeComponent();
            Utils.DownloadCompleted += DownloadComplete;
            Utils.DownloadProgressChanged += DownloadProgress;
            bs = new BindingSource
            {
                DataSource = new BindingListView<DownloadItem>(Utils.Items)
            };
            listBox1.DataSource = bs;
        }

        private readonly BindingSource bs;

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.UseWaitCursor = true;
            if (hasLoaded)
                Utils.Items.RefreshData();
            this.Enabled = true;
            this.UseWaitCursor = false;
            var vers = Utils.Items.OrderByDescending(i => i.AppVersion.Major).ThenByDescending(i => i.AppVersion.Minor).Select(i => i.Version).Distinct().ToList();
            foreach (var item in vers)
            {
                cmbVersion.Items.Add(new CCBoxItem() { Name = item });
            }
            cmbVersion.SetCheckedItems(AcumaticaDeployer.Properties.Settings.Default.VersionFilter);
            chkPreview.Checked = AcumaticaDeployer.Properties.Settings.Default.IncludePreview;
            Filter_Changed(sender, e);
            bs.ResetBindings(false);
        }

        private DownloadItem CurrentItem
        {
            get
            {
                if (listBox1.SelectedItem != null)
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
            if (!File.Exists(Settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1"))
            {
                var data = File.ReadAllText(Application.StartupPath + @"\scripts\ProcessAcumaticaInstaller.ps1");
                data = data.Replace("{targetFolder}", Settings.PathToInstalls);
                File.WriteAllBytes(Settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1", System.Text.Encoding.Default.GetBytes(data));
            }
            this.Enabled = false;
            this.UseWaitCursor = true;
            foreach (DownloadItem item in (BindingListView<DownloadItem>)bs.DataSource)
            {
                listBox1.SelectedItem = item;
                if (listBox1.GetItemChecked(listBox1.SelectedIndex))
                {
                    Application.DoEvents();
                    Utils.downloading = true;
                    CurrentItem.InProgress = true;
                    bs.ResetBindings(false);
                    Utils.DownloadFile(item, OutputHandler);
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
            if (outLine != null && outLine.Data != null && listBox2?.Items?.Count > 0)
            {
                line = (outLine.Data.ToString().Replace("\0", string.Empty));
                Debug.WriteLine(line);
                OutputLog += line + "\r\n";
                listBox2.Invoke(new Action(() => listBox2.Items.Add(line)));
                listBox2.Invoke(new Action(() => listBox2.SelectedIndex = listBox2.Items.Count - 1));
            }
        }

        public frmDeploy FrmDeploy { get; set; }

        private void frmDownloadVersion_Load(object sender, EventArgs e)
        {
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
            if (e.GetType() == typeof(ItemCheckEventArgs))
            {
                ea = (ItemCheckEventArgs)e;
                var obj = ((CCBoxItem)cmbVersion.Items[ea.Index]).Name;
                if (verTest.Contains(obj) && ea.NewValue == CheckState.Unchecked)
                    verTest.Remove(obj);
                else if (!verTest.Contains(obj) && ea.NewValue == CheckState.Checked)
                    verTest.Add(obj);
            }
            if (verTest.Count == 0 && !chkPreview.Checked)
                view.ApplyFilter(f => !f.Preview && !f.Cached);
            else if (verTest.Count == 0 && chkPreview.Checked)
            {
                view.RemoveFilter();
                view.ApplyFilter(f => !f.Cached);
            }
            else if (cmbVersion.CheckedItems.Count >= 0 && !chkPreview.Checked)
                view.ApplyFilter(f => !f.Preview && verTest.Contains(f.Version) && !f.Cached);
            else if (cmbVersion.CheckedItems.Count >= 0 && chkPreview.Checked)
                view.ApplyFilter(f => verTest.Contains(f.Version) && !f.Cached);
            Application.DoEvents();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            var list = (BindingListView<DownloadItem>)bs.DataSource;
            if (listBox1.CheckedItems.Count < listBox1.Items.Count)
                foreach (var item in list)
                    listBox1.SetItemChecked(listBox1.Items.IndexOf(item), true);
            else if (listBox1.CheckedItems.Count == listBox1.Items.Count)
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