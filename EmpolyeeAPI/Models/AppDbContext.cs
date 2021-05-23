using EmployeeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department { DepID = 1, DepName = "Management" });
            modelBuilder.Entity<Department>().HasData(new Department { DepID = 2, DepName = "Tea Department" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Designation = "CEO",
                ID = 1,
                EmpGender = Gender.Male,
                DepID = 1,
                ImagePath = "/img/John.jpeg",
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                FirstName = "Ahmad",
                LastName = "Qureshi",
                Designation = "Tea boy",
                ID = 2,
                EmpGender = Gender.Male,
                DepID = 2,
                ImagePath = "/img/TeaBoy.jpeg",
            });

            
        }

    }
}
