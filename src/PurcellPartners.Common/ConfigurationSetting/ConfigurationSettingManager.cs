using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ConfigurationSetting
{
    public class ConfigurationSettingManager
    {
        private IEnumerable<ConfigurationSetting> _ConfigurationSettings = new List<ConfigurationSetting>
        {
            new ConfigurationSetting { Key = "InputPrompt", Value = "Please enter the input list" },
            new ConfigurationSetting { Key = "EmptyInputDetected", Value = "Input not detected. Please try again" },
            new ConfigurationSetting { Key = "ProcessingStarted", Value = "Please wait while we process your request" }
        };

        public string? GetValueByKey(string key)
        {
            return _ConfigurationSettings.FirstOrDefault(x => x.Key == key)?.Value ?? null;
        }
    }
}