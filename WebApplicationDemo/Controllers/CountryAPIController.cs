using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        private readonly LocationService locationService;
        public CountryAPIController(LocationService locationservice)
        {
            this.locationService = locationservice;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public List<Country> Get()
        {
            var countries = locationService.GetCountries();
            return countries;
        }

        // GET api/<CountryController>/5
        [HttpGet("{id:int}")]
        public Task<Country> Get(int id)
        {
            var country = locationService.GetCountry(id);
            return country;
        }
        [HttpPost]
        public Boolean Post(Country country)
        {
            locationService.AddCountry(country);
            return true;
        }
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] Country country)
        {
           locationService.UpdateCountry(country);
            return true;
        }
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            locationService.DeleteCountry(id);
            return true;
        }
        [HttpGet]
        [Route("GetName/{name}/{id}")]
        public Boolean GetName(string name, int id)
        {
            var flag = locationService.GetCountryName(name, id);
            if (flag) { return false; }
            else return true;
        }
    }
}
