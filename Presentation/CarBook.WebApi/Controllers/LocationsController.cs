﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LocationList()
    {
        var value = await _mediator.Send(new GetLocationQuery());
        return Ok(value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var value = await _mediator.Send(new GetLocationByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Lokasyon başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Lokasyon başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await _mediator.Send(new DeleteLocationCommand(id));
        return Ok("Lokasyon silme başarıyla gerçekleşti");
    }
}
