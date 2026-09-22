using EmployeeLib.Models;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace BlazorApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public EmployeeService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        } 
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await _httpClient.GetAsync($"Employee");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var employee = JsonSerializer.Deserialize<List<Employee>>(content, _options);
            return employee;
        }

        public Boolean AddEmployee(Employee employee)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync($"Employee", content);
                var result = response.Result;
                var flag = false;
                if (result.IsSuccessStatusCode) { return !flag; }
                else return flag;
            }
        }
    }
}
