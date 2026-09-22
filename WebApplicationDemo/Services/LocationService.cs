using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using System.Net.Http.Formatting;

namespace WebApplicationDemo.Services
{
    public class LocationService
    {
        private readonly DemoDbContext _Db;
        public LocationService(DemoDbContext db)
        {
            _Db = db;
        }
        string URL = "https://localhost:44326/api/";
        
        public Boolean GetCountryName(string name,int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(URL+"Country/GetName/"+name+"/"+id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsStringAsync();
                        apiResponse.Wait();
                        string conreturn = apiResponse.Result;
                        if (conreturn == "true") return true;
                        else return false;
                    }
                }
            }
            return false;

        }
        public Boolean GetEmployeeEmailId(string email,int id)
        {
            
            string jsonString = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(URL + "Employee/GetEmployeeEmail/" + email+"/" + id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        jsonString = result.Content.ReadAsStringAsync().Result;
                        if (jsonString == "true") return true;
                        else return false;
                    }
                    
                }
            }
            return false;

        }

        public Boolean GetCityName(string name,int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(URL + "City/GetIsExistCity/" + name+"/"+id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsStringAsync();
                        string cityreturn = apiResponse.Result;
                        if (cityreturn == "true") return true;
                        else return false;
                    }
                    
                }
            }return false;
        }
        public Boolean GetStateName(string name,int id)
        {
            using (var httpClient = new HttpClient())
            {
                
                using (var response = httpClient.GetAsync(URL + "State/GetIsExistState/" + name+"/"+id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsStringAsync();
                        apiResponse.Wait();
                        string statereturn = apiResponse.Result;
                        if (statereturn == "true") return true;
                        else return false;
                    }
                    
                }
            }return false;
        }
        public List<State> GetStateByCountryId(int countryid)
        {
            List<State> states = new List<State>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL + "State/GetStates/"+countryid);

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsAsync<List<State>>();
                    apiResponse.Wait();
                    states = apiResponse.Result;
                }

            }
            return states;
        }
        public List<City> GetCityByStateId(int stateId)
        {
            List<City> cities = new List<City>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL + "City/GetCities/" + stateId);

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsAsync<List<City>>();
                    apiResponse.Wait();
                    cities = apiResponse.Result;
                }

            }
            return cities;
        }


       
       
        public State GetState(int id)
        {
            State state = new State();
            using (var httpClient = new HttpClient())
            {
                using (var response =  httpClient.GetAsync(URL +"State/"+ id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsAsync<State>();
                        apiResponse.Wait();
                        state = apiResponse.Result;
                    }
                }
            }
            return state;
        }

       

        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL + "City");
                
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsAsync<List<City>>();
                        apiResponse.Wait();
                        cities = apiResponse.Result;
                    }
               
            }
            return cities;
        }
        public  List<State> GetAllState()
        {
            List<State> states = new List<State>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL + "State");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsAsync<List<State>>();
                    apiResponse.Wait();
                    states = apiResponse.Result;
                }
            }
            return states;
        }

        public Boolean UpdateCity(City city)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json");
                var response = httpClient.PutAsync(URL + "City/" + city.City_Id, content);

                response.Wait();

                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
                
            }
        }

        public Boolean UpdateState(State state)
        {
            //State newstate = new State();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(state), Encoding.UTF8, "application/json");
                var response = httpClient.PutAsync(URL + "State/" + state.State_Id, content);
                
                    response.Wait();
                   
                    var result = response.Result;
                    var flag = false;
                    if (result.IsSuccessStatusCode) { return !flag; }
                    else return flag;
                    
                }
        }

        public Boolean DeleteCity(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync(URL + "City/" + id);
            var result = response.Result;
            return result.IsSuccessStatusCode;
        }

        public Boolean DeleteState(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync(URL + "State/" + id);
            var result = response.Result;
            return result.IsSuccessStatusCode;
        }

       
        public  List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL+"Country");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsAsync<List<Country>>();
                    apiResponse.Wait();
                    countries = apiResponse.Result;
                }


            }
            return countries;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL + "Employee");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsAsync<List<Employee>>();
                    apiResponse.Wait();
                    employees = apiResponse.Result;
                }
            }
            return employees;

        }
        public Employee GetEmployees(int id)
        {
            Employee employee = new Employee();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(URL + "Employee/" + id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsAsync<Employee>();
                        apiResponse.Wait();
                        employee = apiResponse.Result;
                    }
                }
            }
            return employee;
        }

        public Boolean AddEmployee(Employee employee)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(URL + "Employee", content);
                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }
        }
       
       
       
        public City GetCityById(int id)
        {
            City city = new City();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(URL + "City/" + id))
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var apiResponse = result.Content.ReadAsAsync<City>();
                        apiResponse.Wait();
                        city = apiResponse.Result;
                    }
                }
            }
            return city;
        }
       

        public async Task<Country> GetCountry(int id)
        {
            Country country = new Country();
            using (var httpClient = new HttpClient())
            {
                
                    using (var response = await httpClient.GetAsync("https://localhost:44326/api/Country/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        country = JsonConvert.DeserializeObject<Country>(apiResponse);
                    }
                    }
            }
            return country;

        }

        public Boolean UpdateEmployee(int id,Employee employee)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                var response = httpClient.PutAsync(URL + "Employee/" + id, content);

                response.Wait();

                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;

            }
        }

        public Boolean UpdateCountry(Country country)
        {
           
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
                var response = httpClient.PutAsync(URL + "Country/" + country.Country_Id, content);
                    response.Wait();
                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }
            
        }
        public Boolean AddCountry(Country country)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(URL+"Country", content);
                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }
        }
        public Boolean AddState(State state)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(state), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(URL + "State", content);
                var result= response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }

        }
        public Boolean AddCity(City city)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(URL + "City", content);
                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }
        }
        public Boolean RemoveEmployee(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync(URL + "Employee/" + id);
            var result = response.Result;
            return result.IsSuccessStatusCode;
        }
        public Boolean DeleteCountry(int Id)
        {
            var httpClient = new HttpClient();
            var response= httpClient.DeleteAsync(URL + "Country/" + Id);
            var result = response.Result;
            return result.IsSuccessStatusCode;
        }
      
    }
}

