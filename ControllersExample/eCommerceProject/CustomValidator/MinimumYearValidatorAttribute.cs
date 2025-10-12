using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.CustomValidator;

public class MinimumYearValidatorAttribute : ValidationAttribute
{
    public int MinimumYear { get; set; } = 2000;

    public string DefaultErroMessage { get; set; } = "Year should not be less than {0}";

    public MinimumYearValidatorAttribute()
    {
    }

    public MinimumYearValidatorAttribute(int minimumYear)
    {
        MinimumYear = minimumYear;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = (DateTime)value;
            
            if (this.MinimumYear <= 2000)
            {
                return  new ValidationResult(string.Format(ErrorMessage ?? DefaultErroMessage, MinimumYear));
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        
        return null;
    }
}