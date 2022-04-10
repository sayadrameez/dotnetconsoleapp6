using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class SelectProductResponseDTO
{
  public bool IsCoinValid { get; set; }
  public bool IsProductValid { get; set; }
  public SelectProductDTO SelectedProducts { get; set; }
}
