using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTaxCalculation.Domain.Interfaces
{
    internal interface ITaxCalculator
    {
        string CountryCode { get; set;  }
        decimal CalculateTax(decimal income);
    }
}
