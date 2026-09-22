using EmployeeLib.Models;
using EmployeeLib.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
            private readonly EmployeeService employeeService;
            public EmployeeController(EmployeeService employeeService)
            {
                this.employeeService = employeeService;
            }
            // GET: api/<EmployeeController>
            [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeService.GetEmployees();
        }
       
       

       
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeService.GetEmployees(id);
        }
        [HttpGet]
        [Route("GetEmployeeEmail/{email}/{id}")]
        public Boolean GetEmployeeEmail(string email,int id)
        {
             var flag=employeeService.GetEmployeeEmail(email,id);
            if (flag == null) { return false; }
            else return true;
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            employeeService.AddEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            employeeService.UpdateEmployee(id, employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeService.RemoveEmployee(id);
        }
    }
}
