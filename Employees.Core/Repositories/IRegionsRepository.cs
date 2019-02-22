using Employees.Core.Entities;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IRegionsRepository
    {
        Task CreateAsync(Region region);

        Task<Region> FirstOrDefaultAsync(int id);
    }
}
