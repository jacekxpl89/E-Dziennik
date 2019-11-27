using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
   public class DB_Subject_Controler : I_DB_Controler<Subject>
    {
        public void Insert(Subject data)
        {
            using (var db = new Schoolcontext())
            {


              try
                {
                    if (db.Subjects.SingleOrDefault(s => s.Name == data.Name && s.TeacherId == data.TeacherId) != null)
                    {
                        return;
                    }

                    db.Subjects.Add(data);
                    db.SaveChanges();
                }
                catch
                {

                }
              
            }
          
        }
        public void Update(Subject data)
        {
            throw new NotImplementedException();
        }

        public List<Subject> Get()
        {
            using (var db = new Schoolcontext())
            {
                return db.Subjects.Include("Teacher").Include("Teacher.User_data").ToList();
            }
        }

        public Subject Get(int id)
        {
            using (var db = new Schoolcontext())
            {
                return db.Subjects.Include("Teacher").Include("Teacher.User_data").FirstOrDefault(u => u.ID == id);
            }
        }

        public void Remove()
        {
            using (var db = new Schoolcontext())
            {
                try
                {

                    foreach (var u in db.Subjects)
                    {
                        db.Subjects.Remove(u);
                    }
                    db.SaveChanges();

                }
                catch
                {

                }
            }
        }

        public void Remove(int ID)
        {
            using (var db = new Schoolcontext())
            {
                try
                {

                    Subject subject = db.Subjects.Where(u => u.ID == ID).First();
                    if (subject != null)
                    {
                        db.Subjects.Remove(subject);
                    }
                    db.SaveChanges();

                }
                catch
                {

                }
            }
        }

        public void Insert(List<Subject> data)
        {
            throw new NotImplementedException();
        }
    }
}
