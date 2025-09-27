using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers;

public class HomeController : Controller
{
    // Add values to the properties by using form-data or similar in Postman's
    // body section, and model binding will add the data to the Person object. 
    [Route("register")] 
    /* [ModelBinder(typeof(PersonModelBinder))] <- isn't needed after we created the PersonBinderProvider class */
    public IActionResult Index(Person person)
    {
        if (!ModelState.IsValid)
        {
           
            // replace the chanined foreach loops
            string errors = string.Join("\n",
                ModelState.Values.SelectMany(value => // equal to outer loop 
                    value.Errors).Select(err => err.ErrorMessage)); // equal to inner loop
            // List<string> errorsList = new List<string>();
            /*foreach (var value in ModelState.Values)
            {   
                foreach (var error in value.Errors)
                {
                    errorsList.Add(error.ErrorMessage);
                }   
            }*/
            // var errors = string.Join("\n", errorsList);
            return BadRequest(errors);
        }
        return Content($"{person}");
    }
}