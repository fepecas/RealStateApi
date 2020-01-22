using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealState.Domain;
using RealState.Model.PaymentPlan;
using RealState.Model.Property;

namespace RealState.WebApi.Tests
{
    [TestClass]
    public class PaymentPlanManagerTests
    {
        public PaymentPlanManager _paymentPlanManager { get; set; }

        public PaymentPlanManagerTests()
        {
            _paymentPlanManager = new PaymentPlanManager();
        }
        #region Tests
        [TestMethod]
        public void PaymentPlanManager_Analyze_WhenSuccess()
        {
            var plan = GetSuccessPlan();
            var result = _paymentPlanManager.Analyze(plan);

            Assert.IsTrue(result.IsApprovedByManager);
        }

        [TestMethod]
        public void PaymentPlanManager_Analyze_WhenDenied()
        {
            var plan = GetDeniedPlan();
            var result = _paymentPlanManager.Analyze(plan);

            Assert.IsFalse(result.IsApprovedByManager);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PaymentPlanManager_Analyze_WhenInsufficientAmountError()
        {
            var plan = GetInsufficientAmountPlan();
            _paymentPlanManager.Analyze(plan);
        }
        #endregion Tests

        #region Private Members
        private PaymentPlanRequest GetSuccessPlan()
        {
            return new PaymentPlanRequest
            {
                Apartment = new Apartment("1602")
                {
                    Price = 100000000
                },
                Fees = new List<Fee>
                {
                    new Fee { CutoffDate = new DateTime(2020, 1, 31), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2020, 2, 29), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 3, 31), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2020, 4, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 5, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 6, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 7, 31), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2020, 8, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 9, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 10, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 11, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2020, 12, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 1, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 2, 28), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2021, 3, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 4, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 5, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 6, 30), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2021, 7, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 8, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 9, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 10, 31), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 11, 30), ExpectedValue = 600000 },
                    new Fee { CutoffDate = new DateTime(2021, 12, 31), ExpectedValue = 1200000 },                    new Fee { CutoffDate = new DateTime(2020, 1, 31), ExpectedValue = 3000000 }
                }
            };
        }
        private PaymentPlanRequest GetDeniedPlan()
        {
            return new PaymentPlanRequest
            {
                Apartment = new Apartment("1602")
                {
                    Price = 100000000
                },
                Fees = new List<Fee>
                {
                    new Fee { CutoffDate = new DateTime(2020, 1, 31), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2020, 2, 29), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 3, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 4, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 5, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 6, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 7, 31), ExpectedValue = 2000000 },
                    new Fee { CutoffDate = new DateTime(2020, 8, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 9, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 10, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 11, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 12, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 1, 31), ExpectedValue = 2000000 },
                    new Fee { CutoffDate = new DateTime(2021, 2, 28), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 3, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 4, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 5, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 6, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 7, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 8, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 9, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 10, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 11, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 12, 31), ExpectedValue = 20000000 }
                }
            };
        }
        private PaymentPlanRequest GetInsufficientAmountPlan()
        {
            return new PaymentPlanRequest
            {
                Apartment = new Apartment("1602")
                {
                    Price = 100000000
                },
                Fees = new List<Fee>
                {
                    new Fee { CutoffDate = new DateTime(2020, 1, 31), ExpectedValue = 3000000 },
                    new Fee { CutoffDate = new DateTime(2020, 2, 29), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 3, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 4, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 5, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 6, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 7, 31), ExpectedValue = 2000000 },
                    new Fee { CutoffDate = new DateTime(2020, 8, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 9, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 10, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 11, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2020, 12, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 1, 31), ExpectedValue = 2000000 },
                    new Fee { CutoffDate = new DateTime(2021, 2, 28), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 3, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 4, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 5, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 6, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 7, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 8, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 9, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 10, 31), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 11, 30), ExpectedValue = 150000 },
                    new Fee { CutoffDate = new DateTime(2021, 12, 31), ExpectedValue = 10000000 }
                }
            };
        }
        #endregion Private Members
    }
}
