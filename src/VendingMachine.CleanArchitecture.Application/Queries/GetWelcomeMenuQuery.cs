using MediatR;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Queries;

public class GetWelcomeMenuQuery : IRequest<WelcomeMenuDTO>
{
  public string? lang { get; set; }
}
