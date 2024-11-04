using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarbook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarbook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarbook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Message=values.Message,
                Subject =values.Subject,
                Email=values.Email,
                Name=values.Name,
                SenDate=values.SenDate
            };
        }
    }
}
