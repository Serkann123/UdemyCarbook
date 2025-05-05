using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarMainCarFeatureQuery
    {
        public int Id { get; set; }
        public GetCarMainCarFeatureQuery(int id)
        {
            Id = id;
        }
    }
}
