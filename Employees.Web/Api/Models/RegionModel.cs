namespace Employees.Web.Api.Models
{
    public class RegionModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }
    }
}