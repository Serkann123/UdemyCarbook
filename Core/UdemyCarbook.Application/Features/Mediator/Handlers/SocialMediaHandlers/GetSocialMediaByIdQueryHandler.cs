using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.SocailMediaQueries;
using UdemyCarbook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueyResult>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSocialMediaByIdQueyResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetSocialMediaByIdQueyResult>(entity);
        }
    }
}
