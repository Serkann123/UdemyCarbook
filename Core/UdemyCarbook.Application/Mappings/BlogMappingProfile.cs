using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.BlogComamnds;
using UdemyCarbook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetBlogQueryResult>();
            CreateMap<Blog, GetBlogByIdQueryResult>();

            CreateMap<Blog, GetBlogByAuthorIdQueryResult>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.Name))
                .ForMember(d => d.AuthorImageUrl, o => o.MapFrom(s => s.Author.ImageUrl))
                .ForMember(d => d.AuthorDescription, o => o.MapFrom(s => s.Author.Description));

            CreateMap<Blog, GetBlogsAllWithAuthorQueryResult>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.Name))
                .ForMember(d => d.AuthorDescription, o => o.MapFrom(s => s.Author.Description))
                .ForMember(d => d.AuthorImageUrl, o => o.MapFrom(s => s.Author.ImageUrl));

            CreateMap<Blog, GetLast3BlogsWithAuthorsQueryResult>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.Name));

            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>()
                .ForMember(dest => dest.BlogId, opt => opt.Ignore());
        }
    }
}
