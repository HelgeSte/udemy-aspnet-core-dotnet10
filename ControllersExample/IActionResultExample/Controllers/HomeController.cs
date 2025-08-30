using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;
namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
        // Route data has higher priority than query strings
    // bookstore/123/true?bookid=1552&isloggedin=false -> Book id: 123
    [Route("bookstore/{bookid?}/{isloggedin?}")] // ? -> optional parameters 
    // Relative url: bookstore/5000/true, absolute url: https://vg.no/bookstore/5000/true
    public IActionResult Index([FromRoute] int? bookid, [FromRoute] bool? isloggedin, Book book) // bookstore/50?b&isloggedin=true
    {
        // model binding instead of !Request.Query.ContainsKey("bookid"))'
        if (bookid.HasValue == false)
        {
            return BadRequest("Book id is not supplied or empty");
        }

        if (bookid <= 0)
        {
            return BadRequest("Book id can't be less than or equal to 0");
        }

        if (bookid > 1000)
        {
            // Treating this as a NotFound (404) error
            return NotFound("Book id can't be greater than 1000");
        }

        //if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
        if (isloggedin == false)
        {
            return Unauthorized("User must be authenticated");
        }

        return Content($"Book id:  {bookid}, Book: {book}", "text/plain");
    }
}