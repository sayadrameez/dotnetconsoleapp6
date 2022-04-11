using FluentValidation;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

namespace VendingMachine.CleanArchitecture.Application.Validators;

public class NewCoinValidator : AbstractValidator<NewCoinAddedCommand>
{
  public NewCoinValidator(IMenuRepository menuRepository)
  {

    //RuleFor(x => x.CoinValue)      
    //    .Equal(0.01m)
    //    .WithMessage(x =>
    //    {
    //      var msg = menuRepository.GetValuefromResource("DisplayMessage", "INVALID01CENT", x.Lang).Result;

    //      return msg;
    //    });
    //RuleFor(x => x.CoinValue)
    //    .Equal(0.02m)
    //    .WithMessage(x =>
    //    {
    //      var msg = menuRepository.GetValuefromResource("DisplayMessage", "INVALID02CENT", x.Lang).Result;

    //      return msg;
    //    });
  }
}
