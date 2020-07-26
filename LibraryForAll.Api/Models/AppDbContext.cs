using LaibraryForAll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryForAll.Api.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                PersonName = "Bakhtiyor",
                Surname = "Esanov"

            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 2,
                PersonName = "Name2",
                Surname = "Surname2"
            });

        }
    }
}
