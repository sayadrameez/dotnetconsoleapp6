using MediatR;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Commands;

public class NewCoinAddedCommand : IRequest<CoinDTO>
{
  public CoinDTO Coin { get; set; }
  public decimal CoinValue { get; set; }
  public string Lang { get; set; }
}
