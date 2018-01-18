using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkerManager.Models
{
    //Admin class
    //Allowed to add and remove managers, workers
    public class Admin
    {
        public int Id { get; set; }
        public string IdentityCard { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    class AdminContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
    }

    
}