using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppSettingsAdvanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //First Way : Read Only
            System.Collections.Specialized.NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string Setting1_index = appSettings[0];
            string Setting1_key = appSettings["Setting1"];
            string Setting2_index = appSettings[1];
            string Setting2_key = appSettings["Setting2"];

            if (!Setting1_index.Equals(Setting1_key) || (!Setting2_index.Equals(Setting2_key)))
            {
                throw new Exception();
            }

            //Second Way : Read & Write

            //Roaming. This folder (%APPDATA%) contains data that can move with your user profile from PC to PC—like when you’re on a domain—because this data has the ability to sync with a server. For example, if you sign in to a different PC on a domain, your web browser favorites or bookmarks will be available.
            //Local. This folder (%LOCALAPPDATA%) contains data that can't move with your user profile. This data is typically specific to a PC or too large to sync with a server. For example, web browsers usually store their temporary files here.
            //LocalLow. This folder (%APPDATA%\..\LOCALLOW) contains data that can't move, but also has a lower level of access. For example, if you're running a web browser in a protected or safe mode, the app will only be able access data from the LocalLow folder.

            //To get the Configuration object that applies to all users(the configuration file is in the same directory as the application), set userLevel to None.
            //To get the local Configuration object that applies to the current user(%LOCALAPPDATA%), set userLevel to PerUserRoamingAndLocal.
            //To get the roaming Configuration object that applies to the current user(%APPDATA%), set userLevel to PerUserRoaming.
            System.Configuration.ConfigurationUserLevel where=System.Configuration.ConfigurationUserLevel.None;

            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(where);

            //Read AppSettings as KeyValueConfigurationCollection
            System.Configuration.KeyValueConfigurationCollection configurationCollection = config.AppSettings.Settings;
            foreach (string key in configurationCollection.AllKeys)
            {
                string get = configurationCollection[key].Value;
            }
            System.Configuration.KeyValueConfigurationElement configurationElement = configurationCollection["Setting1"];
            Setting1_key = configurationElement.Value;
            configurationElement = configurationCollection["Setting2"];
            Setting2_key = configurationElement.Value;

            //Write AppSettings by Adding new key
            config.AppSettings.Settings.Add("MyVariable", "MyValue");
            configurationElement = configurationCollection["MyVariable"];
            string MyVariable_key = configurationElement.Value;
            config.Save();

            //Write AppSettings by Editing existing key
            config.AppSettings.Settings["Setting2"].Value = "adasdasadsads";
            config.Save();

            //Write AppSetting by Removing existing key
            config.AppSettings.Settings.Remove("MyVariable");
            config.Save();
        }
    }
}
