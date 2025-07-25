﻿namespace BuildingManagement.Domain.Dtos
{
    public class ApartmentDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
