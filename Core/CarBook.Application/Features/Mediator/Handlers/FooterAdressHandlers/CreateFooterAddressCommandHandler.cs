using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IRepository<FooterAdress> _repository;

    public CreateFooterAddressCommandHandler(IRepository<FooterAdress> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
         await _repository.CreateAsync(new FooterAdress
         {
             Address = request.Address,
             Description = request.Description,
             Email = request.Email,
             Phone = request.Phone
         });
        return Unit.Value;
    }
}
