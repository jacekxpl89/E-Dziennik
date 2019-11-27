using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
    class DB_mark_controler : I_DB_Controler<Mark>
    {
        public List<Mark> Get()
        {
            using (var db = new Schoolcontext())
            {
                return db.Mark.Include("Student").Include("Student.User_data").Include("Subject").ToList();
            }
        }
      
        public Mark Get(int id)
        {
            using (var db = new Schoolcontext())
            {
           return db.Mark.Include("Student").Include("Student.User_data").Include("Subject").FirstOrDefault(u => u.ID == id);
            }
        }

        public void Insert(Mark data)
        {
            using (var db = new Schoolcontext())
            {
                db.Mark.Add(data);
                db.SaveChanges();
            }
        }

        public void Insert(List<Mark> data)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Mark data)
        {
            throw new NotImplementedException();
        }
    }
}
