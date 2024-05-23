using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;

namespace CarBook.Application.Services.Mediator.Handlers.ServiceHandlers;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.Title = request.Title;
        value.IconUrl = request.IconUrl;
        value.Id = request.Id;

        await _repository.UpdateAsync(value);
        return Unit.Value;
    }
}
