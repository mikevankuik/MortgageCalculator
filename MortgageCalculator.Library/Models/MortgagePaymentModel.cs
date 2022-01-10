using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Library.Models
{
    public class MortgagePaymentModel
    {
        public int Month { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal Interest { get; set; }
        public double InterestRate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal Prinicpal { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal PrincipalExtraPayment { get; set; }
        public decimal EndingBalance { get; set; }
    }
}
