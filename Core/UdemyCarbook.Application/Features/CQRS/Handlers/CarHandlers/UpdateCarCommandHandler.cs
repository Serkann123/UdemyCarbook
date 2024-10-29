using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            values.Fuel = command.Fuel;
            values.BigImageUrl = command.BigImageUrl;
            values.BrandId = command.BrandId;
            values.CarId = command.CarId;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Luggage= command.Luggage;
            values.Km= command.Km;
            values.Model= command.Model;
            values.Seat= command.Seat;
            values.Transmission= command.Transmission;
            await _repository.UpdateAsync(values);
        }
    }
}
