using MediatR;

namespace VendingMachine.CleanArchitecture.Console.Controllers
{

  public class BaseController
  {
    protected IMediator Mediator { get; private set; }
    public BaseController(IMediator mediator)
    {
      Mediator = mediator;
    }
  }
}
