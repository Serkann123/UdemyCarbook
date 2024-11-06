using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand: IRequest
    {
        public int FooterAddressId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}
