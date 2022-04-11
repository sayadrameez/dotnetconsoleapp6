using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Interfaces;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Services;

public class ProductService : IProductService
{

  public async Task<RecalculateInventoryDTO> RecalculateInventory(SelectProductCommand request)
  {
    var response = new RecalculateInventoryDTO();
    response.Products = request.SelectProductDTO.ProductsDTO;
    if (request.SelectProductDTO.ProductsDTO.Products[request.SelectProductDTO.SelectedProduct].Inventory > 0)
    {
      response.IsValidSelection = true;
      Interlocked.Decrement(ref response.Products.Products[request.SelectProductDTO.SelectedProduct]._inventory);

    }
    else
    {

      // inventory empty message

    }
    return await Task.FromResult(response).ConfigureAwait(false);
  }
}
