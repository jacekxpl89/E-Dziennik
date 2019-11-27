using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
    class DB_SchoolClass_controler : I_DB_Controler<SchoolClass>
    {
        public List<SchoolClass> Get()
        {
            using (var db = new Schoolcontext())
            {
                return db.school_classes.Include("Students").Include("Subjects").Include("Students.User_data").Include("HouseMaster").Include("HouseMaster.User_data").ToList();
            }
        }

        public SchoolClass Get(int id)
        {
            using (var db = new Schoolcontext())
            {
                return db.school_classes.Include("Subjects").Include("Subjects").Include("Students.User_data").Include("HouseMaster").Include("HouseMaster.User_data").FirstOrDefault(u => u.ID == id);
            }
        }

        public void Insert(SchoolClass data)
        {
            using (var db = new Schoolcontext())
            {
                if (db.school_classes.Where(c => c.Name == data.Name).Count() != 0)
                    return;



                var list_of_students = data.Students;
                var list_of_subjects = data.Subjects;

                data.Students = new List<User>();
                data.Subjects = new List<Subject>();

                db.school_classes.Add(data);
                db.SaveChanges();

                int id = data.ID;
              
                
                foreach(var o in list_of_students)
                {
                    db.Users.Where(u => u.ID == o.ID).First().SchoolClassId = data.ID;
                    db.SaveChanges();
                }
                foreach (var o in list_of_subjects)
                {
                    db.Subjects.Where(u => u.ID == o.ID).First().SchoolClassId = data.ID;
                    db.SaveChanges();
                }

            }
        }

        public void Insert(List<SchoolClass> data)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            using (var db = new Schoolcontext())
            {
                try
                {

                    foreach (var u in db.school_classes)
                    {
                        db.school_classes.Remove(u);
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

                    SchoolClass sc = db.school_classes.Where(u => u.ID == ID).First();
                    if (sc != null)
                    {
                        db.school_classes.Remove(sc);
                    }
                    db.SaveChanges();

                }
                catch
                {

                }
            }
        }

        public void Update(SchoolClass data)
        {
            throw new NotImplementedException();
        }
    }
}
