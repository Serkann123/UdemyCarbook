using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CarFeaturesController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListCarById(int id)
        {
            var values = await _meditor.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
    }
}
