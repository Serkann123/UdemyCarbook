using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarbook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>();
            CreateMap<Category, GetCategoryByIdQueryResult>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore());
        }
    }
}
