using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VendingMachine.CleanArchitecture.Application.Queries;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Application.Handlers;

public class GetWelcomeMenuHandler : IRequestHandler<GetWelcomeMenuQuery, WelcomeMenuDTO>
{
  private readonly IMenuRepository _menuRepository;
  private readonly IMapper _mapper;

  public GetWelcomeMenuHandler(IMenuRepository menuRepository, IMapper mapper)
  {
    _menuRepository = menuRepository;
    _mapper = mapper;
  }


  public async Task<WelcomeMenuDTO> Handle(GetWelcomeMenuQuery request, CancellationToken cancellationToken)
  {
    // Keep the business logic contained within application boundary
    if (request.lang == null) request.lang = "en";
    var msg = await _menuRepository.GetValuefromResource("Menu", "Welcome", request.lang);
    if (msg == null) msg = string.Empty;
    var resp = new WelcomeMenuDTO { WelcomeMessage = msg };

    return resp;
  }
}
