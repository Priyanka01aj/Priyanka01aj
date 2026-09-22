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
    public class CityController : ControllerBase
    {
        private readonly LocationService locationService;
        public CityController(LocationService locationService)
        {
            this.locationService = locationService;
        }
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return locationService.GetAllCities();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public City Get(int id)
        {
            return locationService.GetCity(id);
        }
        [HttpGet]
        [Route("GetIsExistCity/{name}/{id}")]
        public Boolean GetIsExistCity(string name,int id)
        {
            var flag= locationService.GetCityName(name,id);
            if (flag == null) { return false; }
            else return true;
        }
        [HttpGet]

        [Route("GetCities/{id}")]
        public List<City> GetCities(int id)
        {
            return locationService.GetCityByStateId(id);
        }
        //[HttpGet]
        //[Route("GetStateIdByCityId/{cityid}")]
        //public State GetStateIdByCityId(int id)
        //{
        //    return locationService.GetStateByCityId(id);
        //}
        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] City city)
        {
            locationService.AddCity(city);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City city)
        {
            locationService.UpdateCity(id, city);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            locationService.RemoveCity(id);
        }
    }
}
