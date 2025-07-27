using Microsoft.Extensions.DependencyInjection;
using PurcellPartners.Common.Application;

var services = new ServiceCollection();
services.AddTransient<IApplication, Application>();
var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<IApplication>();
bool result = app.TestMethod();
Console.WriteLine($"TestMethod returned: {result}");

Console.ReadLine();