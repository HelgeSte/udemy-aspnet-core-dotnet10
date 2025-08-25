using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
    [Route("book")]
    // GET
    //public FileResult Index() // cannot use return Content()
    public IActionResult Index() // Can return both Content() and File() results 
    {
        // Book id should be applied
        if (!Request.Query.ContainsKey("bookid"))
        {
            return Content("Book id is not supplied");  
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            return Content("Book id can't be null or empty");
        }
        
        // Bookd id should be between 1 and 1000
        int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
        if (bookId <= 0)
        {
            return Content("Book id can't be less than or equal to Zero");
        }

        if (bookId > 1000)
        {
            return Content("Book id can't be greater than 1000");
        }
        
        // isLoggedin should be tru
        if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
        {
            Response.StatusCode = 401;
            return Content("User must be authenticated");
        }

        return File("/sample.pdf",  "application/pdf");
    }
}