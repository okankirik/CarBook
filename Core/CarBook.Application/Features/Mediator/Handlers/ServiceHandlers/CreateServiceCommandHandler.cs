using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;

namespace CarBook.Application.Services.Mediator.Handlers.ServiceHandlers;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public CreateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Service
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title
        });
        return Unit.Value;
    }
}
