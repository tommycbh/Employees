using Employees.Core.Services;
using Employees.Web.Api.Models;
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
        public async Task Post([FromBody]EmployeeModel model)
        {
            await _employeesService.CreateAsync(model.RegionId, model.Name, model.Surname);
        }
    }
}