using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    
    public enum  E_Person_type
    {
       student,teacher,secretary,headmaster,admin
    }

  public class User
    {
        [Key, Column("UserID")]
        public int ID { get; set; }
        
        public string Login { get; set; }

        public string Password { get; set; }

        public int User_dataID { get; set; }
        public virtual User_data User_data { get; set; }

        public int? SchoolClassId { get; set; }
        [ForeignKey("SchoolClassId")]
        public virtual SchoolClass SchoolClass { get; set; }
    


        public static User Temp_user(string name)
        {
            var user = new User();
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://media.salon.com/2019/04/suprised-man.jpg");


            user.Login = name;
            user.Password = "1234";

            var user_data = user.User_data = new User_data();

            user_data.Name = name;
            user_data.LastName = "Kowalski";
            user_data.Pesel = "143254344";
            user_data.Phone = "695 695 456";
            user_data.Street = "Piękna 5/50";
            user_data.Emile = name + "12pl@gmail.com";
            user_data.Birthday = DateTime.Today;
            user_data.Premission = E_Person_type.student;


            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                user_data.Photo = ms.ToArray();
            }

            return user;
        }


        public static List<User> Generate_Random_data(int j)
        {
            List<User> new_users = new List<User>(); 
 













            List<string> Names = new List<string>(){ "Ziemowit", "Radzimir", "Gniewomir", "Mieszko", "Krzesimir", "Tadeusz", "Jacenty", "Ignacy", "Wacław", "Zbyszko", "Roch", "Wit", "Szczepan", "Wincenty" };
            List<string> lastNames = new List<string>() { "Nowak", "Kowalski", "Kowalski", "Wójcik", "Kowalczyk" };
            List<string> streets = new List<string>() { "Polna", "Leśna", "Słoneczna", "Krótka", "Szkolna","Ogrodowa","Brzozowa" };
            Random r= new Random();
            for (int i=0;i<j;i++)
            {
                User temp = new User();
                
                temp.Password = Generate_Numbers(10, r);
                temp.User_data = new User_data();
                temp.User_data.Pesel = Generate_Numbers(11, r);
                temp.User_data.Name = Names[r.Next(0, Names.Count() - 1)];
                temp.User_data.LastName = lastNames[r.Next(0, lastNames.Count() - 1)];
                temp.User_data.Phone = Generate_Numbers(9, r);
                temp.User_data.Street = streets[r.Next(0, streets.Count() - 1)] + " " + Generate_Numbers(1, r) + "/" + Generate_Numbers(2, r);
                temp.User_data.Emile = temp.User_data.Name +Generate_Numbers(2,r)+ "@gmail.com";
                temp.User_data.Birthday = DateTime.Today;
                temp.User_data.Premission = (E_Person_type)r.Next(0, 4);
                temp.Login = temp.User_data.Name + Generate_Numbers(3, r);
                new_users.Add(temp);
            }

            return new_users;
        }

       private static string Generate_Numbers(int j ,Random r)
        {
            string result = "";
          
            for (int i = 0; i < j; i++)
            {
               result += r.Next(0, 9).ToString();
            }
            return result;
        }

     
    }
}
