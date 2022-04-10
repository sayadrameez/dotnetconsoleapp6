using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class RecalculateInventoryDTO
{
  public bool IsValidSelection { get; set; }
  public ProductsDTO Products { get; set; }
}
