using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class NationalInsurance : ItemRecord
    {
        #region Constants
        // Tax year 2016/17
        private const decimal FullRate = 0.12M;
        private const decimal ReducedRate = 0.02M;
        private const decimal EmployerRate = 0.138M;
        private const decimal FullRateWeeklyThreshold = 156; 
        private const decimal ReducedRateWeeklyThreshold = 827; 
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
                var employeeContribution = WeeklySalary > FullRateWeeklyThreshold ?
                    WeeklySalary - FullRateWeeklyThreshold : 0;

                employeeContribution = employeeContribution > ReducedRateWeeklyThreshold ?
                    ReducedRateWeeklyThreshold : employeeContribution;

                employeeContribution = employeeContribution > 0 ?
                    employeeContribution * FullRate * 52 : 0;

                var employerContribution = WeeklySalary > FullRateWeeklyThreshold ?
                    WeeklySalary - FullRateWeeklyThreshold : 0;
                employerContribution = employerContribution * EmployerRate * 52;

                return employeeContribution + employerContribution;
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
