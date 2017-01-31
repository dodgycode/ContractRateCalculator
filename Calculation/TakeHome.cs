namespace Calculation
{
    public class TakeHome
    {
        #region Input Properties
        public int DayRate
        {
            get
            {
                return DayRate;
            }
            set
            {
                GrossRevenue = DayRate * WeeksWorked;
            }
        }
        public int WeeksWorked { get; set; }
        public decimal Salary { get; set; }
        public decimal Pension { get; set; }
        public decimal AccountingFees { get; set; }
        #endregion

        #region Private properties
        //public NetRevenue Revenue { get; set; }
        private Taxes.Taxes Taxes { get; set; }
        private Expenses.Expenses Expenses { get; set; }
        private decimal GrossRevenue
        {
            get
            {
                return DayRate * WeeksWorked;
            }
            set
            {
                GrossRevenue = value;
                Taxes.SetGrossRevenue(GrossRevenue);
            }
        }

        private decimal GrossDividends
        {
            get
            {
                return GrossRevenue - Expenses.Amount;
            }
        }
        #endregion

        #region Output properties
        public decimal TotalIncludingPension
        {
            get
            {
                return GrossRevenue -
                    Taxes.Amount;
            }
        }

        public decimal TotalExcludingPension
        {
            get
            {
                return TotalIncludingPension -
                    Expenses.Pension.Amount;
            }
        }
        #endregion

    }
}
