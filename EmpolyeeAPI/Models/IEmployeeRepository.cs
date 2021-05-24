using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeAPI.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee newEmployee);
        Task<Employee> UpdateEmployee(Employee updatedEmplyee);
        Task<Employee> DeleteEmployee(int employeeId);
    }
}
