using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_Cookies_QryString.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private IHttpContextAccessor Accessor;

        public CookieController(IHttpContextAccessor _accessor)
        {
            this.Accessor = _accessor;
        }


        [HttpPost]
        public IActionResult WriteCookie(string name)
        {
            //Set the Expiry date of the Cookie.
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(30);

            //Create a Cookie with a suitable Key and add the Cookie to Browser.
            Response.Cookies.Append("Name", name, option);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReadCookie()
        {
            //Fetch the Cookie value using its Key.
            string name = this.Accessor.HttpContext.Request.Cookies["Name"];

            TempData["Message"] = name != null ? name : "undefined";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCookie()
        {
            //Delete the Cookie from Browser.
            Response.Cookies.Delete("Name");

            return RedirectToAction("Index");
        }
    }
}
