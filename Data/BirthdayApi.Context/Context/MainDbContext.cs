using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BirthdayApi.Context
{
    public class MainDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public MainDbContext(DbContextOptions<MainDbContext> opts) : base(opts)
        {
        }
        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<BirthdayDate> birthdayDates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Birthday>().ToTable("birthdays");
            modelBuilder.Entity<BirthdayDate>().ToTable("dates");

        }
    }
}
