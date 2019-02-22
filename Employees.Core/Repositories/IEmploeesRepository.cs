using Employees.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IEmploeesRepository
    {
        Task CreateAsync(Employee employee);

        Task<List<Employee>> GetByRegionId(int regionId);
    }
}
