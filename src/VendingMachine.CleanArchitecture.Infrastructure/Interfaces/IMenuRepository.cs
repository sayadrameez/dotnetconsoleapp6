using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

public interface IProductsRepository
{
  Task<ProductsDTO> GetInitialProductInventory(string lang);

}
