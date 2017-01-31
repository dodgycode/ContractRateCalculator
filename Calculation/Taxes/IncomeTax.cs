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

        #region Properties
        public override decimal Amount
        {
            get
            {
                return  BasicRateTax + HigherRateTax + AdditionalRateTax;
            }
        }

        private decimal BasicRateTax
        {
            get
            {
                var tax = Salary > AvailableAllowance ?
                  Salary - AvailableAllowance : 0;

                tax = tax > HigherRateAmount ?
                    HigherRateAmount : tax; 

                tax = tax > 0 ?
                 tax * BasicRate : 0;

                return tax;
            }
        }

        private decimal HigherRateTax
        {
            get
            {
                var tax = Salary > HigherRateAmount ?
                  Salary - HigherRateAmount : 0;

                tax = tax > AdditionalRate ?
                    AdditionalRate : tax;

                tax = tax > 0 ?
                 tax * HigherRate : 0;

                return tax;
            }
        }

        private decimal AdditionalRateTax
        {
            get
            {
                var tax = Salary > AdditionalRateAmount ?
                  Salary - AdditionalRateAmount : 0;

                tax = tax > 0 ?
                 tax * AdditionalRate : 0;

                return tax;
            }
        }

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

        private decimal GrossDividends { get; set; }

        private decimal Salary { get; set; }
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
    }
}
