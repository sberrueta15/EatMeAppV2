using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EatMeApp.Models
{
    public class AppDbContext : DbContext
    {

        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //: base(options)
        //{ }

        public AppDbContext()
        : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=santiago;Host=localhost;Port=5432;Database=EatMeApp;Pooling=true;");
        }

        public DbSet<Event> Eventos { get; set; }

    }
}
