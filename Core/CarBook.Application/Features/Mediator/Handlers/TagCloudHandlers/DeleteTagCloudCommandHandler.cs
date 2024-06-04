using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class DeleteTagCloudCommandHandler : IRequestHandler<DeleteTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;

    public DeleteTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteTagCloudCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return Unit.Value;
    }
}