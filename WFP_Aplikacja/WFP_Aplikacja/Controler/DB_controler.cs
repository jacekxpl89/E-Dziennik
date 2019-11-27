using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Controler
{
   public class DB_controler
    {

      


        public static List<User> Get_users_task()
        {
            using (var db = new Schoolcontext())
            {
               
                    return db.Users.Include("User_data").ToList<User>();
               
            }
           
          
        }
        public static User Get_user_task(int id)
        {
            using (var db = new Schoolcontext())
            {


                return db.Users.Single(a => a.ID == id);


            }
          

        }
        public static async Task<bool> Add_user_task(User user)
        {
            //Sprawdza czy podany login jest dostępny
           
            using( var db = new Schoolcontext())
            {
                if (db.Users.Where(u => u.Login.Equals(user.Login)).Count() != 0)
                {
                    return false;
                }
                try
                {
                    await Task.Run(() => {
                       db.Users.Add(user);
                       db.SaveChanges();
                    });
                }
                catch
                {
                    return false;
                }
            }
           

            return true;
        }
    
      public static async Task<bool> Update_user_task(User new_data)
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        User user = db.Users.Where(u => u.ID.Equals(new_data.ID)).First();
                        if (user != null)
                        {
                            user = new_data;
                        }
                        db.SaveChanges();
                    });
                }
                catch
                {
                    return false;
                }
            }
        return true;
    }

        public static void Remove_user(int ID)
        {
            using (var db = new Schoolcontext())
            {
                try
                {
                  
                        User user = db.Users.Where(u => u.ID == ID).First();
                        if (user != null)
                        {
                            db.Users.Remove(user);
                        }
                        db.SaveChanges();
                   
                }
                catch
                {
                  
                }
            }
          
        }

        public static void Remove_ALL()
        {
            using (var db = new Schoolcontext())
            {

                db.Messages.RemoveRange(db.Messages);
                db.Mark.RemoveRange(db.Mark);
                db.Subjects.RemoveRange(db.Subjects);
                db.school_classes.RemoveRange(db.school_classes);
                db.Users.RemoveRange(db.Users);
                        db.SaveChanges();
                   
                }
               
            }
           
        }


    
}
