using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class UpdateFooterAddressHandler:IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressId);
            values.Description = request.Description;
            values.Phone=request.Phone;
            values.Address=request.Address;
            values.Mail = request.Mail;
            await _repository.UpdateAsync(values);
        }
    }
}
