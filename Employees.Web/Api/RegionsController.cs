using Employees.Core.Services;
using Employees.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

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
        [Route("region/{id}/employees")]
        public async Task<List<EmployeeModel>> GetEmployees(int id)
        {
            var employees = await _employeesService.GetAllByRegionIdAsync(id);

            return AutoMapper.Mapper.Map<List<EmployeeModel>>(employees);
        }
    }
}