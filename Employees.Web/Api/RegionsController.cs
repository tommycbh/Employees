using Employees.Core.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employees.Web.Api
{
    public class RegionsController : ApiController
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost]
        [Route("api/regions/")]
        public async Task Post([FromBody]int id, [FromBody]string name, [FromBody]int? parentId)
        {
            await _regionService.CreateAsync(id, name, parentId);
        }
    }
}