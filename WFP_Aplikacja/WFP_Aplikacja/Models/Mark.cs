using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{


    public class Mark
    {
        [Key]
        public int ID { get; set; }

        public int mark { get; set; }
        
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public virtual User Student { get; set; }

        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

    }
}
