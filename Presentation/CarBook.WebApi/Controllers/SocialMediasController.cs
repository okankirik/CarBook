using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var value = await _mediator.Send(new GetSocialMediaQuery());
        return Ok(value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(int id)
    {
        var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("Servis başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("Servis başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _mediator.Send(new DeleteSocialMediaCommand(id));
        return Ok("Servis başarıyla gerçekleşti");
    }
}
