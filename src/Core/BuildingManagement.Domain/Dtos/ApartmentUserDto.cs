namespace BuildingManagement.Domain.Dtos
{
    public class ApartmentUserDto
    {
        public Guid Id { get; set; }
        public string UserFullName { get; set; }
        public string KatDaire { get; set; }
        public string BinaAdi { get; set; }
        public string KullaniciTipi { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}

