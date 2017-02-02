using System;
using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class IncomeTax : ItemRecord
    {
        #region Constants
        private const decimal BasicRateAmount = 32000;
        private const decimal BasicRate = 0.2M;

        private const decimal HigherRateAmount = 43000;
        private const decimal HigherRate = 0.4M;

        private const decimal AdditionalRateAmount = 150000;
        private const decimal AdditionalRate = 0.45M;

        private const int PersonalAllowance = 11000;

        #endregion

        #region Private Properties

        private decimal BasicRateTax { get; set; }

        private decimal HigherRateTax { get; set; }

        private decimal AdditionalRateTax { get; set; }

        private decimal AvailableAllowance
        {
            get
            {
                var allowance = PersonalAllowance - GrossDividends > 0 ?
                    PersonalAllowance - GrossDividends
                    : 0;

                return allowance;
            }
        }

        private decimal _grossDividends;
        private decimal GrossDividends
        {
            get
            {
                return _grossDividends;
            }
            set
            {
                _grossDividends = value;
                CalculateIncomeTax();
            }
        }

        private decimal _salary;
        private decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                CalculateIncomeTax();
            }
        }
        #endregion

        #region Public methods
        public void SetSalary(decimal annualSalary)
        {
            Salary = annualSalary;
        }

        public void SetGrossDividends(decimal revenue)
        {
            GrossDividends = revenue;
        }
        #endregion

        private void CalculateIncomeTax()
        {
            CalculateBasicRateTax();
            CalculateHigherRateTax();
            CalculateAdditionalRateTax();
            CalculateTotalTax();
        }

        private void CalculateTotalTax()
        {
            Amount = BasicRateTax + HigherRateTax + AdditionalRateTax;
        }

        private void CalculateAdditionalRateTax()
        {
            var tax = Salary > AdditionalRateAmount ?
                   Salary - AdditionalRateAmount : 0;

            tax = tax > 0 ?
             tax * AdditionalRate : 0;

            AdditionalRateTax = tax;
        }

        private void CalculateHigherRateTax()
        {
            var tax = Salary > HigherRateAmount ?
                  Salary - HigherRateAmount : 0;

            if (tax == 0)
            {
                HigherRateTax = 0;
                return;
            }

            tax = tax > AdditionalRateAmount ?
                AdditionalRateAmount : tax;

            tax = tax > 0 ?
             tax * HigherRate : 0;

            HigherRateTax = tax;
        }

        private void CalculateBasicRateTax()
        {
            var tax = Salary > AvailableAllowance ?
                   Salary - AvailableAllowance : 0;

            if (tax == 0)
            {
                BasicRateTax = 0;
                return;
            }

            tax = tax > HigherRateAmount ?
                HigherRateAmount : tax;

            tax = tax > 0 ?
             tax * BasicRate : 0;

            BasicRateTax = tax;

        }

    }
}
