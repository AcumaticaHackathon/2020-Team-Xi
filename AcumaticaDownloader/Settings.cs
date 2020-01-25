using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcumaticaDeployer
{
    public static class Settings
    {
        private static Configuration config;
        private static void InitSettings()
        {
            if (!File.Exists(Application.StartupPath + @"\settings."))
                File.Create(Application.StartupPath + @"\settings.");
            config = ConfigurationManager.OpenExeConfiguration(Application.StartupPath + @"\settings.");
        }
        public static string AcumaticaS3Url
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("AcumaticaS3Url"))
                {
                    var retval = config.AppSettings.Settings["AcumaticaS3Url"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Properties.Settings.Default.AcumaticaS3Url;
                    return retval;
                }
                return Properties.Settings.Default.AcumaticaS3Url;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("AcumaticaS3Url"))
                {
                    config.AppSettings.Settings["AcumaticaS3Url"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("AcumaticaS3Url", value);
                }
            }
        }
        public static string DefaultDBUser
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBUser"))
                {
                    var retval = config.AppSettings.Settings["DefaultDBUser"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Properties.Settings.Default.DefaultDBUser;
                    return retval;
                }
                return Properties.Settings.Default.DefaultDBUser;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBUser"))
                {
                    config.AppSettings.Settings["DefaultDBUser"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("DefaultDBUser", value);
                }
            }
        }
        public static string DefaultDBServer
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBServer"))
                {
                    var retval = config.AppSettings.Settings["DefaultDBServer"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Properties.Settings.Default.DefaultDBServer;
                    return retval;
                }
                return Properties.Settings.Default.DefaultDBServer;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBServer"))
                {
                    config.AppSettings.Settings["DefaultDBServer"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("DefaultDBServer", value);
                }
            }
        }

        public static string DefaultDBPassword
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBPassword"))
                {
                    var retval = config.AppSettings.Settings["DefaultDBPassword"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Properties.Settings.Default.DefaultDBPassword;
                    return retval;
                }
                return Properties.Settings.Default.DefaultDBPassword;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("DefaultDBPassword"))
                {
                    config.AppSettings.Settings["DefaultDBPassword"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("DefaultDBPassword", value);
                }
            }
        }
        public static string PathToInstalls
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("PathToInstalls"))
                {
                    var retval = config.AppSettings.Settings["PathToInstalls"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Application.StartupPath;
                    return retval;
                }
                return Application.StartupPath;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("PathToInstalls"))
                {
                    config.AppSettings.Settings["PathToInstalls"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("PathToInstalls", value);
                }
            }
        }
        public static string PathToAcumatica
        {
            get
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("PathToAcumatica"))
                {
                    var retval = config.AppSettings.Settings["PathToAcumatica"].Value;
                    if (string.IsNullOrWhiteSpace(retval))
                        retval = Application.StartupPath;
                    return retval;
                }
                return Application.StartupPath;
            }
            set
            {
                if (config == null)
                    InitSettings();
                if (config.AppSettings.Settings.AllKeys.Contains("PathToAcumatica"))
                {
                    config.AppSettings.Settings["PathToAcumatica"].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add("PathToAcumatica", value);
                }
            }
        }

        public static void SaveSettings()
        {
            if (config == null)
                InitSettings();
            config.Save(ConfigurationSaveMode.Minimal, true);
        }


    }
}
