using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

public interface IMenuRepository
{
  Task<string?> GetValuefromResource(string resourcetype,string key, string lang);

}
