using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands
{
    public class RemoveCarFeatureByCarCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveCarFeatureByCarCommand(int id)
        {
            Id = id;
        }
    }
}
