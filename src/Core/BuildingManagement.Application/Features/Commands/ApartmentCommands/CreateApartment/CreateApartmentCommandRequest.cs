using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateApartmentCommandRequest : IRequest<CreateApartmentCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int TotalUnits { get; set; }
    }
}
