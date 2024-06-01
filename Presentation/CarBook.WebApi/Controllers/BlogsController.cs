using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> BlogList()
    {
        var value = await _mediator.Send(new GetBlogQuery());
        return Ok(value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        var value = await _mediator.Send(new GetBlogByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        await _mediator.Send(new DeleteBlogCommand(id));
        return Ok("Blog silme başarıyla gerçekleşti");
    }

    [HttpGet("GetLast3BlogsWithAuthorsList")]
    public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
    {
        var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
        return Ok(values);
    }
}
