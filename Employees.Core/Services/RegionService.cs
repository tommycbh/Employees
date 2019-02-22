using System;
using System.Threading.Tasks;
using Employees.Core.Entities;
using Employees.Core.Repositories;

namespace Employees.Core.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionsRepository _repository;

        public RegionService(IRegionsRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(int id, string name, int? parentId)
        {
            var region = new Region(id, name, parentId);

            if (region.ParentId != null)
            {
                var parent = await _repository.FirstOrDefaultAsync(region.ParentId.Value);

                region.Parent = parent ?? throw new Exception("Region does not exists.");
            }

            await _repository.CreateAsync(region);
        }
    }
}
