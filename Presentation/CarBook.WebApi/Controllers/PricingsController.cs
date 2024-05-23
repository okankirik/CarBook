﻿using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PricingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PricingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> PricingList()
    {
        var value = await _mediator.Send(new GetPricingQuery());
        return Ok(value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetPricing(int id)
    {
        var value = await _mediator.Send(new GetPricingByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Fiyat bilgisi  başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Fiyat bilgisi başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePricing(int id)
    {
        await _mediator.Send(new DeletePricingCommand(id));
        return Ok("Fiyat bilgisi  başarıyla gerçekleşti");
    }
}
