using Employees.Core.Entities;
using Employees.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmploeesRepository _repository;
        private readonly IRegionsRepository _regionsRepository;

        public EmployeesService(
            IEmploeesRepository repository,
            IRegionsRepository regionsRepository)
        {
            _repository = repository;
            _regionsRepository = regionsRepository;
        }

        public async Task CreateAsync(int regionId, string name, string surname)
        {
            var region = await _regionsRepository.FirstOrDefaultAsync(regionId);

            if (region == null)
            {
                throw new Exception("Region does not exists.");
            }

           await _repository.CreateAsync(new Employee(regionId, name, surname));
        }

        public async Task<List<Employee>> GetAllByRegionIdAsync(int regionId)
        {
            return await _repository.GetAllByRegionIdAsync(regionId);
        }
    }
}
