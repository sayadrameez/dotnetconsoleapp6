namespace VendingMachine.CleanArchitecture.Core.DTO;

public class RecalculateInventoryDTO
{
  public bool IsValidSelection { get; set; }
  public ProductsDTO Products { get; set; }
}
