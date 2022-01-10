using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Library.Models
{
    public class QuestionnaireModel
    {
        public int Duration { get; set; }
        public double Interest { get; set; }
        public decimal Principal { get; set; }
    }
}
