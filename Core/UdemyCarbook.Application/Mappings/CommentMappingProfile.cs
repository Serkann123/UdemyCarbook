using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentQueryResult>();
            CreateMap<Comment, GetCommentByIdQueryResult>();
            CreateMap<Comment, GetCommentListByBlogIdQueryResult>();
            CreateMap<CreateCommentCommannd, Comment>()
                .ForMember(d => d.CreateDate,
                    o => o.MapFrom( src => DateTime.Parse(DateTime.Now.ToShortDateString())));
            CreateMap<UpdateCommentCommand, Comment>()
                .ForMember(dest => dest.CommentId, opt => opt.Ignore());
        }
    }
}
