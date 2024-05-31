using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
    private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;

    public CarsController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, DeleteCarCommandHandler deleteCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler)
    {
        _getCarQueryHandler = getCarQueryHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _createCarCommandHandler = createCarCommandHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _deleteCarCommandHandler = deleteCarCommandHandler;
        _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        _getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var value = await _getCarByIdQueryHandler.Handle(new GeyCarByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("Araba eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Araba güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _deleteCarCommandHandler.Handle(new DeleteCarCommand(id));
        return Ok("Araba bilgisi silindi.");
    }

    [HttpGet("GetCarWithBrand")]
    public  IActionResult GetCarWithBrand()
    {
        var values = _getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
    
    [HttpGet("GetLast5CarsWithBrandQueryHandler")]
    public  IActionResult GetLast5CarsWithBrandQueryHandler()
    {
        var values = _getLast5CarsWithBrandQueryHandler.Handle();
        return Ok(values);
    }
}
