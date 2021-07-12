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
        [Required(ErrorMessage ="This field is required.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Number.")]
        public double PresentValue { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Number.")]
        public int LowerBoundInterest { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Number.")]
        public int UpperBoundInterest { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Number.")]
        public int IncrementalRate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Number.")]
        public int MaturityYears { get; set; }
        public DateTime ExecutionDate { get; set; }

        public List<ExecutionDetailsModel> ExecutionDetails { get; set; }
    }
}
