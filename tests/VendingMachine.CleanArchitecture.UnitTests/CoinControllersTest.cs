//using VendingMachine.CleanArchitecture.Core.Interfaces;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;
//using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Handlers;
using Autofac.Extras.Moq;
using MediatR;
using Moq;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Handlers;
using VendingMachine.CleanArchitecture.Console.Controllers;
using VendingMachine.CleanArchitecture.Core.DTO;
using Xunit;

namespace VendingMachine.CleanArchitecture.UnitTests.Core.Handlers;

public class CoinControllersTest
{


  [Fact]
  public async Task Test()
  {
    using (var mock = AutoMock.GetLoose())
    {
      // The AutoMock class will inject a mock IDependency
      // into the SystemUnderTest constructor
      var mediator = new Mock<IMediator>();
      mediator
    .Setup(m => m.Send(It.IsAny<NewCoinAddedCommand>(), It.IsAny<CancellationToken>()))
    .ReturnsAsync(new CoinDTO()) //<-- return Task to allow await to continue
    .Verifiable("Notification was not sent.");
      var coinController = new CoinController(mediator.Object);
      var resp = await coinController.AddNewCoin(1, new CoinDTO(), "en");
      //var controllermock = new Mock<CoinController>(mediator);
      //controllermock.Setup(x=> x.AddNewCoin(1,new CoinDTO(),"en")).Returns()
      //var sut = mock.Create<CoinController>();

      //var resp = await sut.AddNewCoin(1, new CoinDTO(), "en");
      var mockController = mock.Create<NewCoinAddedCommandHandler>();
      var mockCommand = mock.Create<NewCoinAddedCommand>();
      mockCommand.Coin = new CoinDTO() { TotalOneEuros = 1, TotalInserted = 1 };
      mockCommand.Lang = "en";
      mockCommand.CoinValue = 1;

      var resp2 = await mockController.Handle(mockCommand, It.IsAny<CancellationToken>());
    }
  }
}
