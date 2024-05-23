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

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public DeleteServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return Unit.Value;
    }
}
