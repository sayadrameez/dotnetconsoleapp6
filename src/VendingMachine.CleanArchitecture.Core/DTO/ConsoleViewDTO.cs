using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class ConsoleViewDTO
{
  public string? completeinput { get; set; }
  public string? action { get; set; }
  public string? value { get; set; }

  public decimal? valueAmount { get; set; }
  public string? lang { get; set; }
  public CoinDTO Coin { get; set; }
  public ProductsDTO Products { get; set; }

}
