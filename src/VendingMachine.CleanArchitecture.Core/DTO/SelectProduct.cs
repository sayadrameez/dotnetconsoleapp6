using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class SelectProductDTO
{
  public int SelectedProduct { get; set; }
  public CoinDTO CoinDTO { get; set; }
  public ProductsDTO  ProductsDTO { get; set; }

}
