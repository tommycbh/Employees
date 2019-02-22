using Employees.Core.Entities;
using Employees.Core.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Employees.EntityFramework.Repositories
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly EmployeesDbContext _context;

        public RegionsRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task<Region> FirstOrDefaultAsync(int id)
        {
            return await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateAsync(Region region)
        {
            _context.Regions.Add(region);

            await _context.SaveChangesAsync();
        }
    }
}
