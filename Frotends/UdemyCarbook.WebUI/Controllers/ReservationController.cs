using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Application.Validators.Tools;
using UdemyCarbook.Dto.ReservationDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly ILocationApiService _locationApiService;
        private readonly ICarApiService _carApiService;
        private readonly IReservationApiService _reservationApiService;

        public ReservationController(ILocationApiService locationApiService, ICarApiService carApiService,
            IReservationApiService reservationApiService)
        {
            _locationApiService = locationApiService;
            _carApiService = carApiService;
            _reservationApiService = reservationApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(ReservationInputDto input)
        {
            SetPage("Araç Kiralama", "Araç Rezervasyon Formu");

            await LoadLocations();

            // id gelmediyse araç listesi yükle
            if (input.CarId <= 0)
                await LoadCars();

            var model = new CreateReservationDto
            {
                CarId = input.CarId,
                PickUpLocationId = input.LocationId,
                DropOffLocationId = input.LocationId,
                PickUpDateTime = input.PickUp,
                DropOffDateTime = input.DropOff
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto dto)
        {
            SetPage("Araç Kiralama", "Araç Rezervasyon Formu");
            ViewBag.v3 = dto.CarId;

            if (dto.CarId <= 0)
                ModelState.AddModelError(nameof(dto.CarId), "Lütfen bir araç seçin.");

            if (!ModelState.IsValid)
            {
                await LoadLocations();

                // CarId yoksa araç dropdown'u tekrar dolsun
                if (dto.CarId <= 0)
                    await LoadCars();

                return View(dto);
            }

            var result = await _reservationApiService.CreateAsync(dto);

            if (result.Success)
                return RedirectToAction("Index", "Default");

            AddApiErrorsToModelState(result);

            await LoadLocations();
            if (dto.CarId <= 0) await LoadCars();

            return View(dto);
        }

        private async Task LoadLocations()
        {
            var values = await _locationApiService.GetAllAsync();

            ViewBag.Locations = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();
        }

        private async Task LoadCars()
        {
            var cars = await _carApiService.GetAllAsync();

            ViewBag.Cars = cars.Select(c => new SelectListItem
            {
                Text = $"{c.BrandName} {c.Model}",
                Value = c.CarId.ToString()
            }).ToList();
        }

        private void AddApiErrorsToModelState(ApiPostResult result)
        {
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = JsonConvert.DeserializeObject<ApiValidationProblem>(result.RawBody ?? "");
                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                        foreach (var message in error.Value)
                            ModelState.AddModelError(error.Key, message);
                    return;
                }
            }

            ModelState.AddModelError(string.Empty,
                $"İşlem başarısız: {(int)result.StatusCode} {result.ReasonPhrase}");
        }
    }
}