using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ConfigurationSetting
{
    /// <summary>
    /// A configuration setting is used to hold a key/value pair
    /// </summary>
    public class ConfigurationSetting
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
    }
}