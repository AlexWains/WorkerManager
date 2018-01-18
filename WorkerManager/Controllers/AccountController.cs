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

        //GET: Account/LoginPage
        public ActionResult LoginPage()
        {
            return View();
        }

        //GET: Account/RegisterPage
        public ActionResult RegisterPage()
        {
            return View();
        }


        //GET: Account/AdminRegister?
        public void AdminRegister(string IdentityCard, string Name, string Password)
        {

            using (var db = new AdminContext())
            {
                db.Admins.Add(new Admin { IdentityCard = IdentityCard, Name = Name, Password = Password });
                db.SaveChanges();
            }

        }
        //GET: Account/AdminLogin?
        public bool AdminLogin(string IdentityCard, string Password)
        {
            bool exis = false;
            using (var db = new AdminContext())
            {
                foreach (var item in db.Admins)
                {
                    if (item.IdentityCard == IdentityCard && item.Password == Password)
                    {
                        exis = true;
                    }

                }
            }
            return exis;
        }

        //Dletes the current DB. 
        public void DeleteDB()
        {
            using (var db = new AdminContext())
            {
                db.Database.Delete();
            }
        }

    }
}