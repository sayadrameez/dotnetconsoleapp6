using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class CheckCoinDTO
{
  public  bool IsValidSelection { get; set; }
  public CoinDTO Coin { get; set; }
}
