namespace Employees.Core.Entities
{
    public class Employee : Entity<int>
    {
        public int RegionId { get; set; }

        public Region Region { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Employee()
        {
        }

        public Employee(int regionId, string name, string surname)
        {
            RegionId = regionId;
            Name = name;
            Surname = surname;
        }
    }
}
