using MediatR;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Queries;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Console.Controllers;

public class ProductController : BaseController
{
  private readonly IMediator _mediator;

  public ProductController(IMediator mediator) : base(mediator)
  {
    _mediator = mediator;
  }

  public async Task<ProductsDTO> GetInitialInventory(string lang)
  {
    var result = await _mediator.Send(new GetInitialProductInventory() { lang = lang });

    return result;
  }

  public async Task<SelectProductResponseDTO> SelectProduct(int selectedProduct, string lang, CoinDTO coinDTO, ProductsDTO productsDTO)
  {
    var result = await _mediator.Send(new SelectProductCommand()
    {
      lang = lang,
      SelectProductDTO = new SelectProductDTO()
      {
        CoinDTO = coinDTO,
        ProductsDTO = productsDTO,
        SelectedProduct = selectedProduct
      }
    });

    return result;
  }
}
