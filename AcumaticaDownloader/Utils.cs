using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AcumaticaDeployer
{
    public class Utils
    {
        private static bool _error;
        public static bool HasError
        { get { return _error; } }
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
                _error = false;
                return retVal;
            }
            catch
            {
                _error = true;
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
            req.DownloadFileAsync(new Uri(string.Format("{0}{1}", url, key)), filename);
            //var resp = req.GetResponse();
            //var str = resp.GetResponseStream();
            //var sr = new BinaryReader(str);
            //var retVal = new System.IO.MemoryStream(sr.ReadBytes((int)resp.ContentLength));
            //return retVal;

        }
    }
}
