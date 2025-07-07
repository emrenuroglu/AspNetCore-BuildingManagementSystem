namespace BuildingManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
