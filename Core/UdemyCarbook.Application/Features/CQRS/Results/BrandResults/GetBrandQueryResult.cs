using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public int BranId { get; set; }
        public string Name { get; set; }
    }
}
