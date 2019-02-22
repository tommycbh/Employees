using System.Threading.Tasks;
using Employees.Core.Entities;

namespace Employees.Core.Repositories
{
    public interface IRegionsRepository
    {
        Task CreateAsync(Region region);

        Task<Region> FirstOrDefaultAsync(int id);
    }
}
