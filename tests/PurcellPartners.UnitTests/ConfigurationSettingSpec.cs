using FluentAssertions;
using PurcellPartners.Common.ConfigurationSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.UnitTests
{
    public class ConfigurationSettingSpec
    {
        [Fact]
        public void ConfigurationSettingShouldHaveCorrectProperties()
        {
            var type = typeof(ConfigurationSetting);
            var keyProperty = type.GetProperty("Key");
            var valueProperty = type.GetProperty("Value");

            keyProperty.Should().NotBeNull();
            keyProperty.PropertyType.Should().Be(typeof(string));
            valueProperty.Should().NotBeNull();
            valueProperty.PropertyType.Should().Be(typeof(string));
        }

    }
}