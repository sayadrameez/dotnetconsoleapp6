using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Application.Interfaces;

public interface ICoinService
{
  public Task<CoinDTO> AddNewCoin(CoinDTO coinDTO, decimal coinValue);
  public Task<CheckCoinDTO> CheckCoinSelection(SelectProductCommand request);
  public Task<CoinDTO> RecalculateCoins(SelectProductCommand request);
}
