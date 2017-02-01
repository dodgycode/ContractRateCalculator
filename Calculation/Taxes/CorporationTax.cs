using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class CorporationTax : ItemRecord
    {
        #region Constants
        private const decimal CorporationTaxRate = 0.2M;
        #endregion

        #region   Properties

        private decimal _netPreTaxRevenue;
        public decimal NetPreTaxRevenue
        {
            get
            {
                return _netPreTaxRevenue;
            }
            set
            {
                _netPreTaxRevenue = value;
                Amount = _netPreTaxRevenue * CorporationTaxRate;
            }
        }
        #endregion
    }
}
