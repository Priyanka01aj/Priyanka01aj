using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDemo.Services;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class CityController : Controller
    {
        private readonly LocationService locationService;
        
        public CityController(LocationService locationService)
        {
            
            this.locationService = locationService;
        }
        // GET: CityController
        public ActionResult Index()
        {
            var city = locationService.GetAllCities();
            return View(city);
        }
        [HttpGet]
        public ViewResult GetCity() => View();
        [HttpPost]
        public IActionResult GetCity(int id)
        {
            var city = locationService.GetCityById(id);
            return View(city);
        }
        public IActionResult Details(int id)
        {
            var city = locationService.GetCityById(id);
            return View(city);
        }

        public ActionResult AddNew()
        {
            //var statelist = locationService.GetAllState();
            //statelist.Insert(0, new State { State_Id = 0, State_Name = "Select" });
            //ViewBag.state = statelist;
            var countrylist = locationService.GetCountries();
            countrylist.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = countrylist;
            return View();

        }
        public JsonResult GetCityIsExist(string city_name,int City_Id)
        {
            var flag = locationService.GetCityName(city_name,City_Id);
            return Json(!flag);
        }
        [HttpPost]
        public IActionResult AddNew([Bind(include: "City_Id,City_Name,State_Id")] City city)
        {
            
            if (ModelState.IsValid)
            {
                var flag = locationService.AddCity(city);
                if (flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("AddNew");
                }
            }
            else return RedirectToAction("Index");

        }
       
        public JsonResult GetState(int countryId)
        {
            List<State> statesList = new List<State>();

            statesList = locationService.GetStateByCountryId(countryId);
            statesList.Insert(0, new State { State_Id = 0, State_Name = "Select" });
            return Json(new SelectList(statesList, "State_Id", "State_Name"));

        }
        public IActionResult Edit(int Id)
        {
            var cityreturn = locationService.GetCityById(Id);

            var countrylist = locationService.GetCountries();
            countrylist.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = countrylist;
            var stateslist = locationService.GetStateByCountryId(cityreturn.State.Country_Id);
            //stateslist.Insert(0, new State { State_Id = 0, State_Name = "Select" });
            ViewBag.state = stateslist;
            if (Id == 0)
            {
                return RedirectToAction("Index");

            }
            
            return View(cityreturn);
        }
        [HttpPost]
        public IActionResult Edit([Bind(include: "City_Id,City_Name,State_Id")] City city)
        {
            var flag = locationService.UpdateCity(city);
            if (flag)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }

        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult DeleteD(int id) { return View(locationService.GetCityById(id)); }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var flag = locationService.DeleteCity(Id);
            if (flag) return RedirectToAction("Index");
            else return RedirectToAction("Delete");
        }
        
    }
}
