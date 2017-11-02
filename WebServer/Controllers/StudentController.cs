using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{

    public class StudentController : ApiController
    {
        BussinessDbContext db = new BussinessDbContext();
        /// AppContext db = new AppContext();
        public List<Student> Get()
        {
            List<Student> stdList = new List<Student>();
            stdList = db.Students.ToList();
            return stdList;
        }

        public bool Post(Student student)
        {
            if (student != null)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return true;
        }

        public bool Put(int id)
        {
            Student std = db.Students.Find(id);
            db.Entry(std).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            Student std = db.Students.Find(id);
            if (std != null) db.Students.Remove(std);
            db.SaveChanges();
            return true;
        }
    }
}
