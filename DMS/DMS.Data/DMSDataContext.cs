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
        public DbSet<Person_Room> Person_Room { get; set; }
        public DbSet<RoomGeneralInfo_List> RoomGeneralInfo_List { get; set; }
        public DbSet<Students_List> Students_List { get; set; }
        public DbSet<Person_Student> Parent_Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=MyDb.db", b => b.MigrationsAssembly("DMS"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomGeneralInfo_List>(eb => { eb.ToView("RoomGeneralInfo_List"); eb.HasKey("Room_Id"); });
            modelBuilder.Entity<Students_List>().ToView(nameof(Students_List)).HasKey(v => v.Student_Id);
            modelBuilder.Entity<Students_OutOfRoomAgeBracket_List>(x => { x.ToView("Students_OutOfRoomAgeBracket_List"); x.HasKey("Room_Id"); });
        }
    }
}
