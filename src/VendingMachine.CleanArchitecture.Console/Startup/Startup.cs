using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using MediatR.Pipeline;
using MediatR;
using MediatR.Wrappers;
using AutoMapper;

using System.Reflection;
using FluentValidation;
using VendingMachine.CleanArchitecture.Application.Validators;
using VendingMachine.CleanArchitecture.Application.Commands;

namespace VendingMachine.CleanArchitecture.Console.Startup;

internal static class Startup
{
  public static ServiceProvider serviceProvider { get; set; }
  internal static async Task RegisterModules(string[] args)
  {
    var hostBuilder = Host.CreateDefaultBuilder(args);
    hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    hostBuilder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
      containerBuilder.RegisterModule(new StartupModule());
    });

    hostBuilder
           .ConfigureServices((hostContext, services) =>
           {
             services.AddHostedService<Worker>();
             //services.AddMediatR(Assembly.GetExecutingAssembly());
             //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
             //Auto Mapper
             services.AddHostedService<ConsoleView>();
             services.AddAutoMapper(cfg =>
             {
               cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
             });
             services.AddScoped<IValidator<NewCoinAddedCommand>, NewCoinValidator>();
             serviceProvider = services.BuildServiceProvider(true);
           });


    await hostBuilder.Build().RunAsync();
    //await hostBuilder.RunConsoleAsync();
    //hostBuilder.Build();
  }

}
