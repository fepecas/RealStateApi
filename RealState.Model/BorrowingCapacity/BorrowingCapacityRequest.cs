using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.Model.BorrowingCapacity
{
    class BorrowingCapacityRequest
    {
        public DataCredit DataCredit { get; set; }
        public Heritage Heritage { get; set; }
        public Subsidy Subsidy { get; set; }
       
    }
}
