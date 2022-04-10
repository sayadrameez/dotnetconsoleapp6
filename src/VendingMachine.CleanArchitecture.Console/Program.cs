// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.CleanArchitecture.Console;
using VendingMachine.CleanArchitecture.Console.Startup;
// Load initial data along with dependencies
await Startup.RegisterModules(args);
