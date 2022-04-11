namespace VendingMachine.CleanArchitecture.Core.DTO;

public class SelectProductResponseDTO
{
  public bool IsCoinValid { get; set; }
  public bool IsProductValid { get; set; }
  public SelectProductDTO SelectedProducts { get; set; }
}
