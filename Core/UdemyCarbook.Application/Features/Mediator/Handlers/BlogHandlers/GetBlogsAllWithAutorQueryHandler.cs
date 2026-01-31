using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarbook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsAllWithAutorQueryHandler : IRequestHandler<GetBlogsAllWithAutorQuery, List<GetBlogsAllWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsAllWithAutorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsAllWithAuthorQueryResult>> Handle(GetBlogsAllWithAutorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogsAllWithAuthorsAsync();
            return values.Select(x => new GetBlogsAllWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreateDate = x.CreateDate,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Descrpiton = x.Descrpiton,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl
            }).ToList();
        }
    }
}
