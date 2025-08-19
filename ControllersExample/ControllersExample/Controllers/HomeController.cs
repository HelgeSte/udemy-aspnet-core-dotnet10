using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers;

    public class HomeController
    {
        [Route("sayhello")] // Press F12 when cursor is over Route, to go to decleration
        public string method1()
        {
            return "Hello from method1";
        }
    }


