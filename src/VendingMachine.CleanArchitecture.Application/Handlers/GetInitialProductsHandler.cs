using AutoMapper;
using MediatR;
using VendingMachine.CleanArchitecture.Application.Queries;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Application.Handlers;

public class GetInitialProductsHandler : IRequestHandler<GetInitialProductInventory, ProductsDTO>
{
  private readonly IProductsRepository _productsRepository;
  private readonly IMapper _mapper;

  public GetInitialProductsHandler(IProductsRepository productRepository, IMapper mapper)
  {
    _productsRepository = productRepository;
    _mapper = mapper;
  }


  public async Task<ProductsDTO> Handle(GetInitialProductInventory request, CancellationToken cancellationToken)
  {
    // Keep the business logic contained within application boundary
    if (request.lang == null) request.lang = "en";
    var resp = await _productsRepository.GetInitialProductInventory(request.lang);

    return resp;
  }
}
