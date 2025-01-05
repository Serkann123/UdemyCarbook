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

        [HttpGet("GetAvgRentPriceForDaily")]
        public IActionResult GetAvgRentPriceForDaily()
        {
            var values = _meditor.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public IActionResult GetAvgRentPriceForWeekly()
        {
            var values = _meditor.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }


        [HttpGet("GetAvgRentPriceForMonthly")]
        public IActionResult GetAvgRentPriceForMonthly()
        {
            var values = _meditor.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public IActionResult GetCarCountByTranmissionIsAuto()
        {
            var values = _meditor.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public IActionResult GetBlogTitleByMaxBlogComment()
        {
            var values = _meditor.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public IActionResult GetCarCountByKmSmallerThen1000()
        {
            var values = _meditor.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public IActionResult GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _meditor.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public IActionResult GetCarCountByFuelElectric()
        {
            var values = _meditor.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModeByRentPriceDailyMax")]
        public IActionResult GetCarBrandAndModeByRentPriceDailyMax()
        {
            var values = _meditor.Send(new GetCarBrandAndModeByRentPriceDailyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModeByRentPriceDailyMin")]
        public IActionResult GetCarBrandAndModeByRentPriceDailyMin()
        {
            var values = _meditor.Send(new GetCarBrandAndModeByRentPriceDailyMinQuery());
            return Ok(values);
        }
    }
}
