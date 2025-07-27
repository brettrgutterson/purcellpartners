using Microsoft.Extensions.DependencyInjection;
using PurcellPartners.Common.Application;
using PurcellPartners.Common.ConfigurationSetting;
using PurcellPartners.Common.InputHandling;
using PurcellPartners.Common.OutputHandling;

var services = new ServiceCollection();

services.AddSingleton<ConfigurationSettingManager>();
services.AddTransient<IApplication, Application>();
services.AddSingleton<IOutputHandler, OutputHandler>();
services.AddSingleton<IInputHandler, InputHandler>();
services.AddSingleton<IOutputHandler,  OutputHandler>();

var serviceProvider = services.BuildServiceProvider();

var _Application = serviceProvider.GetRequiredService<IApplication>();

_Application.Execute();