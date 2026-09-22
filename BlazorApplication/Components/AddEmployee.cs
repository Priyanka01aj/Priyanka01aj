using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.Services;
using EmployeeLib;
using EmployeeLib.Models;
using EmployeeLib.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApplication.Components
{
    public partial class AddEmployee
    {
        public Employee Employee { get; set; }= new Employee();
        [Inject]
        public IEmployeeService employeeService { get; set; }

        public bool ShowDialog { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { Id = 0, FirstName = "James" };
        }
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        
        protected void HandleValidSubmit()
        {
            employeeService.AddEmployee(Employee);
            ShowDialog = false;
            StateHasChanged();
        }
    }
}
