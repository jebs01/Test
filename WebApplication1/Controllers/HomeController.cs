using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        public ActionResult Logon()
        {
            //var Email = Request["Email"];
            // ViewBag.Message = "Your Logon page.";

            Users user1 = new Users();
             return View(user1);

           // return RedirectToAction("Contact");

         }

        public ActionResult Validate(Users user1)
        {
            //var Email = Convert.ToString();
            var Email = user1.Email;
            var password = user1.Password;

          //  var books = from b in LibraryManagement.Users select b;

            using (LibraryManagement context = new LibraryManagement())
            {
                List<Users> userDB = context.Users.ToList();

                if (userDB.Count>1)
                     View("Index");
                
                else
                    return View("Index");
            }

             //   ViewBag.Message = "Email";

            return View("Index");

            // return RedirectToAction("Contact");


        }
    }
}