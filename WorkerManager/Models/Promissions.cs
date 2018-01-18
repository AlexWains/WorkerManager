using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorkerManager.Models
{
    public class Manager : Worker
    {
        public bool Promission = true;
    }
    class ManagerContext: DbContext
    {
        public DbSet<Manager> Managers { get; set; }
    }
    public class Worker
    {
        public int ID { get; set; }
        public string IdCard { get; set; }
        public string FirstName { get; set; }
        public string SirName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public User UserDetail { get; set; }
    }
    class WorkerContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
    }
    public class User
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
