using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces.CarInterfaces;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetLast5CarsQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetLast5WithCarsWithBrandAsync();
            return _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
        }
    }
}
