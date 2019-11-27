using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    
   

  public class User_data
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string LastName { get; set; }

        public string Street { get; set; }

        public string Emile { get; set; }
        
        public string Pesel { get; set; }

        public string Phone { get; set; }

        public virtual DateTime? Birthday { get; set; }

        public byte[] Photo { get; set; }

        public E_Person_type? Premission { get; set; }

        public User_data()
        {
            Photo = new byte[300*300*32];
        }

    }
}
