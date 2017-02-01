using Calculation.BaseClasses;

namespace Calculation.Expenses
{
    public class Expenses : ItemRecord
    {

        #region Properties
        private Accounting AccountingExpense { get; set; }
        private Mileage MileageExpense { get; set; }
        private Pension Pension { get; set; }
        private Salary Salary { get; set; }
        #endregion

        #region     Constructor
        public Expenses()
        {
            AccountingExpense = new Accounting();
            MileageExpense = new Mileage();
            Pension = new Pension();
            Salary = new Salary();
        }
        #endregion

        #region Public methods
        public void SetAccountingFees(decimal fees)
        {
            AccountingExpense.Amount = fees;
            CalculateExpenses();
        }
        
        public void SetMileage(int milesPerDay, int weeksWorked)
        {
            MileageExpense.MilesPerDay = milesPerDay;
            MileageExpense.WeeksWorked = weeksWorked;
            CalculateExpenses();
        }

        public void SetPension (decimal pensionAmount)
        {
            Pension.Amount = pensionAmount;
            CalculateExpenses();
        }
        
        public void SetSalary(decimal salary)
        {
            Salary.Amount = salary;
            CalculateExpenses();
        }

        public decimal GetPensionAmount()
        {
            return Pension.Amount;
        }
        #endregion

        #region     Private methods
        private void CalculateExpenses()
        {
            var total = 0.0M;
            total += AccountingExpense.Amount;
            total += MileageExpense.Amount;
            total += Pension.Amount;
            total += Salary.Amount;

            Amount = total;
        }
        #endregion
    }
}
