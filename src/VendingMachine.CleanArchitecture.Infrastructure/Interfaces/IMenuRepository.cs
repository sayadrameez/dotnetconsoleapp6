using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

public interface IProductsRepository
{
  Task<ProductsDTO> GetInitialProductInventory(string lang);

}
