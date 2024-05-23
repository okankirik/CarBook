using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;

namespace CarBook.Application.Pricings.Mediator.Handlers.LocationHandlers;

public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public UpdatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Id = request.Id;
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
        return Unit.Value;
    }
}
