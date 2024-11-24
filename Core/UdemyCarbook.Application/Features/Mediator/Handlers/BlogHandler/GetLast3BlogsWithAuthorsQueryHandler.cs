using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarbook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetLast5BlogsWithAuthorsQueryHandler:IRequestHandler<GetLast3BlogsWithAuthorsQuery,List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast5BlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogsWithAuthors();
            return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId  = x.BlogId,
                CategoryId  = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreateDate = x.CreateDate,
                Title = x.Title,
                AuthorName=x.Author.Name
            
            }).ToList();
        }
    }
}
