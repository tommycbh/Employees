using System.Collections.Generic;

namespace Employees.Core.Entities
{
    public class Region : Entity<int>
    {
        public int? ParentId { get; set; }

        public Region Parent { get; set; }

        public string Name { get; set; }

        public string HierarchyId { get; set; }

        public virtual List<Region> Children { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public Region()
        {
        }

        public Region(int id, string name, int? parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }
}
