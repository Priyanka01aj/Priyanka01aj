using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    public class CountryController : Controller
    {
        private readonly LocationService locationservice;
        public CountryController(LocationService locationservice)
        {
            this.locationservice=locationservice;
        }
        public IActionResult Index()
        {
            
          var countries =locationservice.GetCountries();
            return View(countries);
            
        }
        [HttpGet]
        public ViewResult GetCountry() => View();
        [HttpPost]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await locationservice.GetCountry(id);
            return View(country);
        }
        public async Task<IActionResult> Details(int id)
        {
            var country = await locationservice.GetCountry(id);
            return View(country);
        }
        public IActionResult AddNew()
        {
            return View();
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public JsonResult GetCountryIsExist(string country_name,int Country_Id)
        {
            var flag = locationservice.GetCountryName(country_name,Country_Id);
            return Json(!flag);
        }
        [HttpPost]
        public IActionResult AddNew(Country country)
        {
           
            if (ModelState.IsValid)
            {
                locationservice.AddCountry(country);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0)
            {
                return RedirectToAction("Index");
            }
          var countryreturn=await locationservice.GetCountry(Id);
            return View(countryreturn);
        }
        [HttpPost]
        public  IActionResult Edit(Country country)
        {
              locationservice.UpdateCountry(country);
            
            return RedirectToAction("Index");

        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteD(int id) { return View(await locationservice.GetCountry(id)); }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            locationservice.DeleteCountry(Id);
            return RedirectToAction("Index");
        }
    }
}
