using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands;

public class DeleteTagCloudCommand : IRequest
{
    public int Id { get; set; }

    public DeleteTagCloudCommand(int id)
    {
        Id = id;
    }
}
