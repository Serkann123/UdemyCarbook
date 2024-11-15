using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.TestimonialQueries;


namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestiMonialController : ControllerBase
    {
        private readonly IMediator _meditor;

        public TestiMonialController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> TestiMonialList()
        {
            var values = await _meditor.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestiMonial(int id)
        {
            var values = await _meditor.Send(new GetTestimonialByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestiMonial(CreateTestimonialCommand command)
        {
            await _meditor.Send(command);
            return Ok("Referans başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestiMonial(int id)
        {
            await _meditor.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestiMonial(UpdateTestimonialCommand command)
        {
            await _meditor.Send(command);
            return Ok("Referans başarıyla güncelendi");
        }
    }
}
