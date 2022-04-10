using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Hosting;
using VendingMachine.CleanArchitecture.Console.Controllers;
using VendingMachine.CleanArchitecture.Console.Validators;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Console;

public class ConsoleView : IHostedService
{
  private readonly MenuController _menuController;
  private readonly CoinController _coinController;
  private readonly ProductController _productController;


  public ConsoleView(MenuController menuController, CoinController coinController, ProductController productController)
  {
    _menuController = menuController;
    _coinController = coinController;
    _productController = productController;
  }


  public async Task StartAsync(CancellationToken cancellationToken)
  {
    //Since it is the first call , create a new coin DTO with 0 total
    var initialCoinDTO = new CoinDTO();
    //set inital language as English
    var lang = "en";
    var initialProducts = await _productController.GetInitialInventory(lang);
    while (true)
    {
      var msg = await _menuController.GetDisplayMessage("Menu", "INSERT", lang);
      System.Console.WriteLine(Environment.NewLine);
      if (initialCoinDTO.TotalInserted == 0)
        System.Console.WriteLine(msg);
      // Read command
      var input = System.Console.ReadLine();
      //Determine the input and take next action
      var resp = await DetermineAction(input, initialCoinDTO, lang, initialProducts);
      lang = await DetermineResponse(resp, initialCoinDTO, lang, initialProducts);

    }
  }
  //TODO: breakup into smaller classes
  //TODO: language needs to be set in a context rather than a variable
  private async Task<string> DetermineResponse(ConsoleViewDTO resp, CoinDTO initialCoinDTO, string lang, ProductsDTO initialProducts)
  {
    switch (resp.action)
    {
      case "enter":
        var msg = await _menuController.GetDisplayMessage("DisplayMessage", "AMOUNT", lang);

        System.Console.WriteLine($"{msg} {initialCoinDTO.TotalInserted}");
        break;

      case "show":
        foreach (var product in initialProducts.Products)
        {
          var leftinventorymsg = $"{product.Value.Inventory} LEFT";
          if (product.Value.Inventory == 0)
            leftinventorymsg = "SOLD OUT";
          System.Console.WriteLine($"{product.Value.Name} {product.Value.Price} - {leftinventorymsg}");

        }
        break;
      case "select":
        break;
      case "return":
        break;
      case "language":
        lang = resp.lang;
        break;
      default:
        System.Console.WriteLine("Invalid input");
        break;
    }
    return lang;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    System.Console.WriteLine("Stopped");
    return Task.CompletedTask;
  }

  private async Task<ConsoleViewDTO> DetermineAction(string? input, CoinDTO coinDTO, string lang, ProductsDTO initialProducts)
  {
    var consoleviewValidator = new ConsoleViewValidator();
    if (string.IsNullOrWhiteSpace(input))
      return null;
    var inputs = input.Split(' ');
    var consoleviewDTO = new ConsoleViewDTO()
    {
      completeinput = input,
      action = inputs[0].Trim().ToLower(),
      value = inputs.Length > 1 ? inputs[1].Trim() : null,
      lang = lang
    };
    var validationResult = await consoleviewValidator.ValidateAsync(consoleviewDTO);

    switch (inputs[0].Trim().ToLower())
    {
      case "enter":
        consoleviewDTO.valueAmount = Convert.ToDecimal(consoleviewDTO.value);
        coinDTO = await _coinController.AddNewCoin(consoleviewDTO.valueAmount.Value, coinDTO, lang);
        consoleviewDTO.Coin = coinDTO;
        break;

      case "show":

        break;
      case "select":
        consoleviewDTO.valueAmount = Convert.ToInt32(consoleviewDTO.value);

        var productresp = await _productController.SelectProduct(Convert.ToInt32(consoleviewDTO.valueAmount), lang, coinDTO, initialProducts);
        consoleviewDTO.Coin = coinDTO = productresp.SelectedProducts.CoinDTO;
        consoleviewDTO.Products = initialProducts = productresp.SelectedProducts.ProductsDTO;
        break;
      case "return":
        break;
      case "language":
        lang = consoleviewDTO.value.Trim().ToLower();
        consoleviewDTO.lang = lang;
        break;
      default:
        System.Console.WriteLine("Invalid input");
        break;
    }
    return consoleviewDTO;
  }
}
