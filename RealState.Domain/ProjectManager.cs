using RealState.IDomain;
using RealState.Model.Project;
using RealState.Model.Sale;
using System;
using System.Collections.Generic;

namespace RealState.Domain
{
    public class ProjectManager : IProject
    {
        public List<Project> GetAll()
        {
            return new List<Project>
            {
                new Project
                {
                    Name = "Torreón de Varsovia",
                    City = new City
                    {
                        Name = "Ibagué",
                        IATACode = "IBE"
                    },
                    EmployeeInCharge = new SalesPerson("Felipe", "Peña")
                }
            };
        }

        public List<Project> GetAll(City city)
        {
            throw new NotImplementedException();
        }
    }
}
