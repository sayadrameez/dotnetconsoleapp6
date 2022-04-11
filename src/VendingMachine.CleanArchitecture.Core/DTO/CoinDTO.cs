namespace VendingMachine.CleanArchitecture.Core.DTO;

public class CoinDTO
{
  public decimal _totalInserted;
  public decimal _totalFiveCents;
  public decimal _totalTenCents;
  public decimal _totalTwentyCents;
  public decimal _totalFiftyCents;
  public decimal _totalOneEuros;
  public decimal _totalTwoEuros;

  public decimal TotalInserted { get => _totalInserted; set => _totalInserted = value; }
  public decimal TotalFiveCents { get => _totalFiveCents; set => _totalFiveCents = value; }
  public decimal TotalTenCents { get => _totalTenCents; set => _totalTenCents = value; }
  public decimal TotalTwentyCents { get => _totalTwentyCents; set => _totalTwentyCents = value; }
  public decimal TotalFiftyCents { get => _totalFiftyCents; set => _totalFiftyCents = value; }
  public decimal TotalOneEuros { get => _totalOneEuros; set => _totalOneEuros = value; }
  public decimal TotalTwoEuros { get => _totalTwoEuros; set => _totalTwoEuros = value; }

}
