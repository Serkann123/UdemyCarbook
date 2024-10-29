using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressComamnd: IRequest
    {
        public int Id { get; set; }
        public RemoveFooterAddressComamnd(int id)
        {
            Id = id;
        }
    }
}
