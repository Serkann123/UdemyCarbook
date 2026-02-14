using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarbook.Dto.CarFeatures;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator meditor)
        {
            _mediator = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListCarById(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost("CarFeatureByCarId")]
        public async Task<IActionResult> CarFeatureByCarId(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            await _mediator.Send(createCarFeatureByCarCommand);
            return Ok("Araç Özelliği başarıyla eklendi");
        }

        [HttpPut("UpdateCarFeatureAvailableChangeList")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeList(List<UpdateCarFeatureAvailableChangeDto> updateList)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableListCommand(updateList));
            return Ok("Araç özellikleri başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarFeatureByCarId(int id)
        {
            await _mediator.Send(new RemoveCarFeatureByCarCommand(id));
            return Ok("Silme işlemi başarıyla yapıldı");
        }
    }
}
