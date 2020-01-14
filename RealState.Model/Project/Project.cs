using RealState.Model.Sale;

namespace RealState.Model.Project
{
    public class Project
    {
        public string Name { get; set; }
        public City City { get; set; }
        public SalesPerson EmployeeInCharge { get; set; }
    }
}
