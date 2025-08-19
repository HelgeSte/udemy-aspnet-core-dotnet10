using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers;

    public class HomeController
    {
        [Route("home")] // Press F12 when cursor is over Route, to go to decleration
        [Route("/")]       
        public string Index()
        {
            return "Hello from method1";
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


