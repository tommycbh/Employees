using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Core.Entities;

namespace Employees.Core.Repositories
{
    public interface IEmploeesRepository
    {
        Task CreateAsync(Employee employee);

        Task<List<Employee>> GetAllByRegionIdAsync(int region);
    }
}
