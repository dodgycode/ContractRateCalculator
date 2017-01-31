using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class VAT : ItemRecord
    {
        #region Constants
        private const decimal FlatRate = 0.145M;
        private const decimal FullRate = 0.2M;
        #endregion

        #region Properties
        public override decimal Amount
        {
            get
            {
               return InputVat - OutputVat;
            }
        }

        private decimal InputVat
        {
            get
            {
                return GrossRevenue * FullRate;
            }
        }

        private decimal OutputVat
        {
            get
            {
                return (GrossRevenue + InputVat) * FlatRate;
            }
        }
       
        private decimal GrossRevenue { get; set; }

        public void SetGrossRevenue(decimal grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        #endregion
    }
}
