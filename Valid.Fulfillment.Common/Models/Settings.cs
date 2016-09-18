using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valid.Fulfillment.Common.Models
{
    /// <summary>
    /// Configuration Settings Data Model
    /// </summary>
    public class Settings
    {
        private readonly Dictionary<string, string> _SettingsDictionary;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsDictionary"></param>
        public Settings(Dictionary<string, string> settingsDictionary)
        {
            _SettingsDictionary = settingsDictionary;
        }

        /// <summary>
        /// Configuration property to set the Database connection info
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _SettingsDictionary.ContainsKey("ConnectionString")
                    ? _SettingsDictionary["ConnectionString"]
                    : string.Empty;
            }
        }

        /// <summary>
        /// Configuration property to set the logo image location
        /// </summary>
        public string ImageUri
        {
            get
            {
                return _SettingsDictionary.ContainsKey("ImageUri")
                    ? _SettingsDictionary["ImageUri"]
                    : string.Empty;
            }
        }

        /// <summary>
        /// Configuration property to set the print csv location
        /// </summary>
        public string PrintPath
        {
            get
            {
                return _SettingsDictionary.ContainsKey("PrintPath")
                    ? _SettingsDictionary["PrintPath"]
                    : string.Empty;
            }
        }

        /// <summary>
        /// Configuration property to set the print csv location
        /// </summary>
        public string PrintFileName
        {
            get
            {
                return _SettingsDictionary.ContainsKey("PrintFileName")
                    ? _SettingsDictionary["PrintFileName"]
                    : string.Empty;
            }
        }

        /// <summary>
        /// Configuration property to enable fullscreen on startup
        /// </summary>
        public bool StartFullScreen
        {
            get
            {
                var value = _SettingsDictionary.ContainsKey("StartFullScreen")
                    ? _SettingsDictionary["StartFullScreen"]
                    : string.Empty;
                if (string.IsNullOrEmpty(value) || value != "true")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Configuration property to enable fullscreen on startup
        /// </summary>
        public bool AllowMultipleInstances
        {
            get
            {
                var value = _SettingsDictionary.ContainsKey("AllowMultipleInstances")
                    ? _SettingsDictionary["AllowMultipleInstances"]
                    : string.Empty;
                if (string.IsNullOrEmpty(value) || value != "true")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
