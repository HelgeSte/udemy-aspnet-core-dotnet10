using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample;

public class MaximumYearValidatorAttribute : ValidationAttribute
{
    public int MaximumYear { get; set; } = 2100;

    public string DefaultErrorMessage { get; set; } = "Year should not be more than {0}";

    // parameterless constructor
    public MaximumYearValidatorAttribute()
    {
        
    }

    public MaximumYearValidatorAttribute(int maximumYear)
    {
        MaximumYear = maximumYear;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = (DateTime)value;
            if (date.Year > MaximumYear)
            {
                // x ?? y -> returns y if x is null
                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MaximumYear));
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        return null;
    }
}