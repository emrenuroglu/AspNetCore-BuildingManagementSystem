using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public Guid ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public Guid CreatedById { get; set; }
        public User? CreatedBy { get; set; }
    }
}
