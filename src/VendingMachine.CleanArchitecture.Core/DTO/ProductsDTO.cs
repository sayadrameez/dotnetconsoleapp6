﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Core.DTO;

public class ProductsDTO
{
  public SortedDictionary<int, ProductDTO> Products { get; set; }

}
