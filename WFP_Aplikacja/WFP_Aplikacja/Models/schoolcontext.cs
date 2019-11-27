using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    
   

  public class Schoolcontext :DbContext
    {

        public Schoolcontext() : base("name=Schoolcontext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasOptional( u => u.SchoolClass).WithMany(s => s.Students).HasForeignKey(u => u.SchoolClassId);
            modelBuilder.Entity<Subject>().HasOptional(u => u.SchoolClass).WithMany(s => s.Subjects).HasForeignKey(u => u.SchoolClassId);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SchoolClass> school_classes { get; set; }
         
    }
}
