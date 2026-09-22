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
    public class CountryController : ControllerBase
    {
        private readonly LocationService locationService;
        public CountryController(LocationService locationService)
        {
            this.locationService = locationService;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult Get()
        {
            var countries = locationService.GetAllCountries();
            return Ok(countries);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id:int}")]
        public Country Get(int id)
        {
            var country=locationService.GetCountry(id);
           return country;
        }
        [HttpGet]
        [Route("GetName/{name}/{id}")]
        public Boolean GetName(string name,int id)
        {
            var flag= locationService.GetCountryName(name,id);
            if (flag == null) { return false; }
            else return true;
        }
        // POST api/<CountryController>
        [HttpPost]
        public IActionResult Post(Country country)
        {
            locationService.AddCountry(country);
            return Ok();
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]Country country)
        {
            locationService.UpdateCountry(id,country);
            return Ok();
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            locationService.RemoveCountry(id);
            return Ok();
        }
    }
}
