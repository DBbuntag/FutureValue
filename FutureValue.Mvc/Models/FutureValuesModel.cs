using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue.Mvc.Models
{
    public class FutureValuesModel
    {
        public int FutureValuesId { get; set; }
        public double PresentValue { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int LowerBoundInterest { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int UpperBoundInterest { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int IncrementalRate { get; set; }
        public int MaturityYears { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}
