using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
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

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            await _meditor.Send(new UpdateCarFeatureChangeToAvailableFalseCommand(id));
            return Ok("Güncelleme İşlemi Başarıyla Yapıldı");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            await _meditor.Send(new UpdateCarFeatureChangeToAvailableTrueCommand(id));
            return Ok("Güncelleme İşlemi Başarıyla Yapıldı");
        }

        [HttpPost]
        public async Task<IActionResult> CarFeatureByCarId(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            _meditor.Send(new CreateCarFeatureByCarCommand());
            return Ok("Güncelleme Yapıldı");
        }
    }
}
