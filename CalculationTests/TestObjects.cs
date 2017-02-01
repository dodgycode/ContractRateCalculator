using Calculation;

namespace CalculationTests
{
    public class TestObjects
    {
        public TakeHome GetTest1()
        {
            var obj = new TakeHome()
            {
                DayRate = 310,
                WeeksWorked = 44,
                MilesPerDay = 100,
                Pension = 7000,
                AccountingFees = 1200,
                Salary = 6500
            };

            return obj;
        }
    }
}
