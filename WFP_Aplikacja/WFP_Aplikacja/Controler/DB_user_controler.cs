using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
    class DB_user_controler : I_DB_Controler<User>
    {
        public List<User> Get()
        {
            using (var db = new Schoolcontext())
            {
                return db.Users.Include("User_data").ToList();
            }
        }

        public User Get(int id)
        {
            using (var db = new Schoolcontext())
            {
                return db.Users.Include("User_data").FirstOrDefault(u => u.ID == id);
            }
        }

        public void Insert(User data)
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                    if (db.Users.SingleOrDefault(u => u.Login== data.Login) != null)
                    {
                        return;
                    }

                    db.Users.Add(data);
                    db.SaveChanges();
                }
                catch
                {

                }

            }
        }

        public void Insert(List<User> data)
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                    db.Users.AddRange(data);
                    db.SaveChanges();
                }
                catch
                {

                }

            }
        }

        public void Remove()
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                    db.Users.RemoveRange(db.Users);
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
                    User user = db.Users.SingleOrDefault(u => u.ID ==ID);

                    if (user == null) return;

                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                catch
                {

                }

            }
        }

        public void Update(User data)
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                    User user = db.Users.SingleOrDefault(u => u.ID == data.ID);

                    if (user == null) return;


                    user.Login = data.Login;
                    user.Password = data.Password;
                    user.SchoolClassId = data.SchoolClassId;
                    user.SchoolClass = data.SchoolClass;
                    user.User_data = data.User_data;
                    user.User_dataID = data.User_dataID;
                    db.SaveChanges();
                }
                catch
                {

                }

            }
        }
    }
}
