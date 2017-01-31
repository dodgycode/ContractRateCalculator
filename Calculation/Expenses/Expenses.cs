using Calculation.BaseClasses;

namespace Calculation.Expenses
{
    public class Expenses : ItemRecord
    {
        #region Properties

        public Accounting AccountingExpense { get; set; }
        public Mileage MileageExpense { get; set; }
        public Pension Pension { get; set; }
        public Salary Salary { get; set; }

        public override decimal Amount
        {
            get
            {
                var total = 0.0M;
                total += AccountingExpense.Amount;
                total += MileageExpense.Amount;
                total += Pension.Amount;
                total += Salary.Amount;

                return total;
            }
        }
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
        }

        public void SetMileage(int milesPerDay, int weeksWorked)
        {
            MileageExpense.MilesPerDay = milesPerDay;
            MileageExpense.WeeksWorked = weeksWorked;
        }

        public void SetPension (decimal pensionAmount)
        {
            Pension.Amount = pensionAmount;
        }
        
        public void SetSalary(decimal salary)
        {
            Salary.Amount = salary;
        }
        #endregion
    }
}
