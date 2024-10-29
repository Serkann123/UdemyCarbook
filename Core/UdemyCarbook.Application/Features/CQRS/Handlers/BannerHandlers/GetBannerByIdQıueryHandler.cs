using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarbook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQıueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQıueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId=values.BannerId,
                Description=values.Description,
                Title=values.Title,
                VideoDescription=values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
