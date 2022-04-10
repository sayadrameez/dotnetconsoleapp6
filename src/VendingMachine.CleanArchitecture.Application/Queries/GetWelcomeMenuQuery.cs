using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Queries;

public class GetWelcomeMenuQuery : IRequest<WelcomeMenuDTO>
{
  public string? lang {get; set;}
}
