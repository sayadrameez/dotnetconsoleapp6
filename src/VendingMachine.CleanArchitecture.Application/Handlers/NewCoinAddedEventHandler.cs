using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;
using MediatR;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Core.ProjectAggregate.Handlers;

public class NewCoinAddedEventHandler : INotificationHandler<NewCoinAddedEvent>
{
  //Incase we need to update external systems or files
  private readonly ICoinRepository coinRepository;

  public NewCoinAddedEventHandler()
  {

  }


  public Task Handle(NewCoinAddedEvent newCoinAddedEvent, CancellationToken cancellationToken)
  {
    Guard.Against.Null(newCoinAddedEvent, nameof(newCoinAddedEvent));

    return Task.CompletedTask;
  }
}
