using DMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Data
{
    public class DMSDataContext : DbContext
    {
        public DbSet<Age_Bracket> Age_Bracket { get; set; }
        public DbSet<Activity_Type> Activity_Type { get; set; }
        public DbSet<Contact_Type> Contact_Type { get; set; }
        public DbSet<Person_Type> Person_Type { get; set; }

        public DbSet<Person> Person { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Student_Room> Student_Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=MyDb.db", b => b.MigrationsAssembly("DMS"));
        }
    }
}
