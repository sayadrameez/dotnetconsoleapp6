//using VendingMachine.CleanArchitecture.Core.Interfaces;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Handlers;
using Autofac.Extras.Moq;
using Moq;
using VendingMachine.CleanArchitecture.Console.Controllers;
using VendingMachine.CleanArchitecture.Core.DTO;
using Xunit;

namespace VendingMachine.CleanArchitecture.UnitTests.Core.Handlers;

public class ControllersTest
{


  [Fact]
  public async Task Test()
  {
    using (var mock = AutoMock.GetLoose())
    {
      // The AutoMock class will inject a mock IDependency
      // into the SystemUnderTest constructor
      var sut = mock.Create<CoinController>();
      var resp = await sut.AddNewCoin(1, new CoinDTO(), "en");
    }
  }
}
