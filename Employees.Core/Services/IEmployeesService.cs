using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Core.Entities;

namespace Employees.Core.Services
{
    public interface IEmployeesService
    {
        Task CreateAsync(int regionId, string name, string surname);

        Task<List<Employee>> GetAllByRegionIdAsync(int regionId);
    }
}
