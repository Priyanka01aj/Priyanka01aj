using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Services;
using WebApplicationDemo.Models;
namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly LocationService locationService;

        public EmployeeAPIController(LocationService locationService)
        {
            this.locationService = locationService;
        }
        [HttpGet]
        public List<Employee> Get()
        {
            return locationService.GetEmployees();
        }
     
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return locationService.GetEmployees(id);
        }
        [HttpGet]
        [Route("GetEmployeeEmail/{email}/{id}")]
        public Boolean GetEmployeeEmail(string email, int id)
        {
            var flag = locationService.GetEmployeeEmailId(email, id);
            if (flag) { return false; }
            else return true;
        }
        [HttpPost]
        public Boolean Post([FromBody] Employee employee)
        {
            if (locationService.AddEmployee(employee)) { return true; }
            else return false;
        }
        [HttpGet]

        [Route("GetStates/{id}")]
        public List<State> GetStates(int id)
        {
            return locationService.GetStateByCountryId(id);
        }
        [HttpGet]

        [Route("GetCities/{id}")]
        public List<City> GetCities(int id)
        {
            return locationService.GetCityByStateId(id);
        }
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] Employee employee)
        {
            if (locationService.UpdateEmployee(id, employee)) { return true; }
            else return false;
        }
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            if (locationService.RemoveEmployee(id)) { return true; }
            else return false;
        }
    }
}
