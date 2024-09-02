using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17_State_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["subject"] = "Maths";
            ViewBag.version = 10;

            ViewBag.colorList = new string[] { "red", "blue", "green" };

            TempData["language"] = "English";
            TempData["name"] = "Abhishek";
            TempData["age"] = 22;

            Session["username"] = "admin";


            HttpCookie MyCookie = new HttpCookie("role");
            MyCookie.Value = "Prime User Abhishek";
            MyCookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(MyCookie);

            return View();
        }

        public ViewResult About()
        {
            if(Request.Cookies["role"] != null)
            {
                ViewBag.msg = Request.Cookies["role"].Value;
            }
            else
            {
                ViewBag.msg = "Cookie expired";
            }
            return View();
        }
    }
}