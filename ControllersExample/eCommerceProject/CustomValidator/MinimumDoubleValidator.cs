using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.CustomValidator;

public class MinimumDoubleValidator : ValidationAttribute
{
    public double MinimumPrice { get; set; } = 10;
    
    public string DefaultErroMessage { get; set; } = "Price should be less than {0}";

    public MinimumDoubleValidator()
    {
        
    }

    public MinimumDoubleValidator(double minimumPrice)
    {
        MinimumPrice = minimumPrice;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = (DateTime)value;
            
            if (this.MinimumPrice <= 0)
            {
                return  new ValidationResult(string.Format(ErrorMessage ?? DefaultErroMessage, MinimumPrice));
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        
        return null;
    }
    
}