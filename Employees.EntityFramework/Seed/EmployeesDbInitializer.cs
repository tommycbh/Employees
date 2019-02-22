using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Employees.Core.Entities;

namespace Employees.EntityFramework.Seed
{
    public class EmployeesDbInitializer : CreateDatabaseIfNotExists<EmployeesDbContext>
    {
        protected override void Seed(EmployeesDbContext context)
        {
            var csvParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            var regions = new List<Region>();
            var employees = new List<Employee>();

            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Employees.EntityFramework.Seed.Csv.regions.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = csvParser.Split(line);

                    var name = values[0];
                    var id = int.Parse(values[1]);
                    int? parentId = null;

                    if (values.Length == 3 && values[2].Trim() != string.Empty)
                    {
                        parentId = int.Parse(values[2]);
                    }

                    regions.Add(new Region(id, name, parentId));
                }
            }

            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Employees.EntityFramework.Seed.Csv.employees.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = csvParser.Split(line);

                    var regionId = int.Parse(values[0]);
                    var name = values[1];
                    var surname = values[2];

                    var employee = new Employee(regionId, name, surname);
                    employees.Add(employee);
                }
            }

            foreach (var region in regions)
            {
                region.HierarchyId = FillHierarchyRecursively(regions, region);
            }

            context.Regions.AddRange(regions);
            context.Employees.AddRange(employees);

            base.Seed(context);
        }

        private string FillHierarchyRecursively(List<Region> regions, Region region)
        {
            if (region.ParentId == null)
            {
                return region.Id + "/";
            }
            else
            {
                return FillHierarchyRecursively(regions, regions.Find(r => r.Id == region.ParentId)) + region.Id + "/";
            }
        }
    }
}
