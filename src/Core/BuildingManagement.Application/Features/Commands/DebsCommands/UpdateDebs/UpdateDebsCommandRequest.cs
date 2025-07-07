using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Commands.DebsCommands.UpdateDebs
{
    public class UpdateDebsCommandRequest : IRequest<UpdateDebsCommandResponse>
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid CreatedById { get; set; }
    }
}
