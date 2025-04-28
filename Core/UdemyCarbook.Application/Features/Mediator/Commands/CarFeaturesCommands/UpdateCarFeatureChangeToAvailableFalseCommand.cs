using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands
{
    public class UpdateCarFeatureChangeToAvailableFalseCommand:IRequest
    {
        public int Id { get; set; }
        public UpdateCarFeatureChangeToAvailableFalseCommand(int id)
        {
            Id = id;
        }
    }
}
