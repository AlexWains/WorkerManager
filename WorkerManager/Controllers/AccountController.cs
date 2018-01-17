using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkerManager.Models;

namespace WorkerManager.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult RegisterPage()
        {
            return View();
        }

        public void AdminRegister(string IdentityCard, string Name, string Password)
        {
            using (var db = new AdminContext())
            {
                //db.Database.Delete();
                db.Admins.Add(new Admin { IdentityCard = IdentityCard, Name = Name, Password = Password });
                db.SaveChanges();
            }
        }




        public bool AdminLogin(string IdentityCard, string Password)
        {
            using (var db = new AdminContext())
            {
                foreach (var item in db.Admins)
                {
                    if (item.IdentityCard == IdentityCard && item.Password == Password)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        
    }
}