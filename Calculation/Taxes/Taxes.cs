﻿using Calculation.BaseClasses;

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

        public override decimal Amount
        {
            get
            {
                var total = 0.0M;
                total += CorporationTax.Amount;
                total += DividendTax.Amount;
                total += IncomeTax.Amount;
                total += NationalInsurance.Amount;
                total += VAT.Amount;

                return total;
            }
        }

        private decimal Salary
        {
            set
            {
                DividendTax.SetSalary(value);
                IncomeTax.SetSalary(value);
                NationalInsurance.SetSalary(value);
            }
        }

        private decimal GrossDividends
        {
            set
            {
                CorporationTax.NetPreTaxRevenue = value;
                DividendTax.SetGrossDividends(value);
            }
        }

        private decimal GrossRevenue
        {
            set
            {
                VAT.SetGrossRevenue(value);
            }
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
    }
}
