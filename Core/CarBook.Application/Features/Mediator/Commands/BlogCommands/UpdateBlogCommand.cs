﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class UpdateBlogCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CoverImageUrl { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}
