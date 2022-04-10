using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.SharedKernel;

namespace VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;

public class NewCoinAddedEvent : BaseDomainEvent
{
  public CoinDTO _coinDTO { get; set; }
  public decimal _newCoinValue { get; set; }


  public NewCoinAddedEvent(CoinDTO coinDTO, decimal newCoinValue)
  {
    _coinDTO = coinDTO;
    _newCoinValue = newCoinValue;
  }
}
