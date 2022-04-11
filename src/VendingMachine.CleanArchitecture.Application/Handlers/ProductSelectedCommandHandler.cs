using FluentValidation;
using MediatR;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Interfaces;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Handlers;

internal class ProductSelectedCommandHandler : IRequestHandler<SelectProductCommand, SelectProductResponseDTO>

{
  private readonly IMediator _mediator;
  private readonly ICoinService _coinService;
  private readonly IProductService _productService;

  private readonly IValidator<NewCoinAddedCommand> _newcoinValidator;


  public ProductSelectedCommandHandler(IMediator mediator, ICoinService coinService, IValidator<NewCoinAddedCommand> validator, IProductService productService)
  {
    _mediator = mediator;
    _coinService = coinService;
    _newcoinValidator = validator;
    _productService = productService;
  }


  public async Task<SelectProductResponseDTO> Handle(SelectProductCommand request, CancellationToken cancellationToken)
  {
    var response = new SelectProductResponseDTO()
    {
      SelectedProducts = new SelectProductDTO()
    };
    response.SelectedProducts.CoinDTO = request.SelectProductDTO.CoinDTO;
    response.SelectedProducts.ProductsDTO = request.SelectProductDTO.ProductsDTO;

    var coinresp = await _coinService.CheckCoinSelection(request);
    response.IsCoinValid = coinresp.IsValidSelection;
    if (coinresp.IsValidSelection)
    {

      var prodresp = await _productService.RecalculateInventory(request);
      response.IsProductValid = prodresp.IsValidSelection;
      response.SelectedProducts.ProductsDTO = prodresp.Products;
      if (prodresp.IsValidSelection)
      {
        var coindedresp = await _coinService.RecalculateCoins(request);
        response.SelectedProducts.CoinDTO = coindedresp;

      }
    }
    else
    {

    }
    return response;
  }
}
