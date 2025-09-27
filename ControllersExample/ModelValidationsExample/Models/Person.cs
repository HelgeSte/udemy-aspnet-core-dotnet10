using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomValidators;

namespace ModelValidationsExample.Models;

public class Person
{
    [BindNever]
    public int? Age { get; set; }
  
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} is not between {2} tp {1} characters")]
    [RegularExpression("^[a-zA-ZøæåØÆÅ .]+$", ErrorMessage = "{0} is not alphanumeric")]
    public string? PersonName { get; set; }
    
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [EmailAddress(ErrorMessage = "{0} should be a proper e-mail address")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [Compare("Email")]
    public string? ConfirmEmail { get; set; }
    
    [Phone(ErrorMessage = "{0} is not a valid phone number")]
    //[ValidateNever]
    public string? Phone { get; set; }
    
    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "{0} can't be blank")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*])(?=.{8,}).*$")]
    // Can replace (?=.{8,}).*$ with MinLenght(8)
    [MinLength(10, ErrorMessage = "{0} must be at least 10 characters")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string? ConfirmPassword { get; set; }
    
    [Range(0, 999.99,  ErrorMessage = "{0} must be between ${1} and ${2}")] 
    public double? Price { get; set; }
    
    [MinimumYearValidator(1900, ErrorMessage = "Date of birth should not be newer than Jan 01, {0}")]
    [MaximumYearValidator]
    public DateTime? DateOfBirth { get; set; }
        
    public DateTime FromDate { get; set; } // flyttet over for å fikse problem
    [DateRangeValidator("FromDate", ErrorMessage = "From Date should be older than or equal to 'ToDate'")]
     /* Flyttet FromDate over [DateRangeValidator] pga. ToDate fikk FromDate dato: */
     // public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
     
    // Returns a list of errors
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // breakpoint here is never hit, if any of the values above it are invalid
        if (DateOfBirth.HasValue == false && Age.HasValue == false)
        {
            yield return new ValidationResult("Either of Date of Birth or Age must be supplied",
                new[] { nameof(Age) });
            // yield allows you to return multiple values
            // yield return new ValidationResult("...", new[] { nameof(Age) });
        }

        if (DateOfBirth.HasValue == false)
        {
            yield return new ValidationResult("DoB is false", new[] { nameof(Age) });
        }

        if (Age.HasValue == false)
        {
            yield return new ValidationResult("Age is false", new[] { nameof(Age) });
        }
        // if yield return never occurs, is null returned?
        // you're going to be able to GetEnumerator() no matter what, there just won't be any items to enumerate. This is equivalent to Enumerable.Empty<T>.
    }

    public override string ToString()
    {
        return $"Person object - Person name:: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, ConfirmPassword: {ConfirmPassword},  Price: {Price}, Age: {Age}";
    }
}