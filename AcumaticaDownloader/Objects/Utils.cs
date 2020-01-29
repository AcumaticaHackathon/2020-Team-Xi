using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AcumaticaDeployer
{
    public class Utils
    {
        private static DownloadItemList items = null;

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
        { get { return _hasError; } }

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

        public static string GetVersionFolder(string version, string path)
        {
            var retVal = string.Format("{0}\\{1}{2}", path, version.IndexOf(".") > 1 ? "20" : "", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\", @"\");
            return retVal;
        }

        public static string GetVersion2(string version)
        {
            var ver = System.Version.Parse(version);
            var major = ver.Major.ToString();
            var minor = (Math.Round((double)(ver.Minor / 100.0)));
            //var retVal = string.Format("{0}{1}", version.IndexOf(".") > 1 ? "20" : "", version.Substring(0, 4).Replace(".", "R")).Replace(@"\\", @"\");
            var retVal = string.Format("{0}{1}", version.IndexOf(".") > 1 ? "20" : "", string.Format("{0}R{1}", major, minor));
            return retVal;
        }

        public static bool CheckFile(string key, string path)
        {
            var parts = key.Split('/').ToList();
            parts[0] = path;
            parts[1] = "20" + parts[1].Replace(".", "r");
            parts.RemoveAt(3);
            var filename2 = string.Join("\\", parts.ToArray());
            parts.RemoveAt(1);
            var filename1 = string.Join("\\", parts.ToArray());
            return System.IO.File.Exists(filename1) || System.IO.File.Exists(filename2);
        }

        public static void DownloadFile(DownloadItem item, DataReceivedEventHandler handler)
        {
            Utils.GetFile(item.Filename, Settings.PathToInstalls + "\\AcumaticaERPInstall.msi", Settings.AcumaticaS3Url);
            //System.IO.File.WriteAllBytes(Settings.PathToInstalls + "\\AcumaticaERPInstall.msi", ((MemoryStream)file).ToArray());
            while (downloading)
                Application.DoEvents();

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
            var releaseFolder = Utils.GetVersionFolder(Utils.GetVersion(item), Settings.PathToInstalls);//.Filename));
            var installFolder = string.Format("{0}{1}", Settings.PathToInstalls, Utils.GetVersion(item));//.Filename));
            var destinationFolder = string.Format("{0}\\{1}", releaseFolder, Utils.GetVersion(item));//.Filename));
            try
            {
                if (!Directory.Exists(releaseFolder))
                    Directory.CreateDirectory(releaseFolder);
                Directory.Move(installFolder, destinationFolder);
            }
            catch
            {
                MessageBox.Show(string.Format("There was an error moving the installation ({0}) \r\n into the release folder ({1}) \r\n you will need to move it manually.", Utils.GetVersion(item), releaseFolder), "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        public static string[] Customizations
        {
            get
            {
                var retVal = new List<string>();
                var files = System.IO.Directory.GetFiles(Settings.CustomizationPath, "*.zip");
                foreach (var file in files)
                {
                    var zip = Ionic.Zip.ZipFile.Read(file);
                    if (zip.Entries.Where(z => z.FileName.ToLower().Contains("project.xml")).Count() > 0)
                        retVal.Add(file);
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
}