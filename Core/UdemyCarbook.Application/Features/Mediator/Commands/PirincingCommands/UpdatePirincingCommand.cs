using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands
{
    public class UpdatePirincingCommand:IRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}