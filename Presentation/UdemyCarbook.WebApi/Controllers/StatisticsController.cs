using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public StatisticsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var values = _meditor.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public IActionResult GetAuthorCount()
        {
            var values = _meditor.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var values = _meditor.Send(new GetBlogCountQueryResult());
            return Ok(values);
        }


        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var values = _meditor.Send(new GetBrandCountQuery());
            return Ok(values);
        }


        [HttpGet("GetLocationQuery")]
        public IActionResult GetLocationQuery()
        {
            var values = _meditor.Send(new GetLocationCountQuery());
            return Ok(values);
        }
    }
}
