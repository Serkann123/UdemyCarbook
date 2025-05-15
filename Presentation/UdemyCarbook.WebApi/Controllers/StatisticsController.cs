using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries;

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
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _meditor.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values =await _meditor.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values =await _meditor.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values =await _meditor.Send(new GetBrandCountQuery());
            return Ok(values);
        }


        [HttpGet("GetLocationQuery")]
        public async Task<IActionResult> GetLocationQuery()
        {
            var values =await _meditor.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values =await _meditor.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values =await _meditor.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }


        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _meditor.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var values = await _meditor.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _meditor.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _meditor.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var values =await _meditor.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var values =await _meditor.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values =await _meditor.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModeByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModeByRentPriceDailyMax()
        {
            var values =await _meditor.Send(new GetCarBrandAndModeByRentPriceDailyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModeByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModeByRentPriceDailyMin()
        {
            var values =await _meditor.Send(new GetCarBrandAndModeByRentPriceDailyMinQuery());
            return Ok(values);
        }
    }
}
