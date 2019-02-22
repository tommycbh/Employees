using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IEmployeesService
    {
        Task CreateAsync(int regionId, string name, string surname);
    }
}
