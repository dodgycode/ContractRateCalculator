using System;
using Calculation.BaseClasses;

namespace Calculation.Taxes
{
    public class Taxes : ItemRecord
    {
        #region Properties
        private CorporationTax CorporationTax { get; set; }
        private DividendTax DividendTax { get; set; }
        private IncomeTax IncomeTax { get; set; }
        private NationalInsurance NationalInsurance { get; set; }
        private VAT VAT { get; set; }

        private decimal _salary;
        private decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                DividendTax.SetSalary(value);
                IncomeTax.SetSalary(value);
                NationalInsurance.SetSalary(value);
                CalculateTotalTax();
            }
        }

        private decimal _grossDividends;
        private decimal GrossDividends
        {
            get
            {
                return _grossDividends;
            }
            set
            {
                _grossDividends = value;
                CorporationTax.NetPreTaxRevenue = value;
                DividendTax.SetGrossDividends(value);
                CalculateTotalTax();
            }
        }

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
                VAT.SetGrossRevenue(value);
                CalculateTotalTax();
            }
        }
        #endregion

        #region     Constructor
        public Taxes()
        {
            CorporationTax = new CorporationTax();
            DividendTax = new DividendTax();
            IncomeTax = new IncomeTax();
            NationalInsurance = new NationalInsurance();
            VAT = new VAT();
        }
        #endregion

        #region Public methods
        public void SetGrossDividends(decimal grossDividends)
        {
            GrossDividends = grossDividends;
        }

        public void SetSalary(decimal annualSalary)
        {
            Salary = annualSalary;
        }

        public void SetGrossRevenue(decimal revenue)
        {
            GrossRevenue = revenue;
        }
        #endregion

        #region Private methods
        private void CalculateTotalTax()
        {
            var total = 0.0M;
            total += CorporationTax.Amount;
            total += DividendTax.Amount;
            total += IncomeTax.Amount;
            total += NationalInsurance.Amount;
            total += VAT.Amount;

            Amount = total;
        }
        #endregion
    }
}
