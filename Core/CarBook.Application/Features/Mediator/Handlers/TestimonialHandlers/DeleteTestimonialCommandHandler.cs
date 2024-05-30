﻿using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

namespace CarBook.Application.Testimonials.Mediator.Handlers.TestimonialHandlers;

public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;

    public DeleteTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return Unit.Value;
    }
}
