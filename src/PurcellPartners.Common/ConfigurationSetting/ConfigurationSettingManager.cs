using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ConfigurationSetting
{
    /// <summary>
    /// Manages the configuration settings
    /// </summary>
    public class ConfigurationSettingManager
    {
        /// <summary>
        /// The list of configuration settings to use (would typically be stored in a DB)
        /// </summary>
        private IEnumerable<ConfigurationSetting> _ConfigurationSettings = new List<ConfigurationSetting>
        {
            new ConfigurationSetting { Key = "InputPrompt", Value = "Please enter the input list" },
            new ConfigurationSetting { Key = "EmptyInputDetected", Value = "Input not detected. Please try again" },
            new ConfigurationSetting { Key = "ProcessingStarted", Value = "Please wait while we process your request" },
            new ConfigurationSetting { Key = "InvalidInputDetected", Value = "Invalid input detected. Input must be a CSV list of integers" }
        };

        // Retrieve the value of a configuration setting via a key search 
        public string? GetValueByKey(string key) => _ConfigurationSettings.FirstOrDefault(x => x.Key == key)?.Value ?? null;
    }
}