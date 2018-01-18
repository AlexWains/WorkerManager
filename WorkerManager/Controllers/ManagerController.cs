using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkerManager.Models;

namespace WorkerManager.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        // add a worker
        public bool WorkerAdd(string IdCard, string FirstName, string SirName, string Phone, string Mail)
        {
            bool k = false;// checks if worker was added
            bool helper = true;// checks if worker exists in DB
            using (var db = new WorkerContext())
            {
                foreach (var item in db.Workers)
                {
                    if(IdCard== item.IdCard)
                    {
                        helper = false;
                    }
                }
                if (helper)
                {
                    db.Workers.Add(new Worker { IdCard = IdCard, FirstName = FirstName, SirName = SirName, Phone = Phone, Mail = Mail , UserDetail = AddUser(IdCard, Phone)});
                    db.SaveChanges();
                    k = true;
                }
            }
            return k;
        }
        public ActionResult AddWorker()
        {
            return View();
        }

        public void DeleteDB()
        {
            using (var db = new WorkerContext())
            {
                db.Database.Delete();
            }
        }


        public User AddUser(string IdCard, string Phone)
        {
            return new User { Password = Phone, Username = IdCard };
        }
    }
}