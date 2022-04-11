using MediatR;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Commands;

public class SelectProductCommand : IRequest<SelectProductResponseDTO>
{
  public SelectProductDTO SelectProductDTO { get; set; }
  public string? lang { get; set; }
}
