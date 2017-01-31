using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class CorporationTax : ItemRecord
    {
        #region Constants
        private const decimal CorporationTaxRate = 0.2M;
        #endregion

        #region   Properties
        public override decimal Amount
        {
            get
            {
                return NetPreTaxRevenue * CorporationTaxRate ;
            }
        }

        public decimal NetPreTaxRevenue { get; set; }
        #endregion
    }
}
