using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModels;
using System.Threading;

namespace EmployeeWebApp.Pages
{
    public class EmployeeListBase : ComponentBase
    {

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            Thread.Sleep(5000);

            Employee e1 = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Designation = "CEO",
                ID = 1,
                EmpGender = Gender.Male,
                DepID = 1,
                ImagePath = "/img/John.jpeg",
            };

            Employee e2 = new Employee
            {
                FirstName = "Ahmad",
                LastName = "Qureshi",
                Designation = "Tea boy",
                ID = 2,
                EmpGender = Gender.Male,
                DepID = 2,
                ImagePath = "/img/TeaBoy.jpeg",
            };

            Employees = new List<Employee> { e1, e2 };
        }
    }
}
