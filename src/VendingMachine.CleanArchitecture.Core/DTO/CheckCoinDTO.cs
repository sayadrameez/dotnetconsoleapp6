namespace VendingMachine.CleanArchitecture.Core.DTO;

public class CheckCoinDTO
{
  public bool IsValidSelection { get; set; }
  public CoinDTO Coin { get; set; }
}
