using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class NationalInsurance : ItemRecord
    {
        #region Constants
        private const decimal FullRate = 0.12M;
        private const decimal ReducedRate = 0.02M;
        private const decimal FullRateWeeklyThreshold = 149;
        private const decimal ReducedRateWeeklyThreshold = 797;
        #endregion

        #region Properties
        public override decimal Amount
        {
            get
            {
                return FullNIAmount + ReducedNIAmount; 
            }
        }

        private decimal FullNIAmount
        {
            get
            {
                var contribution = WeeklySalary > FullRateWeeklyThreshold ?
                    WeeklySalary - FullRateWeeklyThreshold : 0;

                contribution = contribution > ReducedRateWeeklyThreshold ?
                    ReducedRateWeeklyThreshold : contribution;

                contribution = contribution > 0 ?
                    contribution * FullRate * 52 : 0;

                return contribution;
             }
        }

        private decimal ReducedNIAmount
        {
            get
            {
                var contribution = WeeklySalary > ReducedRateWeeklyThreshold ?
               WeeklySalary - ReducedRateWeeklyThreshold : 0;
                
                contribution = contribution > 0 ?
                    contribution * ReducedRate * 52 : 0;

                return contribution;
            }
        }

        private decimal WeeklySalary { get; set; }

        #endregion

        #region Public methods
        public void SetSalary(decimal annualSalary)
        {
            WeeklySalary = annualSalary/52;
        }
        #endregion
    }
}
