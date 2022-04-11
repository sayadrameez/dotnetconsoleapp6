using FluentValidation;
using VendingMachine.CleanArchitecture.Core.DTO;

namespace VendingMachine.CleanArchitecture.Console.Validators;


public class ConsoleViewValidator : AbstractValidator<ConsoleViewDTO>
{
  public ConsoleViewValidator()
  {
    //RuleFor(x=>x.value)

  }
}
