using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using eCommerceProject.CustomValidator;

namespace eCommerceProject.Models;

public class Customer
{
    [Required(ErrorMessage = "Firt name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }
    [Compare("Email", ErrorMessage = "Email and Confirm Email do not match")]
    public string ConfirmEmail { get; set; }
    
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!*^&@#$-])")]
    [MinLength(8, ErrorMessage = "First name must be at least 8 characters")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirm password is required")]
    public string ConfirmPassword { get; set; }
    
    [Phone]
    [Required(ErrorMessage = "Phone number is required")]
    public string Phone { get; set; }
    
    [MinimumYearValidator(1971, ErrorMessage = "You cannot be older than I")]
    public DateTime DateOfBirth { get; set; }
  
    
    
}