using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.RepositoryPattern.TagCloudResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery:IRequest<GetTagCloudByIdQueryResult>
    {
        public int Id { get; set; }
        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }
    }
}
