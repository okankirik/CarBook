﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.SendDate = command.SendDate;
        value.Subject = command.Subject;
        value.Email = command.Email;
        value.Message = command.Message;
        value.Name = command.Name;
        await _repository.UpdateAsync(value);
    }
}
