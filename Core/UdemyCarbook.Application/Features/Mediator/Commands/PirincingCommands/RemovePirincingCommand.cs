using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands
{
    public class RemovePirincingCommand:IRequest
    {
        public int Id { get; set; }
        public RemovePirincingCommand(int id)
        {
            Id = id;
        }
    }
}
