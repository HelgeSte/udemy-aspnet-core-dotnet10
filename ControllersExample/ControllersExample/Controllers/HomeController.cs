using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers;

    public class HomeController : Controller // Controller is the parent class, and is needed for the Content method
    {
        [Route("home")] // Press F12 when cursor is over Route, to go to decleration
        [Route("/")]
        public ContentResult Index()
        {
            // return new ContentResult() { Content = "Hello from Index.", ContentType = "text/plain" };
            // return Content("Hello from index", "text/plain"); 
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Helge",
                LastName = "Stegemoen",
                Age = 54
            };
            //return "{ \"key\": \"value\" }";
            // better to write it as json
            return new JsonResult(person);    
            
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            // VirtualFileResult when the file is in the wwwroot folder
            // Use PhysicalFileResult if the file is outside wwwroot/default webroot 
            //return new VirtualFileResult("/Sample.pdf", "application/pdf");
            return File("/Sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownloadWatusi()
        {
            //return new PhysicalFileResult("E:\\gitkraken-repos\\udemy-aspnet-core-dotnet10\\watusi.pdf", "application/pdf");
            return PhysicalFile("E:\\gitkraken-repos\\udemy-aspnet-core-dotnet10\\watusi.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            // No need to escape backslashes
            byte[] bytes = System.IO.File.ReadAllBytes(@"E:\gitkraken-repos\udemy-aspnet-core-dotnet10\montuno.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");

        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }
        
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        [Route("contact")]
        public string Contact()
        {
            return "Hello from Contact";
        }
        
        
    }


