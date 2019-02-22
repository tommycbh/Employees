using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Employees.Core.Services;
using Employees.Web.Api.Models;

namespace Employees.Web.Api
{
    public class RegionsController : ApiController
    {
        private readonly IRegionService _regionService;
        private readonly IEmployeesService _employeesService;

        public RegionsController(
            IRegionService regionService,
            IEmployeesService employeesService)
        {
            _regionService = regionService;
            _employeesService = employeesService;
        }

        [HttpPost]
        [Route("api/regions/")]
        public async Task Post([FromBody]RegionModel model)
        {
            await _regionService.CreateAsync(model.Id, model.Name, model.ParentId);
        }

        [HttpGet]
        [Route("api/region/{id}/employees")]
        public async Task<List<EmployeeModel>> GetEmployees(int id)
        {
            var employees = await _employeesService.GetAllByRegionIdAsync(id);

            var result = new List<EmployeeModel>();

            // TODO: Replace with automapper
            foreach (var employee in employees)
            {
                result.Add(
                    new EmployeeModel
                    {
                        Name = employee.Name,
                        RegionId = employee.RegionId,
                        Surname = employee.Surname
                    });
            }

            return result;
        }
    }
}