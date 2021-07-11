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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=MyDb.db", b=>b.MigrationsAssembly("DMS"));
        }
    }
}
