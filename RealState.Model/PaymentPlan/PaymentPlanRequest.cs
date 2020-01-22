using RealState.Model.Property;
using RealState.Model.Sale;
using System.Collections.Generic;

namespace RealState.Model.PaymentPlan
{
    public class PaymentPlanRequest
    {
        public Project.Project Project { get; set; }
        public Apartment Apartment { get; set; }
        public Customer Customer { get; set; }
        public List<Fee> Fees { get; set; }
    }
}
