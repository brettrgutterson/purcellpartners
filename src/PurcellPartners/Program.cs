using Microsoft.Extensions.DependencyInjection;
using PurcellPartners.Common.Application;
using PurcellPartners.Common.ConfigurationSetting;

var services = new ServiceCollection();

services.AddSingleton<ConfigurationSettingManager>();
services.AddTransient<IApplication, Application>();

var serviceProvider = services.BuildServiceProvider();

var _Application = serviceProvider.GetRequiredService<IApplication>();

_Application.Execute();