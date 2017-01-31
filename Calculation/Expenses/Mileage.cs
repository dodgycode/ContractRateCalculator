using Calculation.BaseClasses;

namespace Calculation.Expenses
{
    public class Mileage : ItemRecord
    {
        #region Constants
        private const decimal Under10kRate = 0.45M;
        private const decimal Over10kRate = 0.25M;
     
        #endregion

        #region Properties

        public override decimal Amount
        {
            get
            {
                return CalculateMileageExpense();
            }
        }
        public int MilesPerDay { get; set; }
        public int WeeksWorked { get; set; }
        private int TotalMiles
        {
            get
            {
                return MilesPerDay * 5 * WeeksWorked;
            }
        }
        #endregion

             
        #region Private methods
        /// <summary>
        ///     Calculates total mileage expenses, accounting for different
        ///     rates above and below 10,000 miles per year.
        /// </summary>
        /// <returns></returns>
        private decimal CalculateMileageExpense()
        {
            var milesUnder10k = TotalMiles > 10000 ? 10000 : TotalMiles;
            var milesOver10k = TotalMiles > 10000 ? TotalMiles - 10000 : 0;

            var claimAmount = milesUnder10k * Under10kRate;
            claimAmount += milesOver10k * Over10kRate;

            return claimAmount;
        }
        #endregion
    }
}
