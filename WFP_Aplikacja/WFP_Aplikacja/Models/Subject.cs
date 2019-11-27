using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    
  

  public class Subject
    {
        [Key, Column("SubjectID")]
         public int ID { get; set; }
         public string Name { get; set; }


        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public virtual User Teacher { get; set; }

        public int? SchoolClassId { get; set; }
        [ForeignKey("SchoolClassId")]
        public virtual SchoolClass SchoolClass { get; set; }





    }
}
