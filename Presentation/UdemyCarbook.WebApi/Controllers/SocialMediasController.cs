using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.SocailMediaQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _meditor;

        public SocialMediasController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _meditor.Send(new GetSocailMediaQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var values = await _meditor.Send(new GetSocialMediaByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _meditor.Send(command);
            return Ok("Sosyal Medya başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _meditor.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _meditor.Send(command);
            return Ok("Sosyal Medya başarıyla güncelendi");
        }
    }
}
