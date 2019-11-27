using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
    class DB_message_controler : I_DB_Controler<Message>
    {
        public List<Message> Get()
        {
            using (var db = new Schoolcontext())
            {
                return db.Messages.Include("User_from").Include("User_from.User_data").Include("User_to").Include("User_to.User_data").ToList();
            }
        }

        public Message Get(int id)
        {
            using (var db = new Schoolcontext())
            {
                return db.Messages.Include("User_from").Include("User_from.User_data").Include("User_to").Include("User_to.User_data").FirstOrDefault(u => u.ID == id);
            }
        }

        public void Insert(Message data)
        {
            using (var db = new Schoolcontext())
            {
                db.Messages.Add(data);
                db.SaveChanges();
            }
        }

        public void Insert(List<Message> data)
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

        public void Update(Message data)
        {
            throw new NotImplementedException();
        }
    }
}
