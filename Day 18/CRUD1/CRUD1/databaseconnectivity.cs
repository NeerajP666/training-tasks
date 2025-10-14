using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUD1.Models;

namespace CRUD1
{
    public class databaseconnectivity:DbContext
    {
        public databaseconnectivity() : base("mydbconnection") { }
        public DbSet<User> users {  get; set; }
        
    }
}