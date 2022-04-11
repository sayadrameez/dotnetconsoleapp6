using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using VendingMachine.CleanArchitecture.Application.Interfaces;
using VendingMachine.CleanArchitecture.Application.Queries;
using VendingMachine.CleanArchitecture.Application.Services;
using VendingMachine.CleanArchitecture.Console.Controllers;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;
using VendingMachine.CleanArchitecture.Infrastructure.Repositories;
using Module = Autofac.Module;

namespace VendingMachine.CleanArchitecture.Console;

public class StartupModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    RegisterCommonDependencies(builder);
  }

  private static void RegisterCommonDependencies(ContainerBuilder builder)
  {
    //builder.RegisterGeneric(typeof(EfRepository<>))
    //    .As(typeof(IRepository<>))
    //    .As(typeof(IReadRepository<>))
    //    .InstancePerLifetimeScope();

    //builder
    //    .RegisterType<Mediator>()
    //    .As<IMediator>()
    //    .InstancePerLifetimeScope();


    //builder.Register<ServiceFactory>(context =>
    //{
    //  var c = context.Resolve<IComponentContext>();
    //  return t => c.Resolve(t);
    //});

    builder.RegisterType<MenuController>().AsSelf();
    builder.RegisterType<CoinController>().AsSelf();
    builder.RegisterType<ProductController>().AsSelf();

    builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerLifetimeScope();
    builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();

    builder.RegisterType<CoinService>().As<ICoinService>().InstancePerLifetimeScope();
    builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

    builder.RegisterMediatR(typeof(Program).Assembly);
    builder.RegisterMediatR(typeof(GetWelcomeMenuQuery).Assembly);



    //var mediatrOpenTypes = new[]
    //{
    //            typeof(IRequestHandler<,>),
    //            typeof(IRequestExceptionHandler<,,>),
    //            typeof(IRequestExceptionAction<,>),
    //            typeof(INotificationHandler<>),
    //        };

    //foreach (var mediatrOpenType in mediatrOpenTypes)
    //{
    //  builder
    //  .RegisterAssemblyTypes(_assemblies)
    //  .AsClosedTypesOf(mediatrOpenType)
    //  .AsImplementedInterfaces();
    //}

  }
}
