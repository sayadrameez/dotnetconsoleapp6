using FluentValidation;
using MediatR;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Interfaces;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;

namespace VendingMachine.CleanArchitecture.Application.Handlers;

internal class NewCoinAddedCommandHandler : IRequestHandler<NewCoinAddedCommand, CoinDTO>

{
  private readonly IMediator _mediator;
  private readonly ICoinService _coinService;
  private readonly IValidator<NewCoinAddedCommand> _newcoinValidator;


  public NewCoinAddedCommandHandler(IMediator mediator, ICoinService coinService, IValidator<NewCoinAddedCommand> validator)
  {
    _mediator = mediator;
    _coinService = coinService;
    _newcoinValidator = validator;
  }
  public async Task<CoinDTO> Handle(NewCoinAddedCommand request, CancellationToken cancellationToken)
  {
    _newcoinValidator.ValidateAndThrow(request);
    var response = await _coinService.AddNewCoin(request.Coin, request.CoinValue);
    // For notifying other subscribers
    var newCoinAddedEvent = new NewCoinAddedEvent(request.Coin, request.CoinValue);
    await _mediator.Publish(newCoinAddedEvent);
    return response;
  }
}
