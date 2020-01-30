using System;
namespace RealState.Model.Sale
{
    public class SalesMonthRequest
    {
        public DateTime CutoffDate { get; set; }
        public decimal MonthlyGoalAmount { get; set; }
        public decimal TotalAccumulatedSales { get; set; }
    }
}
