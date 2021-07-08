using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue.Mvc.Models
{
    public class ExecutionDetailsModel
    {
        public int ExecutionDetailsId { get; set; }
        public int Year { get; set; }

        public double Value { get; set; }

        public double InterestRate { get; set; }
        public double FutureValue { get; set; }
        public int FutureValueId { get; set; }
    }
}
