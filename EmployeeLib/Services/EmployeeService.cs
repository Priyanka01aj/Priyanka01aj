using EmployeeLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.Services
{
   public class EmployeeService
    {
        private readonly DemoDbContext _Db;
        public EmployeeService(DemoDbContext _Db)
        {
            this._Db = _Db;
        }
        
        public List<Employee> GetEmployees()
        {
            return _Db.Employee.Include(t => t.City).Include(t => t.City.State).Include(t => t.City.State.Country).ToList();

        }
        public Employee GetEmployees(int id)
        {
            return _Db.Employee.Include(t => t.City).Include(t => t.City.State).Include(t => t.City.State.Country).Where(t => t.Id == id).FirstOrDefault();
        }

        public void AddEmployee(Employee employee)
        {
            _Db.Employee.Add(employee);
            _Db.SaveChanges();
        }
        public void UpdateEmployee(int id,Employee employee)
        {
            var newEmployee = _Db.Employee.Include(a=>a.City).Include(t => t.City.State).Include(t => t.City.State.Country).Where(a => a.Id == id).FirstOrDefault();
            newEmployee.FirstName = employee.FirstName;
            newEmployee.LastName = employee.LastName;
            newEmployee.Id = employee.Id;
            newEmployee.Phone = employee.Phone;
            newEmployee.Email = employee.Email;
            newEmployee.CityId= employee.CityId;
            _Db.Update(newEmployee);
            _Db.SaveChanges();
        }

        public string GetEmployeeEmail(string email,int id)
        {
            return _Db.Employee.Where(a => a.Email == email).Where(a => a.Id != id).Select(a=>a.Email).FirstOrDefault();
        }

        public void RemoveEmployee(int id)
        {
            var employee = _Db.Employee.Where(a => a.Id == id).FirstOrDefault();

            _Db.Employee.Remove(employee);
            _Db.SaveChanges();
        }
    }
}
