using RealState.Model.Sale;
using System;

namespace RealState.Domain
{
    public class SalesGoalManager
    {
        #region Public Members
        /// <summary>
        /// Calculate the sales goal in a specific week of the same month
        /// </summary>
        /// <param name="request">Input data to calculate the amount</param>
        /// <returns></returns>
        public SalesMonthResponse Calculate(SalesMonthRequest request)
        {
            var weeklyGoal = CalculateWeeklyGoal(request);            
            var response = new SalesMonthResponse { ExpectedSalesAmount = weeklyGoal };
            if (request.TotalAccumulatedSales < weeklyGoal)
            {
                response.AlertMessage = "Your sales are under the weekly goal";
            }

            return response;
        }
        #endregion Public Member

        #region Private Members
        private static decimal CalculateWeeklyGoal(SalesMonthRequest request)
        {
            var startOfWeek = request.CutoffDate.StartOfWeek(DayOfWeek.Monday);
            var daysInSameMonth = GetNumberDaysInSameMonth(startOfWeek);
            int totalDaysInMonth = DateTime.DaysInMonth(request.CutoffDate.Year, request.CutoffDate.Month);
            var dailyGoal = request.MonthlyGoalAmount / totalDaysInMonth;
            var weeklyGoal = dailyGoal * daysInSameMonth;
            return weeklyGoal;
        }

        private static int GetNumberDaysInSameMonth(DateTime startOfWeek) 
        {
            for (int i = 1; i < 7; i++)
            {              
                var day = startOfWeek.AddDays(i);
                if (startOfWeek.Month != day.Month)
                    return i;                
            }

            return 7;
        }
        #endregion Private Members
    }    
}
