using RealState.Model.PaymentPlan;
using System;
using System.Collections.Generic;

namespace RealState.Domain
{
    public class PaymentPlanManager
    {
        #region Constants
        private const decimal MINIMUM_LEGAL_INITIAL_FEE = 0.3m;
        private const decimal MINIMUM_PERCENTAGE_CURRENT_YEAR = 0.3m;
        #endregion Constants

        #region Public Members
        public PaymentPlanResponse Analyze(PaymentPlanRequest plan)
        {
            Validate(plan);

            var initialFee = plan.Apartment.Price * MINIMUM_LEGAL_INITIAL_FEE;
            var totalPlanAmmount = CalculateTotalFee(plan.Fees);

            if (totalPlanAmmount < initialFee)
                throw new Exception("The plan doesn't sum at least the initial fee.");

            var totalFeeCurrentYear = CaculateCurrentYearTotalFee(plan);

            if (totalFeeCurrentYear < initialFee * MINIMUM_PERCENTAGE_CURRENT_YEAR)
                return new PaymentPlanResponse { IsApprovedByManager = false };

            return new PaymentPlanResponse { IsApprovedByManager = true };
        }
        #endregion Public Members

        #region Private Members
        private void Validate(PaymentPlanRequest plan)
        {
            if (plan.Apartment == null)
                throw new Exception("No apartment was found");

            if (plan.Fees == null)
                throw new Exception("No payment plan was found");
        }
        private decimal CaculateCurrentYearTotalFee(PaymentPlanRequest plan)
        {
            var feesCurrentYear = plan.Fees.FindAll(f => f.CutoffDate.Year == DateTime.Now.Year);
            var monthsLeft = feesCurrentYear.Count;
            int monthsNumberFirstCut = 12;

            if (monthsLeft < 6)
            {
                if (plan.Fees.Count < 12)
                    monthsNumberFirstCut = plan.Fees.Count;

                for (var i = monthsLeft; i < monthsNumberFirstCut; i++)
                {
                    feesCurrentYear.Add(plan.Fees[i]);
                }
            }

            return CalculateTotalFee(feesCurrentYear);
        }
        private decimal CalculateTotalFee(List<Fee> fees)
        {
            decimal totalFee = 0;
            foreach (var fee in fees)
                totalFee += fee.ExpectedValue;

            return totalFee;
        }
        #endregion Private Members
    }
}
