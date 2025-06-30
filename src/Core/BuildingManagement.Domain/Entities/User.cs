using BuildingManagement.Domain.Common;
using BuildingManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcKimlikNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }

        public ICollection<ApartmentUser> ApartmentUsers { get; set; }
        public ICollection<Tenancy> TenanciesAsTenant { get; set; }
        public ICollection<Tenancy> TenanciesAsOwner { get; set; }

    }
}
