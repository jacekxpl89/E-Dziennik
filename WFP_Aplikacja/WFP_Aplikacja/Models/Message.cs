using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
   public class Message
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey("User_from")]
        public int? User_from_ID { get; set; }
        public virtual User User_from { get; set; }

        [ForeignKey("User_to")]
        public int? User_to_ID { get; set; }
        public virtual User User_to { get; set; }

        public string Title { get; set; }
        public string Context { get; set; }
    }
}
