using MediatR;
using UdemyCarbook.Application.Features.Mediator.Results.CarFeatureResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }
        public GetCarFeatureByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
