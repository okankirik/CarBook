using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public DeleteSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return Unit.Value;
    }
}
