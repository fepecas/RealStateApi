using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealState.Model.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Tests
{
    [TestClass]
    public class SalesGoalManagerTests
    {
        private  SalesGoalManager _salesGoalManager { get; set; }

        public SalesGoalManagerTests()
        {
            _salesGoalManager = new SalesGoalManager();
        }

        [TestMethod]
        public void SalesGoalManager_Calculate_WhenAllDaysBelongSameMonthSuccess()
        {
            var request = new SalesMonthRequest
            {
                MonthlyGoalAmount = 1000000000,
                CutoffDate = new DateTime(2020, 2, 19)             
            };           

            var response = _salesGoalManager.Calculate(request);
            Assert.AreEqual(241379310.34482758620689655172m, response.ExpectedSalesAmount);
        }       
        
        [TestMethod]
        public void SalesGoalManager_Calculate_WhenNotAllDaysBelongSameMonthSuccess()
        {
            var request = new SalesMonthRequest
            {
                MonthlyGoalAmount = 500000000,
                CutoffDate = new DateTime(2020, 3, 31)
            };

            var response = _salesGoalManager.Calculate(request);
            Assert.AreEqual(32258064.516129032258064516130m, response.ExpectedSalesAmount);
        }

        [TestMethod]
        public void SalesGoalManager_Calculate_SendAlertSuccess()
        {
            var request = new SalesMonthRequest
            {
                MonthlyGoalAmount = 1000000000,
                CutoffDate = new DateTime(2020, 2, 24),
                TotalAccumulatedSales = 150000000,
            };

            var response = _salesGoalManager.Calculate(request);
            Assert.AreEqual("Your sales are under the weekly goal", response.AlertMessage);
        }

        [TestMethod]
        public void SalesGoalManager_Calculate_NotSendAlertSuccess()
        {
            var request = new SalesMonthRequest
            {
                MonthlyGoalAmount = 1000000000,
                CutoffDate = new DateTime(2020, 2, 24),
                TotalAccumulatedSales = 210000000,
            };

            var response = _salesGoalManager.Calculate(request);            
            Assert.IsNull(response.AlertMessage);
        }
    }
}
