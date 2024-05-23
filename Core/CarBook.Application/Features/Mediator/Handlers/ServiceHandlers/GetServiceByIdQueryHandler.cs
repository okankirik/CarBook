﻿using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;

namespace CarBook.Application.Services.Mediator.Handlers.ServiceHandlers;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
{
    private readonly IRepository<Service> _repository;

    public GetServiceByIdQueryHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetServiceByIdQueryResult
        {
            Description = value.Description,
            IconUrl = value.IconUrl,
            Id = value.Id,
            Title = value.Title
        };
    }
}
