using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
    [Route("bookstore")]
    /* GET
    //public FileResult Index() // cannot use return Content() */
    public IActionResult Index() // Can return both Content() and File() results 
    {
        // Book id should be applied
        if (!Request.Query.ContainsKey("bookid"))
        {
            /* Status codes: 400 = bad request, 401 = unauthorized, 500 = internal server error, etc.
            //return Content("Book id is not supplied");  
            //return new BadRequestResult(){}; // return an object */
            return BadRequest("Book id is not supplied"); // return a method
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            return BadRequest("Book id can't be null or empty");
        }
        
        // Bookd id should be between 1 and 1000
        int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
        if (bookId <= 0)
        {
            /*Response.StatusCode = 505; 
            //return Content("Book id can't be less than or equal to Zero");*/
            return StatusCode(401);
        }
        if (bookId > 1000)
        {
            // Treating this as a NotFound (404) error
            return NotFound("Book id can't be greater than 1000");
        }
        
        if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
        {
            return Unauthorized("User must be authenticated");
        }

        //return File("/sample.pdf",  "application/pdf");
        // RedirectToActionResult(<action-method-name>, <controller-name>, <classless object / anynymous object>, <permanent: true (301) / false (302)>);
        return new RedirectToActionResult("Books", "Store", new { }, true);
    }
}