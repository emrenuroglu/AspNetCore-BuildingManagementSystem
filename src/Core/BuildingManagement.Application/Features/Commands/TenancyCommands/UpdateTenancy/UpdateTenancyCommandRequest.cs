using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Commands.TenancyCommands.UpdateTenancy
{
    public class UpdateTenancyCommandRequest:IRequest<UpdateTenancyCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ApartmentId { get; set; }
        public Guid TenantId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime EndDate { get; set; }


    }
}
