using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarbook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.TagClouds.Mediator.Handlers.TagCloudHandler
{
    internal class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;
        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = values.TagCloudId,
                Title = values.Title,
                BlogId = values.BlogId
            };
        }
    }
}