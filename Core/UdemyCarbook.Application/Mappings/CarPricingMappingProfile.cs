using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.ViewsModel;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class CarPricingMappingProfile:Profile
    {
        public CarPricingMappingProfile()
        {
            CreateMap<CarPricing, GetCarPirincingWithCarQueryResult>()
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Ammount))
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Car.Brand.Name))
                .ForMember(d => d.CoverImageUrl, o => o.MapFrom(s => s.Car.CoverImageUrl))
                .ForMember(d => d.Model, o => o.MapFrom(s => s.Car.Model))
                .ForMember(d => d.CarPirincingId, o => o.MapFrom(s => s.CarPricingId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Piricing.Name));

            CreateMap<CarPrincingViewModel, GetCarPrincingWithTimePeriodQueryResult>();
        }
    }

}
