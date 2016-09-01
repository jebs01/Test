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
            
            return View();

        }

        [HttpPost]
        public ActionResult Logon(Users Logonmodel)
        {
           // var Email = Convert.ToString();
            var Email = Logonmodel.Email;
            var password = Logonmodel.Password;

        if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("EmptyEmail", "Did you provide your e-mail address?");
                ModelState.AddModelError("EmptyPassword", "Did you provide your password?");
                return View("Logon");

            }

            //  var books = from b in LibraryManagement.Users select b;
            if (ModelState.IsValid)
            {
                //1. Username and password success : Done
                //2. Username not found : Done
                //3. Username valid but password is not : Done
                //4. After 3 invalid attempts user account gets locked : Done
                //5. TimeStamp last login : Done
                //6. Encrypted password : Not done
                //7. Validate Email : Not done

                using (UserManagement context = new UserManagement())
                {
                    // List<Users> userDB = context.Users.ToList();


                    var userDB = context.Users.FirstOrDefault(u => u.Email == Logonmodel.Email);
                    if (userDB != null)
                    {

                        #region LoginValidation
                        if (userDB.IsActive ==0)
                        {
                            ModelState.AddModelError("", "User inactive. Please contact Admin");                          
                            return View("Logon");
                        }

                        if (userDB.IsLocked == 1)
                        {
                            ModelState.AddModelError("", "User locked out. Please contact Admin");
                            return View("Logon");
                        }

                        if (userDB.IsVerified == 0)
                        {
                            ModelState.AddModelError("", "User email ID not verified. Please check your email");
                            return View("Logon");
                        }

                        if (userDB.InvalidAttempts >= 3)
                        {
                            ModelState.AddModelError("", "User Account locked out");
                            userDB.InvalidAttempts = userDB.InvalidAttempts + 1;
                            context.SaveChanges();
                            return View("Logon");
                        }

#endregion

                        #region LoginSucessOrFailure
                        if (userDB.Password == Logonmodel.Password &&
                            userDB.InvalidAttempts <3 )
                        {
                            userDB.InvalidAttempts = 0;
                            userDB.LastLoginDateTime = DateTime.Now;

                            context.SaveChanges();
                            return View("Dashboard");
                        }
                        
                        else if (userDB.Password != Logonmodel.Password)
                        {
                            ModelState.AddModelError("", "Invalid Password, Please try again.");
                            userDB.InvalidAttempts = userDB.InvalidAttempts + 1;
                            context.SaveChanges();
                            return View("Logon");
                        }

                        #endregion
                     



                    }

                    else
                    {
                        ModelState.AddModelError("NoUserFound", "User not found");
                        return View("Logon");
                    }




                }
            }
            //   ViewBag.Message = "Email";

            {
                var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();
                return View("Logon");

            }

                // return RedirectToAction("Contact");
            


        }
    }
}