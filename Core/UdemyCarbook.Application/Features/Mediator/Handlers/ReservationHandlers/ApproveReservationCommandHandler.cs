using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class ApproveReservationCommandHandler : IRequestHandler<ApproveReservationCommand, bool>
    {
        private readonly IRepository<Reservation> _reservationRepo;
        private readonly IRepository<RendACarProcess> _processRepository;
        private readonly ICarPricingRepository _carPricingRepository;

        public ApproveReservationCommandHandler(IRepository<Reservation> reservationRepo,
            IRepository<RendACarProcess> processRepository, ICarPricingRepository carPricingRepository)
        {
            _reservationRepo = reservationRepo;
            _processRepository = processRepository;
            _carPricingRepository = carPricingRepository;
        }
        public async Task<bool> Handle(ApproveReservationCommand request, CancellationToken cancellationToken)
        {
            var res = await _reservationRepo.GetByIdAsync(request.ReservationId);
            if (res == null || res.Status != "Pending") return false;

            // Fiyat Hesaplama İşini "Private Method"a devrettik
            decimal calculatedPrice = await CalculateTotalPrice(res);

            if (calculatedPrice <= 0) return false;

            // Güncelleme ve Kayıt
            res.Status = "Approved";
            await _reservationRepo.UpdateAsync(res);

            // RendACarProcess tablosuna kayır ekle
            await _processRepository.CreateAsync(new RendACarProcess
            {
                CarId = res.CarId,
                PickUpLocationId = res.PickUpLocationId ?? 0,
                DropOffLocationId = res.DropOffLocationId ?? 0,
                PickUpDate = res.PickUpDateTime.Date,
                DropOffDate = res.DropOffDateTime.Date,
                PickUpTime = res.PickUpDateTime.TimeOfDay,
                DropOffTime = res.DropOffDateTime.TimeOfDay,
                PickUpDescription = "Reservation Approved",
                DropOffLocationDescription = "Reservation Approved",
                TotalPrice = calculatedPrice
            });

            return true;
        }

        // Hesaplama mantığı burada yapıldı 
        private async Task<decimal> CalculateTotalPrice(Reservation res)
        {
            var totalMinutes = (res.DropOffDateTime - res.PickUpDateTime).TotalMinutes;
            if (totalMinutes <= 0) return 0;

            int totalDays = (int)Math.Ceiling(totalMinutes / (60 * 24.0));

            // Fiyatları çek
            var dailyPrice = await _carPricingRepository.GetAmountAsync(res.CarId, "Günlük") ?? 0;
            var weeklyPrice = await _carPricingRepository.GetAmountAsync(res.CarId, "Haftalık") ?? (dailyPrice * 7);
            var monthlyPrice = await _carPricingRepository.GetAmountAsync(res.CarId, "Aylık") ?? (weeklyPrice * 4);

            decimal totalPrice = 0;

            // 30 gün ve üzeri süreleri aylık paketlere bölerek fiyatla
            if (totalDays >= 30)
            {
                int months = totalDays / 30;
                totalPrice += months * monthlyPrice;
                totalDays %= 30;
            }

            // Aylıktan kalan 7 gün ve üzeri süreleri haftalık paketlere bölerek fiyatla
            if (totalDays >= 7)
            {
                int weeks = totalDays / 7;
                totalPrice += weeks * weeklyPrice;
                totalDays %= 7;
            }

            // Haftalıktan kalan günleri günlük fiyat üzerinden hesapla ve Toplam fiyatı bul
            if (totalDays > 0)
            {
                totalPrice += totalDays * dailyPrice;
            }

            return totalPrice;
        }
    }
}
