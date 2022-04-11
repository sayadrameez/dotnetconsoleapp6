using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace VendingMachine.CleanArchitecture.IntegrationTests
{

  //public class SomeFixture : IDisposable
  //{
  //  private static IConfigurationRoot _configuration = null!;
  //  private static IServiceScopeFactory _scopeFactory = null!;
  //  //private static Checkpoint _checkpoint = null!;
  //  private static string? _currentUserId;
  //  public SomeFixture()
  //  {
  //    System.Console.WriteLine("SomeFixture ctor: This should only be run once");
  //    var builder = new ConfigurationBuilder()
  //       .SetBasePath(Directory.GetCurrentDirectory())
  //       .AddJsonFile("appsettings.json", true, true)
  //       .AddEnvironmentVariables();

  //    _configuration = builder.Build();

  //    var startup = new Startup(_configuration);

  //    var services = new ServiceCollection();

  //    services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
  //        w.EnvironmentName == "Development" &&
  //        w.ApplicationName == "CleanArchitecture.WebUI"));

  //    services.AddLogging();

  //    startup.ConfigureServices(services);

  //    // Replace service registration for ICurrentUserService
  //    // Remove existing registration
  //    var currentUserServiceDescriptor = services.FirstOrDefault(d =>
  //        d.ServiceType == typeof(ICurrentUserService));

  //    if (currentUserServiceDescriptor != null)
  //    {
  //      services.Remove(currentUserServiceDescriptor);
  //    }

  //    // Register testing version
  //    services.AddTransient(provider =>
  //        Mock.Of<ICurrentUserService>(s => s.UserId == _currentUserId));

  //    _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

  //    _checkpoint = new Checkpoint
  //    {
  //      TablesToIgnore = new[] { "__EFMigrationsHistory" }
  //    };

  //    //EnsureDatabase();
  //  }

  //  public void SomeMethod()
  //  {
  //    System.Console.WriteLine("SomeFixture::SomeMethod()");
  //  }

  //  public void Dispose()
  //  {
  //    System.Console.WriteLine("SomeFixture: Disposing SomeFixture");
  //  }
  //}
  public class CoinControllerTest //: SomeFixture,IDisposable
  {
    [Fact]
    public async Task Test()
    {
      //var writer = new WrappingWriter(Console.Out);
      //var mediator = BuildMediator(writer);

      //return Runner.Run(mediator, writer, "Autofac", testStreams: true);

      var output = new StringWriter();
      System.Console.SetOut(output);

      var input = new StringReader("Somebody");
      System.Console.SetIn(input);

      //VendingMachine.CleanArchitecture.Console.
      //Program.Main(new string[] { });

      //Assert.That(output.ToString(), Is.EqualTo(string.Format("What's your name?{0}Hello Somebody!!{0}", Environment.NewLine)));
    }

    

    //[OneTimeSetUp]
    //public void RunBeforeAnyTests()
    //{
     
    //}

    //private static void EnsureDatabase()
    //{
    //  using var scope = _scopeFactory.CreateScope();

    //  var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //  context.Database.Migrate();
    //}

    //private static IMediator BuildMediator(WrappingWriter writer)
    //{
    //  var builder = new ContainerBuilder();
    //  builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

    //  var mediatrOpenTypes = new[]
    //  {
    //        typeof(IRequestHandler<,>),
    //        typeof(IRequestExceptionHandler<,,>),
    //        typeof(IRequestExceptionAction<,>),
    //        typeof(INotificationHandler<>),
    //        typeof(IStreamRequestHandler<,>)
    //    };

    //  foreach (var mediatrOpenType in mediatrOpenTypes)
    //  {
    //    builder
    //        .RegisterAssemblyTypes(typeof(Ping).GetTypeInfo().Assembly)
    //        .AsClosedTypesOf(mediatrOpenType)
    //        // when having a single class implementing several handler types
    //        // this call will cause a handler to be called twice
    //        // in general you should try to avoid having a class implementing for instance `IRequestHandler<,>` and `INotificationHandler<>`
    //        // the other option would be to remove this call
    //        // see also https://github.com/jbogard/MediatR/issues/462
    //        .AsImplementedInterfaces();
    //  }

    //  builder.RegisterInstance(writer).As<TextWriter>();

    //  // It appears Autofac returns the last registered types first
    //  builder.RegisterGeneric(typeof(GenericStreamPipelineBehavior<,>)).As(typeof(IStreamPipelineBehavior<,>));

    //  builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    //  builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    //  builder.RegisterGeneric(typeof(RequestExceptionActionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    //  builder.RegisterGeneric(typeof(RequestExceptionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    //  builder.RegisterGeneric(typeof(GenericRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));
    //  builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
    //  builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    //  builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
    //  builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

    //  builder.Register<ServiceFactory>(ctx =>
    //  {
    //    var c = ctx.Resolve<IComponentContext>();
    //    return t => c.Resolve(t);
    //  });

    //  var container = builder.Build();

    //  // The below returns:
    //  //  - RequestPreProcessorBehavior
    //  //  - RequestPostProcessorBehavior
    //  //  - GenericPipelineBehavior
    //  //  - GenericStreamPipelineBehavior
    //  //  - RequestExceptionActionProcessorBehavior
    //  //  - RequestExceptionProcessorBehavior

    //  //var behaviors = container
    //  //    .Resolve<IEnumerable<IPipelineBehavior<Ping, Pong>>>()
    //  //    .ToList();

    //  var mediator = container.Resolve<IMediator>();

    //  return mediator;
    //}

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
