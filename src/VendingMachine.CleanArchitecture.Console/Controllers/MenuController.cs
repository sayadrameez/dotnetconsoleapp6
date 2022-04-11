using MediatR;
using VendingMachine.CleanArchitecture.Application.Queries;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Console.Controllers;

public class MenuController : BaseController
{
  private readonly IMediator _mediator;
  private readonly IMenuRepository _menuRepository;
  public MenuController(IMediator mediator, IMenuRepository menuRepository) : base(mediator)
  {
    _mediator = mediator;
    _menuRepository = menuRepository;
  }
  /// <summary>
  /// Get the first menu to be displayed
  /// </summary>
  /// <param name="lang">let application handle the business logic for null scenario</param>
  /// <returns></returns>
  public async Task<WelcomeMenuDTO> GetWelcomeMenu(string? lang = null)
  {
    var result = await _mediator.Send(new GetWelcomeMenuQuery() { lang = lang });

    return result;
  }

  public async Task<string?> GetDisplayMessage(string resourcetype, string key, string lang)
  {
    var result = await _menuRepository.GetValuefromResource(resourcetype, key, lang);

    return result;
  }

}
