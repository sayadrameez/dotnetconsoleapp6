using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VendingMachine.CleanArchitecture.Console.Controllers;

namespace VendingMachine.CleanArchitecture.Console;

public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;
  private readonly MenuController _menuController;

  public Worker(ILogger<Worker> logger, MenuController menuController)
  {
    _logger = logger;
    _menuController = menuController;
  }

  /// <summary>
  /// Worker service acts as orchestrator for end user key inputs and display
  /// </summary>
  /// <param name="stoppingToken"></param>
  /// <returns></returns>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    //First run execute hence default to en culture
    var resp = await _menuController.GetWelcomeMenu();
    System.Console.WriteLine(resp.WelcomeMessage);
  }
}
