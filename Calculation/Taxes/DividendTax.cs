using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class DividendTax : ItemRecord
    {
        #region Constants
        private const int TaxFreeAmount = 5000;
        private const int BasicRateAmount = 32000;
        private const int HigherRateAmount = 150000;
        private const int PersonalAllowance = 11000;
        #endregion

        #region Properties
        public override decimal Amount
        {
            get
            {
                return TaxedAt7_5 + TaxedAt32_5 + TaxedAt38_1;
            }
        }
        
        private decimal TaxedAt7_5
        {
            get
            {
                var taxableAmount = GrossDividends > TaxFreeAmount ?
                    GrossDividends - TaxFreeAmount : 0;

                taxableAmount = taxableAmount > BasicRateAmount ?
                    BasicRateAmount - TaxFreeAmount : taxableAmount;

                taxableAmount = taxableAmount - AvailableAllowance >= 0 ?
                    taxableAmount - AvailableAllowance : 0;

                taxableAmount = taxableAmount > 0 ?
                 taxableAmount * 0.075M : 0;

                return taxableAmount;
            }
        }

        private decimal TaxedAt32_5
        {
            get
            {
                var taxableAmount = GrossDividends > BasicRateAmount ?
                    GrossDividends - BasicRateAmount : 0;

                taxableAmount = taxableAmount > HigherRateAmount ?
                    HigherRateAmount - BasicRateAmount : GrossDividends;

                taxableAmount = taxableAmount > 0 ?
                    taxableAmount * 0.325M : 0;

                return taxableAmount;
            }
        }

        private decimal TaxedAt38_1
        {
            get
            {
                var taxableAmount = GrossDividends > HigherRateAmount ?
                                    GrossDividends - HigherRateAmount : 0;

                taxableAmount = taxableAmount > 0 ?
                 taxableAmount * 0.381M : 0;

                return taxableAmount;
            }
        }
        
        private decimal AvailableAllowance
        {
            get
            {
                var allowance = PersonalAllowance - Salary > 0 ?
                    PersonalAllowance - Salary : 0;

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
