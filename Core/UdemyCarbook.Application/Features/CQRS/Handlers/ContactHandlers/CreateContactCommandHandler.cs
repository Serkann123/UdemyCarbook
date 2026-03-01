using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        private readonly IMapper _mapper;
        public CreateContactCommandHandler(IRepository<Contact> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(_mapper.Map<Contact>(command));
        }
    }
}
