using Employees.Core.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employees.Web.Api
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpPost]
        [Route("api/Employee/")]
        public async Task Post([FromBody]int regionId, [FromBody]string name, [FromBody]string surname)
        {
            await _employeesService.CreateAsync(regionId, name, surname);
        }
    }
}