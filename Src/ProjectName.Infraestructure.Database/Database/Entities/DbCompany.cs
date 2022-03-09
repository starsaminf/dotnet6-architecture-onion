namespace ProjectName.Infrastructure.Database.Entities
{
    public class DbCompany
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}