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
        private decimal InputVat { get; set; }

        private decimal OutputVat { get; set; }

        private decimal _grossRevenue;
        private decimal GrossRevenue
        {
            get
            {
                return _grossRevenue;
            }
            set
            {
                _grossRevenue = value;
                CalculateVat();

            }
        }
        #endregion

        #region Public methods
        public void SetGrossRevenue(decimal grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        #endregion

        #region Private methods
        private void CalculateVat()
        {
            InputVat = GrossRevenue * FullRate;
            OutputVat = (GrossRevenue + InputVat) * FlatRate;
            Amount = OutputVat - InputVat; // Backwards to give negative amount
        }
        #endregion
    }
}
