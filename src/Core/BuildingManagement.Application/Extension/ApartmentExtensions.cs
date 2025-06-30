using BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment;
using BuildingManagement.Application.Features.Commands.ApartmentCommands.RemoveApartment;
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
        public static CreateBuildingCommandResponse ToCreateResponse(this Building building)
            => new()
            {
                Message = $"{building.Id}'si ile {building.Name} adında oluşturuldu."
            };


        public static RemoveBuildingCommandResponse ToRemoveResponse(this Building building)
    => new()
    {
        Message = $"{building.Id}'si ile {building.Name} adında olan apartman silindi."
    };
    }
}
