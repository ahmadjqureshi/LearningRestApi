using EmployeeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee newEmployee)
        {
            EntityEntry<Employee> result = await appDbContext.Employees.AddAsync(newEmployee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            Employee result = appDbContext.Employees.Where( x => x.ID == employeeId).FirstOrDefault();

            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }
            
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.ID == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.Include(x => x.Department).ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmplyee)
        {
            Employee result = appDbContext.Employees.Where(x => x.ID == updatedEmplyee.ID).FirstOrDefault();

            if (result != null)
            {
                result.DepID = updatedEmplyee.DepID;
                result.Designation = updatedEmplyee.Designation;
                result.EmpGender = updatedEmplyee.EmpGender;
                result.FirstName = updatedEmplyee.FirstName;
                result.LastName = updatedEmplyee.LastName;
                result.ImagePath = updatedEmplyee.ImagePath;

                appDbContext.Employees.Update(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> SearchEmp(string firstName, string LastName, string designation)
        {
            try
            {
                IList<Employee> employees = await appDbContext.Employees.Where(
                                                  x => x.FirstName.Contains(firstName) ).ToListAsync();

                if (LastName != string.Empty)
                {
                    employees = await appDbContext.Employees.Where(
                                                  x => x.LastName.Contains(LastName)).ToListAsync();
                }

                if (designation != string.Empty)
                {
                    employees = await appDbContext.Employees.Where(
                                                  x => x.Designation.Contains(designation)).ToListAsync();
                }

                return employees;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
