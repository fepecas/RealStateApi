using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.Model.PaymentPlan
{
    public class Fee
    {
        public DateTime CutoffDate { get; set; }
        public decimal ExpectedValue { get; set; }
        public decimal ActualValue { get; set; }
    }
}
