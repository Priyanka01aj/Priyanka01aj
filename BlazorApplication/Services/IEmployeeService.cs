using EmployeeLib.Models;

namespace BlazorApplication.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Boolean AddEmployee(Employee employee);
    }
}
