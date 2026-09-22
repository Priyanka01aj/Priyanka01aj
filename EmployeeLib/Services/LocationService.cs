using EmployeeLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.Services
{
   public class LocationService
    {
        private readonly DemoDbContext demoDb;
        public LocationService(DemoDbContext demoDb)
        {
            this.demoDb = demoDb;
        }
        public List<Country> GetAllCountries()
        {
            return demoDb.Country.ToList();
        }
        //public City GetStateByCityId(int cityid)
        //{
        //    return demoDb.City.Where(a => a.City_Id == cityid).FirstOrDefault();
        //}
        public Country GetCountry(int id)
        {
            return demoDb.Country.Where(t => t.Country_Id == id).FirstOrDefault();
        }
        public int AddCountry(Country country)
        {
            demoDb.Add(country);
            demoDb.SaveChanges();
            return country.Country_Id;
        }
        public string GetCountryName(string name,int id)
        {
            var countryname=demoDb.Country.Where(a => a.Country_Name == name).Where(a=>a.Country_Id!=id).Select(a => a.Country_Name).FirstOrDefault();
            return countryname;
        }

        public string GetCityName(string name,int id)
        {
            var city= demoDb.City.Where(a => a.City_Name == name).Where(a => a.City_Id != id).Select(a => a.City_Name).FirstOrDefault();
            return city;
        }
        public List<City> GetAllCities()
        {
            return demoDb.City.Include(t=>t.State).Include(t=>t.State.Country).ToList();
        }

        public City GetCity(int id)
        {
            return demoDb.City.Include(t=>t.State).Include(t=>t.State.Country).Where(t=>t.City_Id==id).FirstOrDefault();
        }

        public void AddCity(City city)
        {
            demoDb.City.Add(city);
            //demoDb.Add(city);
            demoDb.SaveChanges();
        }

        public void UpdateCity(int id, City city)
        {
            var newcity = demoDb.City.Where(a => a.City_Id == id).FirstOrDefault();
            newcity.City_Id = city.City_Id;
            newcity.City_Name = city.City_Name;
            newcity.State_Id = city.State_Id;
            newcity.State = city.State;
            demoDb.Update(newcity);
            demoDb.SaveChanges();
        }

        public void RemoveCity(int id)
        {
            var city= demoDb.City.Where(a => a.City_Id == id).FirstOrDefault();
            demoDb.Remove(city);
            demoDb.SaveChanges();
        }

        public void AddState(State state)
        {
            demoDb.Add(state);
            demoDb.SaveChanges();

        }
        public void UpdateState(int id,State state)
        {
           
           var states=demoDb.State.Where(a=>a.State_Id==id).FirstOrDefault();
            states.State_Id = state.State_Id;
            states.State_Name = state.State_Name;
            states.Country_Id = state.Country_Id;
            demoDb.Update(states);

            demoDb.SaveChanges();
        }

        public List<State> GetAllStates()
        {
            return demoDb.State.Include(t => t.Country).ToList();
        }
        public State GetState(int stateid)
        {
            return demoDb.State.Include(t => t.Country).Where(a => a.State_Id == stateid).FirstOrDefault();
        }
        public List<State> GetStateByCountryId(int countryid)
        {
            return demoDb.State.Where(a => a.Country_Id == countryid).ToList();
        }
        public List<City> GetCityByStateId(int stateId)
        {
            return demoDb.City.Where(a => a.State_Id == stateId).ToList();
        }
        public string GetStateName(string name,int id)
        {
            var state= demoDb.State.Where(a => a.State_Name == name).Where(a => a.State_Id != id).Select(a => a.State_Name).FirstOrDefault();
            return state;
        }
        public void RemoveState(int id)
        {
            var state = demoDb.State.Where(t => t.State_Id == id).FirstOrDefault();
            demoDb.Remove(state);
            demoDb.SaveChanges();
        }

        public void UpdateCountry(int id,Country country)
        {
            var countrys = demoDb.Country.Where(t => t.Country_Id == id).FirstOrDefault();
            countrys.Country_Id = country.Country_Id;
            countrys.Country_Name = country.Country_Name;
            demoDb.SaveChanges();
            
        }
        public void RemoveCountry(int id)
        {
            var country = demoDb.Country.Where(t => t.Country_Id == id).FirstOrDefault();
            demoDb.Remove(country);
            demoDb.SaveChanges();
           
        }

    }
}
