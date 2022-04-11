namespace VendingMachine.CleanArchitecture.Core.DTO;

public class SelectProductDTO
{
  public int SelectedProduct { get; set; }
  public CoinDTO CoinDTO { get; set; }
  public ProductsDTO ProductsDTO { get; set; }

}
