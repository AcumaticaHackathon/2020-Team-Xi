using AcuDevDeployer.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AcuDevDeployer
{
    public class Utils
    {
        private static DownloadItemList items = null;
        public static void RefreshItems()
        {
            items = DownloadItemList.GetList();
        }
        public static DownloadItemList Items
        {
            get
            {
                if (items == null)
                    items = DownloadItemList.GetList();
                return items;
            }
        }

        private static bool _hasError;
        public static string Error { get; set; }

        public static bool HasError
        { get { return _hasError; }
            set { _hasError = value; }
        }

        public static ListBucketResult GetResults(string url)
        {
            try
            {
                var req = WebRequest.CreateHttp(url);
                var resp = req.GetResponse();
                var str = resp.GetResponseStream();
                //var sr = new StreamReader(str);
                var xml = new XmlSerializer(typeof(ListBucketResult));
                var retVal = (ListBucketResult)xml.Deserialize(str);
                _hasError = false;
                return retVal;
            }
            catch (Exception ex)
            {
                _hasError = true;
                Error = ex.ToString();
                return null;
            }
        }

        public static event DownloadProgressChangedEventHandler DownloadProgressChanged;

        public static event AsyncCompletedEventHandler DownloadCompleted;

        public static void GetFile(string key, string filename, string url)
        {
            var req = new WebClient();
            req.DownloadFileCompleted += (sender, e) => { DownloadCompleted.Invoke(sender, e); };
            req.DownloadProgressChanged += (sender, e) => { DownloadProgressChanged.Invoke(sender, e); };
            downloading = true;
            req.DownloadFileAsync(new Uri(string.Format("{0}{1}", url, key)), filename);
            //var resp = req.GetResponse();
            //var str = resp.GetResponseStream();
            //var sr = new BinaryReader(str);
            //var retVal = new System.IO.MemoryStream(sr.ReadBytes((int)resp.ContentLength));
            //return retVal;
        }

        public static string GetVersion(DownloadItem item)//(string key)
        {
            var key = item.Filename;
            var parts = key.Split('/').ToList();
            if (parts.Count > 1)
                return parts[2];
            else
                return "";
        }

        //public static string GetVersionFolder(string version, string path)
        //{
        //    var retVal = string.Format("{0}\\{1}{2}", path, version.IndexOf(".") > 1 ? "20" : "", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\", @"\");
        //    return retVal;
        //}

        public static string GetVersion2(string version)
        {
            var ver = System.Version.Parse(version);
            var major = ver.Major.ToString();
            var minor = (Math.Round((double)(ver.Minor / 100.0)));
            //var retVal = string.Format("{0}{1}", version.IndexOf(".") > 1 ? "20" : "", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\", @"\");
            var retVal = string.Format("{0}{1}", version.IndexOf(".") > 1 ? "20" : "", string.Format("{0}R{1}", major, minor));
            return retVal;
        }

        public static bool CheckFile(DownloadItem item, string path)
        {
            //var parts = key.Split('/').ToList();
            //parts[0] = path;
            //parts[1] = "20" + parts[1].Replace(".", "r");
            //parts.RemoveAt(3);
            //var filename2 = string.Join("\\", parts.ToArray());
            //parts.RemoveAt(1);
            //var filename1 = string.Join("\\", parts.ToArray());
            var fi = new FileInfo(item.Filename);
            var filename = string.Format(@"{0}\{1}\{2}\{3}", path, item.Version, item.PatchVersion,fi.Name);
            return System.IO.File.Exists(filename);// || System.IO.File.Exists(filename2);
        }

        public static bool DownloadFile(DownloadItem item, DataReceivedEventHandler handler, bool notify=true)
        {
            Utils.GetFile(item.Filename, Settings.PathToInstalls + "\\AcumaticaERPInstall.msi", Settings.AcumaticaS3Url);
            //System.IO.File.WriteAllBytes(Settings.PathToInstalls + "\\AcumaticaERPInstall.msi", ((MemoryStream)file).ToArray());
            while (downloading)
                Application.DoEvents();
            if(HasError)
            {
                if (notify)
                    MessageBox.Show("There was an error downloading the file", "Download Error", MessageBoxButtons.OK);
                else
                {
                    var e = DataReceivedEventArgsExt.Create("There was an error downloading the file");
                    handler.Invoke(null, e);

                }
                return false;
            }
            RunScript(Utils.GetVersion(item), handler);//.Filename));
            Application.DoEvents();
            if (System.IO.File.Exists(Settings.PathToInstalls + "\\AcumaticaERPInstall.msi"))
            {
                try
                {
                    System.IO.File.Delete(Settings.PathToInstalls + "\\AcumaticaERPInstall.msi");
                }
                catch { }
            }
            var releaseFolder = string.Format("{0}{1}", Settings.PathToInstalls, item.Version);//Utils.GetVersionFolder(Utils.GetVersion(item), Settings.PathToInstalls);//.Filename));
            var installFolder = string.Format("{0}{1}", Settings.PathToInstalls, item.PatchVersion);// Utils.GetVersion(item));//.Filename));
            var destinationFolder = string.Format("{0}\\{1}", releaseFolder, item.PatchVersion); // Utils.GetVersion(item));//.Filename));
            try
            {
                if (!Directory.Exists(releaseFolder))
                    Directory.CreateDirectory(releaseFolder);
                Directory.Move(installFolder, destinationFolder);
            }
            catch
            {
                if (notify)
                    MessageBox.Show(string.Format("There was an error moving the installation ({0}) \r\n into the release folder ({1}) \r\n you will need to move it manually.", Utils.GetVersion(item), releaseFolder), "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var e = DataReceivedEventArgsExt.Create(string.Format("There was an error moving the installation ({0}) \r\n into the release folder ({1}) \r\n you will need to move it manually.", Utils.GetVersion(item), releaseFolder));
                    handler.Invoke(null, e);
                }
                return false;
            }
            return true;
        }

        public static void RunScript(string version, DataReceivedEventHandler handler)
        {
            var ps1File = Settings.PathToInstalls + @"\ProcessAcumaticaInstaller.ps1";
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
            results.OutputDataReceived += new DataReceivedEventHandler(handler);
            results.ErrorDataReceived += new DataReceivedEventHandler(handler);
            results.StartInfo = startInfo;
            results.Start();
            results.BeginOutputReadLine();
            results.BeginErrorReadLine();
            while (!results.HasExited)
                Application.DoEvents();
            //return OutputLog;
        }

        public static bool downloading;
        private static frmProgress progress;

        public static frmProgress Progress
        {
            get
            {
                if (progress == null)
                    progress = new frmProgress();
                return progress;
            }
        }

        public static CustomizationItem[] Customizations
        {
            get
            {
                var retVal = new List<CustomizationItem>();
                var files = System.IO.Directory.GetFiles(Settings.CustomizationPath, "*.zip");
                foreach (var file in files)
                {
                    var zip = Ionic.Zip.ZipFile.Read(file);
                    if (zip.Entries.Where(z => z.FileName.ToLower().Contains("project.xml")).Count() > 0)
                    {
                        var fi = new FileInfo(file);
                        retVal.Add(new CustomizationItem() {Name=fi.Name,Path=fi.FullName });
                    }
                }
                return retVal.ToArray();
            }
        }
        public static object MyConvert(string Type, string Value)
        {
            object retVal = null;
            if (!string.IsNullOrWhiteSpace(Value))
                retVal = Convert.ChangeType(Value, System.Type.GetType(Type));
            return retVal;
        }
    }

    public static class StringExt
    {
        public static bool IsNumeric(this string text) => double.TryParse(text, out _);
    }
    public static class DataReceivedEventArgsExt
    {
        public static DataReceivedEventArgs Create(this string Data)
        {

                if (String.IsNullOrEmpty(Data))
                    throw new ArgumentException("Data is null or empty.", "Data");

                DataReceivedEventArgs EventArgs =
                    (DataReceivedEventArgs)System.Runtime.Serialization.FormatterServices
                     .GetUninitializedObject(typeof(DataReceivedEventArgs));

                FieldInfo[] EventFields = typeof(DataReceivedEventArgs)
                    .GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance |
                        BindingFlags.DeclaredOnly);

                if (EventFields.Count() > 0)
                {
                    EventFields[0].SetValue(EventArgs, Data);
                }
                else
                {
                    throw new ApplicationException(
                        "Failed to find _data field!");
                }

                return EventArgs;

        }
    }
}