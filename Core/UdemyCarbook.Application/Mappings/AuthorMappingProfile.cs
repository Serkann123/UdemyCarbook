using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarbook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, GetAuthorQueryResult>();
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore());
        }
    }
}
