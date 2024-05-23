﻿using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers;

public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IRepository<FooterAdress> _repository;

    public UpdateFooterAddressCommandHandler(IRepository<FooterAdress> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.Address = request.Address;
        value.Phone = request.Phone;
        value.Email = request.Email;
        await _repository.UpdateAsync(value);
        return Unit.Value;
    }
}
