using EmployeeModels;
using EmployeeWebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApp.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Emp { get; set; } = new Employee();

        protected string MouseCordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int id = int.Parse(Id);

            Emp = await EmployeeService.GetEmployee(id);
        }

        protected void Mouse_Move (MouseEventArgs e)
        {
            MouseCordinates = $"Y Cordinates: {e.ClientY} X Cordinates: {e.ClientX}";
        }

        protected void Mouse_Out(MouseEventArgs e)
        {
            MouseCordinates = "";
        }

        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
