using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarbook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarbook.Application.Features.CQRS.Queries.BannerQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQıueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQıueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values =await _getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value =await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Bilgi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Bilgi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Bilgi Güncellendi");
        }
    }
}
