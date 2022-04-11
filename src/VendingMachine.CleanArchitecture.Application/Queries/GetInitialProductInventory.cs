using MediatR;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Queries;

public class GetInitialProductInventory : IRequest<ProductsDTO>
{
  public string? lang { get; set; }
}
