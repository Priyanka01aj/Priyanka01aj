using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.Components;
using BlazorApplication.Services;
using EmployeeLib;
using EmployeeLib.Models;
using EmployeeLib.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApplication.Pages
{
    public partial class EmployeeOverview
    {
        public IEnumerable<Employee> Employees { get; set; }=new List<Employee>();
        [Inject]
        public IEmployeeService employeeService {get;set;}

        protected AddEmployee AddEmployee { get; set; }
        protected async override Task<Task> OnInitializedAsync()
        {
            Employees = await employeeService.GetEmployees();
            //setEmployeeData();
            return base.OnInitializedAsync();
        }

        protected void QuikAddEmployee()
        {
            AddEmployee.Show();
        }
        //private void setEmployeeData()
        //{
        //    Employees = new List<Employee>()
        //    {
        //    new Employee { Id = 1, FirstName = "Priyanka", LastName = "Ajmera" },
        //    new Employee { Id = 2, FirstName = "Monish", LastName = "Shah" },
        //    new Employee { Id = 3, FirstName = "Karan", LastName = "Patel" }
        //    };
        //}
    }
}
