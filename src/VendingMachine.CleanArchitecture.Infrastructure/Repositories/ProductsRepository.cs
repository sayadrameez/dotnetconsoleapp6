using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CleanArchitecture.Infrastructure.Helpers;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
  public async Task<string?> GetValuefromResource(string resourcetype, string key, string lang)
  {
    var value = ResourceManagerHelper.GetValue(resourcetype, key, lang);
    return await Task.FromResult(value).ConfigureAwait(false);
  }



}
