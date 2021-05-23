using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeAPI.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Department GetDepartment(int depId)
        {
            return appDbContext.Departments.FirstOrDefault(x => x.DepID == depId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments.ToList();
        }
    }
}
