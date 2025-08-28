using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarbook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
               Address=values.Address,
               Description=values.Description,
               FooterAddressId=values.FooterAddressId,
               Mail = values.Mail,
               Phone = values.Phone
            };

        }
    }
}

