using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace AcuDevDeployer
{
    [Serializable]
    public class DownloadItem
    {
        public Version AppVersion
        {
            get
            {
                Version ver;
                if (System.Version.TryParse(Utils.GetVersion(this), out ver))
                {
                    return ver;
                }
                return new Version();
            }
        }

        public string PatchVersion
        {
            get
            {
                return Utils.GetVersion(this);
            }
        }

        public string Version
        {
            get
            {
                return Utils.GetVersion2(Utils.GetVersion(this));
            }
        }

        public string Filename { get; set; }

        public bool Preview
        {
            get
            {
                return Filename.ToLower().Contains("preview") || Filename.ToLower().Contains("beta");
            }
        }

        public bool Cached
        {
            get
            {
                return Utils.CheckFile(this, Settings.PathToInstalls);
            }
        }

        public bool Downloaded { get; set; }
        public bool InProgress { get; set; }

        public string Label
        {
            get
            {
                return PatchVersion + (Preview ? " Preview" : "") + (Cached ? " - Cached" : "");
            }
        }

        public override string ToString()
        {
            return Filename + (Downloaded ? " - Done" : (InProgress ? " - Processing" : ""));
        }
    }

    [Serializable]
    public class DownloadItemList : BindingList<DownloadItem>
    {
        public static DownloadItemList GetList()
        {
            DownloadItemList retVal = LoadFile();
            if (retVal == null)
            {
                retVal = new DownloadItemList();
                retVal.RefreshData();
            }
            return retVal;
        }

        //private Settings Settings;
        //private bool hasLoaded;
        // public event DownloadProgressChangedEventHandler DownloadProgress;
        //public event AsyncCompletedEventHandler DownloadComplete;
        private string url;

        public DateTime FileDate
        {
            get
            {
                try
                {
                    return System.IO.File.GetLastWriteTime(fileName);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }

        private void OnDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            Utils.downloading = true;
            // DownloadProgress(sender, e);
        }

        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            Utils.downloading = false;
            //DownloadComplete.Invoke(sender, e);
        }

        //private bool downloading;
        private DownloadItemList()
        {
            //Settings = new Settings();
            Utils.DownloadCompleted += OnDownloadComplete;
            Utils.DownloadProgressChanged += OnDownloadProgress;
            //hasLoaded = false;
            url = Settings.AcumaticaS3Url;
        }

        private string fileName
        {
            get
            {
                return Settings.PathToInstalls + @"Cache.xml";
            }
        }

        private void SaveFile()
        {
            var ser = new System.Xml.Serialization.XmlSerializer(typeof(DownloadItemList));
            var ms = new System.IO.MemoryStream();
            ser.Serialize(ms, this);
            System.IO.File.WriteAllBytes(fileName, ms.ToArray());
        }

        private static DownloadItemList LoadFile()
        {
            if (System.IO.File.Exists(Settings.PathToInstalls + @"Cache.xml"))
            {
                var ser = new System.Xml.Serialization.XmlSerializer(typeof(DownloadItemList));
                var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(Settings.PathToInstalls + @"Cache.xml"));
                DownloadItemList cache = (DownloadItemList)ser.Deserialize(ms);
                return cache;
            }
            return null;
        }

        public void RefreshData()
        {
            Items.Clear();
            var boolTruncated = true;
            Utils.Progress.ProgressMessage = "Refreshing Versions";
            Utils.Progress.ProgressValue = 0;
            if (!Utils.Progress.Visible)
                Utils.Progress.Show();
            Application.DoEvents();
            while (boolTruncated)
            {
                var batch = Utils.GetResults(url);
                Application.DoEvents();
                var results = batch.Contents;//.Where(s => s.Key.Contains(txtFilter.Text)).ToList();
                string lastKey = "";
                Utils.Progress.ProgressValue = 0;
                Utils.Progress.ProgressMax = results.Count;
                Application.DoEvents();
                foreach (var item in results)
                {
                    Utils.Progress.ProgressValue = results.IndexOf(item) + 1;
                    Utils.Progress.ProgressValue -= 1;
                    Utils.Progress.ProgressValue += 1;
                    System.Diagnostics.Debug.WriteLine(Utils.Progress.ProgressValue);
                    Utils.Progress.Refresh();
                    Application.DoEvents();
                    try
                    {
                        //lastKey = item.Key;
                        if (item.Key.Contains("AcumaticaERP") && item.Key.ToLower().Contains(".msi"))
                        {
                            var dl = new DownloadItem() { Filename = item.Key };
                            //dl.Version = Utils.GetVersion2(Utils.GetVersion(dl));
                            //Version ver;
                            //if (Version.TryParse(Utils.GetVersion(dl), out ver))
                            //{
                            //    dl.AppVersion = ver;
                            //}
                            if (dl.PatchVersion.Replace(".", "").IsNumeric())
                                if (item.Key.ToLower().Contains("preview") || item.Key.ToLower().Contains("beta"))
                                {
                                    //    dl.Preview = true;
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
                boolTruncated = bool.Parse(batch.IsTruncated);
                if (boolTruncated)
                {
                    lastKey = batch.Contents.Last().Key;
                    url = Settings.AcumaticaS3Url + "?marker=" + lastKey;
                }
                Application.DoEvents();
            }
            Utils.Progress.Hide();
            SaveFile();
            url = Settings.AcumaticaS3Url;
        }
    }
}