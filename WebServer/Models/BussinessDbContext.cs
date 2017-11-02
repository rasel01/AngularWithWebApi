using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    public class BussinessDbContext:DbContext
    {
        public BussinessDbContext():base("DefaultBusinessConnection")
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}