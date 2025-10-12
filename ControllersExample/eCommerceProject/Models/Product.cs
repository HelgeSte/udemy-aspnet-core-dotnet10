using System.ComponentModel.DataAnnotations;
using eCommerceProject.CustomValidator;

namespace eCommerceProject.Models;

public class Product
{
    [Required]
    [MinLength(3)]
    string ProductName { get; set; }
    
    [Required]
    [Range(1, 1000, ErrorMessage = "You have to order at least 1 item, and no more than 1000")]
    int Quantity { get; set; }
    
    [Required]
    //[MinimumDoubleValidator(2)]
    double Price { get; set; }

    public override string ToString()
    {
        return $"{ProductName} {Quantity} {Price}";
    }
}