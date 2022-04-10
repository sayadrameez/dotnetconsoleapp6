﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VendingMachine.CleanArchitecture.Application.Commands;
using VendingMachine.CleanArchitecture.Core.DTO;
using VendingMachine.CleanArchitecture.Core.ProjectAggregate.Events;

namespace VendingMachine.CleanArchitecture.Console.Controllers;

public class CoinController : BaseController
{
  private readonly IMediator _mediator;

  public CoinController(IMediator mediator) : base(mediator)
  {
    _mediator = mediator;
  }

  public async Task<CoinDTO> AddNewCoin(decimal coinvalue, CoinDTO coinDTO, string lang)
  {
    var result = await _mediator.Send(new NewCoinAddedCommand() { Coin = coinDTO, CoinValue = coinvalue, Lang = lang });

    return result;

  }
}
