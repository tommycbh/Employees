using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IRegionService
    {
        Task CreateAsync(int id, string name, int? parentId);
    }
}
