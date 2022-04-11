using System.Globalization;
using System.Resources;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Infrastructure.Helpers;

public static class ResourceManagerHelper
{
  private static ResourceManager? _resourceManObj;
  private static ResourceManager ResourceManagerObj
  {
    get
    {
      if (object.Equals(null, _resourceManObj))
      {
        var temp = new ResourceManager("VendingMachine.CleanArchitecture.Core.Resources.Menu", typeof(WelcomeMenuDTO).Assembly);
        _resourceManObj = temp;
      }
      return _resourceManObj;
    }
  }

  private static ResourceManager? _displayMessageManObj;
  private static ResourceManager DisplayMessageManObj
  {
    get
    {
      if (object.Equals(null, _displayMessageManObj))
      {
        var temp = new ResourceManager("VendingMachine.CleanArchitecture.Core.Resources.DisplayMessages", typeof(WelcomeMenuDTO).Assembly);
        _displayMessageManObj = temp;
      }
      return _displayMessageManObj;
    }
  }

  internal static string? GetValue(string resourcetype, string key, string lang)
  {
    var cultureInfo = CultureInfo.GetCultureInfo(lang);
    switch (resourcetype)
    {
      case "DisplayMessage":
        return DisplayMessageManObj.GetString(key, cultureInfo);

      case "Menu":
        return ResourceManagerObj.GetString(key, cultureInfo);
      default:
        break;
    }
    return null;

  }
}
