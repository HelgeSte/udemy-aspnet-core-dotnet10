using eCommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Controllers;

public class HomeController : Controller
{
    [Route("customers")]
    public IActionResult Index(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            string errors = string.Join("\n",
                ModelState.Values.SelectMany(values =>
                    values.Errors).Select(error => error.ErrorMessage));
            // return BadRequest(new { errors }); // code displays "\n" instead of 
            return BadRequest( errors );
        }
        return Content($"{customer}");
    }

    [Route("order")]
    public IActionResult Index(Product product)
    {
        if (!ModelState.IsValid)
        {
            string errors = string.Join("\n",
                ModelState.Values.SelectMany(values =>
                    values.Errors).Select(error => error.ErrorMessage));
            return BadRequest( errors );
        }

        return Content($"{product}");
    }
}