using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Interfaces;

public interface IProductService
{
  public Task<RecalculateInventoryDTO> RecalculateInventory(SelectProductCommand request);
}
