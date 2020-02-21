using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AcuDevDeployer.Objects
{
    public class Instance
    {
        private string name;
        public string Name 
        { 
            get 
            {
                return name;
            }
            set 
            {
                name = value;
                _webConfig = null;
            } 
        }
        public string connectionString
        {
            get
            {
                //Configuration config = webConfig;
                var test = webConfig?.ConnectionStrings?.ConnectionStrings?.GetEnumerator();
                if (test != null)
                {
                    while (test?.Current == null || ((ConnectionStringSettings)test.Current)?.Name != "ProjectX")
                        if (!test.MoveNext())
                            break;
                    ConnectionStringSettings item = (ConnectionStringSettings)test.Current;
                    if (item.Name != "ProjectX")
                        return "";
                    else
                        return item.ConnectionString;
                }
                return "";
            }
        }
        public string vdir
        {
            get
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Acumatica ERP");
                var retVal = key?.OpenSubKey(Name);
                return retVal.GetValue("VirtDirName").ToString();
            }
        }
        public string siteVersion
        {
            get
            {
                string retVal = "";
                //Configuration config = webConfig();
                if (webConfig.AppSettings.Settings.AllKeys.Contains("Version"))
                    retVal = webConfig.AppSettings.Settings["Version"].Value;
                return retVal;
            }
        }
        private Configuration _webConfig;
        public Configuration webConfig
        {
            get
            {
                if (_webConfig == null)
                {
                    if (File.Exists(ErpPath + @"web.config"))
                    {
                        var configFile = new FileInfo(ErpPath + @"web.config");
                        var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
                        var wcfm = new WebConfigurationFileMap();
                        wcfm.VirtualDirectories.Add("/", vdm);
                        _webConfig = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
                    }
                }
                return _webConfig;
            }
        }
        private string ErpPath
        {
            get
            {
                var path = string.Format(@"{0}{1}\site\", Settings.PathToAcumatica, Name);
                if(!Directory.Exists(path))
                {
                    try
                    {
                        var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Acumatica ERP");
                        var retVal = key?.OpenSubKey(Name);
                        path = retVal?.GetValue("Path").ToString();
                    }
                    catch { }
                }
                return path;
            }
        }
        public void UpdateWebConfig(DevOptions options)
        {
            //var config = webConfig;
            foreach (var item in options)
            {
                switch (item.Area)
                {
                    case "AppSettings":
                        try
                        {
                            if (webConfig.AppSettings.Settings.AllKeys.Contains(item.Name))
                                webConfig.AppSettings.Settings[item.Name].Value = item.Value;
                            else
                                webConfig.AppSettings.Settings.Add(item.Name, item.Value);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                        break;

                    case "compilation":
                        var element = (System.Web.Configuration.SystemWebSectionGroup)webConfig.GetSectionGroup("system.web");//.ElementInformation("compilation");
                        var comp = element.Compilation;
                        comp.GetType().GetProperty(item.Name).SetValue(comp, Utils.MyConvert(item.Type, item.Value));
                        break;
                    default:
                        break;
                }
            }
            webConfig.Save();
        }

    }
}
