﻿using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> FeatureList()
    {
        var value = await _mediator.Send(new GetFeatureQuery());
        return Ok(value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeature(int id)
    {
        var value = await _mediator.Send(new GetFeatureByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Özellik başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Özellik başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeature(int id)
    {
        await _mediator.Send(new DeleteFeatureCommand(id));
        return Ok("Özellik silme başarıyla gerçekleşti");
    }
}
