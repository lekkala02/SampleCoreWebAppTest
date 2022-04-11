using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleCoreWebApp.Models
{
    public class MyViewModel : IValidatableObject
    {
        public int Priority { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Priority < 1000)
            {
                if (DateEnd.Subtract(DateStart).TotalDays > 90)
                    yield return new ValidationResult($"<strong>The date range should be under 90 days</strong>");
            }
            else if (Priority > 1000 && Priority < 5000)
            {
                var totalDays = DateEnd.Subtract(DateStart).TotalDays;
                if (!(totalDays > 90 && totalDays < 180))
                    yield return new ValidationResult($"<strong>The date range should be between 90 and 180 days</strong>");
            }
            else if (Priority > 5000)
            {
                if (!(DateEnd.Subtract(DateStart).TotalDays > 180))
                    yield return new ValidationResult($"<strong>The date range should be more than 180 days</strong>");
            }
        }
    }
}
