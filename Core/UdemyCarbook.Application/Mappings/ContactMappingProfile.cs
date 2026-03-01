using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarbook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, GetContactQueryResult>();
            CreateMap<Contact, GetContactByIdQueryResult>();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>()
                .ForMember(dest => dest.ContactId, opt => opt.Ignore());
        }
    }
}
