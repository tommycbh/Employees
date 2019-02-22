using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Employees.Core.Entities;
using Employees.Core.Repositories;

namespace Employees.EntityFramework.Repositories
{
    public class EmploeesRepository : IEmploeesRepository
    {
        private readonly EmployeesDbContext _context;

        public EmploeesRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllByHierarchyIdAsync(string hierarchyId)
        {
            var employees = _context.Employees.Where(e => e.Region.HierarchyId.StartsWith(hierarchyId));

            return await employees.ToListAsync();
        }
    }
}
