﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarbook.Application.Features.RepositoryPattern.TagCloudResults;
using UdemyCarbook.Application.Interfaces.TagCloudInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler:IRequestHandler<GetTagCloudByBlogIdQuery,List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudByBlogId(request.Id);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,
                Title = x.Title
            }).ToList();
        }
    }
}
