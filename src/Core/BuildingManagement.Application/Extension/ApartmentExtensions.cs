using BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment;
using BuildingManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Extension
{
    public static class ApartmentExtensions
    {
        public static CreateApartmentCommandResponse ToCreateResponse(this Apartment apartment)
            => new()
            {
                Message = $"{apartment.Id}'si ile {apartment.Name} adında oluşturuldu."
            };
    }
}
