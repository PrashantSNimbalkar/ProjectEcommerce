using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerce.DAL;
using Microsoft.AspNetCore.Session;

namespace ProjectEcommerce.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult AllUsers()
        {
            var model = UserDAL.GetAllUsers();
            return View(model);
        }
       
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            User user = UserDAL.VerifyLogin(u);
            if (user.u_password==u.u_password)
            {
                HttpContext.Session.SetString("username", user.u_name);         
                HttpContext.Session.SetString("userid", user.u_id.ToString());

                if (user.u_roleid == 1)
                    return RedirectToAction("Index","Product");
                else
                    return RedirectToAction("Admin", "Product");
            }            
            return View();
        }

        // GET: UserController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            try
            {
                int result = UserDAL.AddUser(u);
                if (result == 1)
                    return RedirectToAction("Login");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewProfile(int id)
        {
            User user = UserDAL.GetUserById(id);
            return View(user);
        }


        // GET: UserController/Edit/5
        public ActionResult EditProfile(int id)
        {
            User user=UserDAL.GetUserById(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(int id, User u)
        {
            try
            {
                int result = UserDAL.UpdateUser(u);
                if (result == 1)
                    return RedirectToAction("ViewProfile", "User", new { id });
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
