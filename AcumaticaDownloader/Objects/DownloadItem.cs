using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaDeployer
{
    public class DownloadItem
    {
        public Version AppVersion { get; set; }
        public string Version { get; set; }
        public string Filename { get; set; }
        public bool Preview { get; set; }
        public bool Downloaded { get; set; }
        public bool InProgress { get; set; }
        public override string ToString()
        {
            return Filename + (Downloaded?" - Done":(InProgress?" - Processing":""));
        }
    }
}
