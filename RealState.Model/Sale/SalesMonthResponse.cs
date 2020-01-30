using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.Model.Sale
{
    public class SalesMonthResponse
    {
        public decimal ExpectedSalesAmount { get; set; }
        public string AlertMessage { get; set; }
    }
}
