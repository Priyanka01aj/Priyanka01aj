using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly LocationService locationService;
        public EmployeeController(LocationService locationService)
        {
            this.locationService = locationService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employee = locationService.GetEmployees();
            return View(employee);
        }
        [HttpGet]
        public ViewResult GetEmployee() => View();
        [HttpPost]
        public IActionResult GetEmployee(int id)
        {
            var employee = locationService.GetEmployees(id);
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee = locationService.GetEmployees(id);
            return View(employee);
        }
        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            var country = locationService.GetCountries();
            country.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = country;
            return View();
        }
        public JsonResult GetState(int countryId)
        {
            List<State> statesList = new List<State>();
            statesList = locationService.GetStateByCountryId(countryId);
            statesList.Insert(0, new State { State_Id = 0, State_Name = "Select" });
            return Json(new SelectList(statesList, "State_Id", "State_Name"));
            }
        public JsonResult GetCity(int stateId)
        {
            List<City> cities = new List<City>();
            cities = locationService.GetCityByStateId(stateId);
            cities.Insert(0, new City { City_Id = 0, City_Name = "Select" });
            return Json(new SelectList(cities, "City_Id", "City_Name"));
        }
        
        public JsonResult GetEmailIsExist(string email,int Id)
        {
            var flag = locationService.GetEmployeeEmailId(email,Id);
            return Json(!flag);
        }
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include:"Id,FirstName,LastName,Phone,Email,CityId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                    locationService.AddEmployee(employee);
                    return RedirectToAction(nameof(Index));
    
            }
            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
           //var cityid=locationService.GetCityByEmployeeId(id);
           // var stateid = locationService.GetStateByCityId(cityid);
            var countrylist = locationService.GetCountries();
            countrylist.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = countrylist;
            var employee = locationService.GetEmployees(id);
            // var cityid = employee.CityId;
            //var city= locationService.GetCityById(cityid);
            // var stateid = city.State_Id;
            // var state = locationService.GetState(stateid);

            ViewBag.st = locationService.GetStateByCountryId(employee.City.State.Country_Id);
            ViewBag.city = locationService.GetCityByStateId(employee.City.State_Id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "Id,FirstName,LastName,Phone,Email,CityId")] Employee employee)
        {
                if (ModelState.IsValid)
                {
                    locationService.UpdateEmployee(employee.Id,employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
        }
        [HttpGet]
        [ActionName("Delete")]
        // GET: EmployeeController/Delete/5
        public ActionResult DeleteD(int id)
        {
           var employee=locationService.GetEmployees(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var flag=locationService.RemoveEmployee(id);
            if (flag) return RedirectToAction("Index");
            else return RedirectToAction("Delete");
        }
    }
}
