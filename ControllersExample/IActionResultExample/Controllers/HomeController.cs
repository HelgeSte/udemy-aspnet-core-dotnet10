using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
    [Route("bookstore")]
    //Url: /bookstore?bookid=10&isloggedin=true
    public IActionResult Index() // Can return both Content() and File() results 
    {
        if (!Request.Query.ContainsKey("bookid"))
        {
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
        //return new RedirectToActionResult("Books", "Store", new { }, true);
        //return RedirectToActionPermanent("Books", "Store", new { id = bookId });
        //return new LocalRedirectResult($"store/books/{bookId}"); // cannot redirect to another application
        return LocalRedirectPermanent($"~/store/books/{bookId}"); // cannot redirect to another application
    }
}