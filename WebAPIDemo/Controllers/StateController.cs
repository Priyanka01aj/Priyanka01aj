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
    public class StateController : ControllerBase
    {
        private readonly LocationService locationService;
        public StateController(LocationService locationService)
        {
            this.locationService = locationService;
        }
        // GET: api/<StateController>
        [HttpGet]
        public IEnumerable<State> Get()
        {
            var states=locationService.GetAllStates();
            
            return states;
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public State Get(int id)
        {
            return locationService.GetState(id);
        }
        [HttpGet]

        [Route("GetStates/{id}")]
        public List<State> GetStates(int id)
        {
            return locationService.GetStateByCountryId(id);
        }
        [HttpGet]
        [Route("GetIsExistState/{name}/{id}")]
        public Boolean GetIsExistState(string name,int id)
        {
            var flag= locationService.GetStateName(name,id);
            if (flag == null) { return false; }
            else return true;
        }
        // POST api/<StateController>
        [HttpPost]
        public void Post([FromBody]State state)
        {
            locationService.AddState(state);
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] State state)
        {
            locationService.UpdateState(id,state);
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            locationService.RemoveState(id);
        }
    }
}
