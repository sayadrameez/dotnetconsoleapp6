using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
  public async Task<ProductsDTO> GetInitialProductInventory(string lang)
  {
    var productsdto = new ProductsDTO()
    {
      Products = new SortedDictionary<int, ProductDTO>()
    };
    //Currently hardcoded - need to change to csv
    var productdto = new ProductDTO()
    {
      Name = "cola",
      Price = 1,
      Inventory = 15,
      Sequence = 1
    };
    var productdto2 = new ProductDTO()
    {
      Name = "chips",
      Price = 0.50m,
      Inventory = 10,
      Sequence = 2
    };
    var productdto3 = new ProductDTO()
    {
      Name = "candy",
      Price = 0.65m,
      Inventory = 20,
      Sequence = 3
    };
    productsdto.Products.Add(1, productdto);
    productsdto.Products.Add(2, productdto2);
    productsdto.Products.Add(3, productdto3);


    return await Task.FromResult(productsdto).ConfigureAwait(false);
  }
}
