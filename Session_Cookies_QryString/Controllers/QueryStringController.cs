using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_Cookies_QryString.Controllers
{
    public class QueryStringController : Controller
    {
        ///QueryString/QueryTest? name = Jenna Doe

        public IActionResult QueryTest()
        {
            string name = "John Doe";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
                name = HttpContext.Request.Query["name"];

            return Content("Name from query string: " + name);
        }

    }
}
