using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Application.Interfaces;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Infrastructure.Extensions;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Application.Services;

public class CoinService : ICoinService
{
  private readonly IMenuRepository _menuRepository;
  public CoinService(IMenuRepository menuRepository)
  {
    _menuRepository = menuRepository;
  }
  public async Task<CoinDTO> AddNewCoin(CoinDTO coinDTO, decimal coinValue)
  {
    switch (coinValue)
    {
      case 0.05m:
        InterlockedExtensions.Add(ref coinDTO._totalFiveCents, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      case 0.10m:
        InterlockedExtensions.Add(ref coinDTO._totalTenCents, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      case 0.20m:
        InterlockedExtensions.Add(ref coinDTO._totalTwentyCents, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      case 0.50m:
        InterlockedExtensions.Add(ref coinDTO._totalFiftyCents, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      case 1:
        InterlockedExtensions.Add(ref coinDTO._totalOneEuros, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      case 2:
        InterlockedExtensions.Add(ref coinDTO._totalTwoEuros, coinValue);
        InterlockedExtensions.Add(ref coinDTO._totalInserted, coinValue);

        break;
      default:
        break;
    }
    return await Task.FromResult(coinDTO).ConfigureAwait(false);
  }

  public async Task<CheckCoinDTO> CheckCoinSelection(SelectProductCommand request)
  {
    var resp = new CheckCoinDTO();
    var selectedprice = request.SelectProductDTO.ProductsDTO.Products[request.SelectProductDTO.SelectedProduct].Price;
    if (request.SelectProductDTO.CoinDTO.TotalInserted >= selectedprice)
      resp.IsValidSelection = true;
    return await Task.FromResult(resp).ConfigureAwait(false);
  }

  public async Task<CoinDTO> RecalculateCoins(SelectProductCommand request)
  {
    var selectedprice = request.SelectProductDTO.ProductsDTO.Products[request.SelectProductDTO.SelectedProduct].Price;
    var pricetobededucted = selectedprice;

    while (pricetobededucted > 0)
    {

      if (pricetobededucted >= 2 && request.SelectProductDTO.CoinDTO.TotalTwoEuros > 0)
      {
        //keeping it more explicit rather than the shorthand
        request.SelectProductDTO.CoinDTO.TotalTwoEuros = request.SelectProductDTO.CoinDTO.TotalTwoEuros - 2;
        pricetobededucted = pricetobededucted - 2;
      }
      else if (pricetobededucted >= 1 && request.SelectProductDTO.CoinDTO.TotalOneEuros > 0)
      {
        request.SelectProductDTO.CoinDTO.TotalOneEuros = request.SelectProductDTO.CoinDTO.TotalOneEuros - 1;
        pricetobededucted = pricetobededucted - 1;
      }
      else if (pricetobededucted >= 0.50m && request.SelectProductDTO.CoinDTO.TotalFiftyCents > 0)
      {
        request.SelectProductDTO.CoinDTO.TotalFiftyCents = request.SelectProductDTO.CoinDTO.TotalFiftyCents - 0.50m;
        pricetobededucted = pricetobededucted - 0.50m;
      }
      else if (pricetobededucted >= 0.20m && request.SelectProductDTO.CoinDTO.TotalTwoEuros > 0)
      {
        request.SelectProductDTO.CoinDTO.TotalTwentyCents = request.SelectProductDTO.CoinDTO.TotalTwentyCents - 0.20m;
        pricetobededucted = pricetobededucted - 0.20m;
      }
      else if (pricetobededucted >= 0.10m && request.SelectProductDTO.CoinDTO.TotalTenCents > 0)
      {
        request.SelectProductDTO.CoinDTO.TotalTenCents = request.SelectProductDTO.CoinDTO.TotalTenCents - 0.10m;
        pricetobededucted = pricetobededucted - 0.10m;
      }
      else if (pricetobededucted > 0)
      {
        //here is the tricky bit - needs implementing the exact change logic which means machine itself will have some initial coins
        var result = await _menuRepository.GetValuefromResource("DisplayMessage", "EXACTCHANGE", request.lang);
        throw new Exception(result);
      }

    }

    request.SelectProductDTO.CoinDTO.TotalInserted = request.SelectProductDTO.CoinDTO.TotalInserted - selectedprice;

    return await Task.FromResult(request.SelectProductDTO.CoinDTO).ConfigureAwait(false);
  }
}
