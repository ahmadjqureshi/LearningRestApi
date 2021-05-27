using EmployeeModels;
using EmployeeWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApp.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Emp { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int id = int.Parse(Id);

            Emp = await EmployeeService.GetEmployee(id);
        }
    }
}
