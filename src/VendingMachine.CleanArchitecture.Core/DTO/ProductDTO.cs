namespace VendingMachine.CleanArchitecture.Core.DTO;

public class ProductDTO
{
  public uint _inventory;

  public uint Sequence { get; set; }
  public uint Inventory { get => _inventory; set => _inventory = value; }
  public decimal Price { get; set; }
  public string Name { get; set; }

}
