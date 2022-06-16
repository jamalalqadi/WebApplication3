using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Department>  Departments { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<EmpRole> EmpRoles { get; set; }
        public DbSet<Job>  Jobs { get; set; }
        public DbSet<PersonalData>  PersonalDatas { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().Property(s => s.Name).IsRequired();
        }
    }
}
