using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    public class SchoolClass
    {
       // [Key, Column("ClassID")]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("HouseMaster")]
        public int? HouseMasterId { get; set; }
        public virtual User HouseMaster { get; set; }


        public virtual ICollection<User> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

       
    }
}
