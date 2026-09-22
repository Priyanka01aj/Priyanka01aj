using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    public class StateController : Controller
    {
        private readonly LocationService locationservice;
        public StateController(LocationService locationservice)
        {
            this.locationservice = locationservice;
        }

       
        // GET: StateController
        public ActionResult Index()
        {
            var states = locationservice.GetAllState();
            return View(states);
        }
        [HttpGet]
        public ViewResult GetState() => View();
        [HttpPost]
        public IActionResult GetState(int id)
        {
            var state = locationservice.GetState(id);
            return View(state);
        }
        public IActionResult Details(int id)
        {
            var state = locationservice.GetState(id);
            return View(state);
        }
        public IActionResult AddNew()
        {
            var countrylist = locationservice.GetCountries();
            countrylist.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = countrylist;
            return View();
        }
        public JsonResult GetStateIsExist(string state_name,int State_Id)
        {
            var flag = locationservice.GetStateName(state_name,State_Id);
            return Json(!flag);
        }
        [HttpPost]
        public IActionResult AddNew(State state)
        {
           
            if (ModelState.IsValid)
            {
                var flag = locationservice.AddState(state);
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
        public IActionResult Edit(int Id)
        {
            var countrylist = locationservice.GetCountries();
            countrylist.Insert(0, new Country { Country_Id = 0, Country_Name = "Select" });
            ViewBag.country = countrylist;

            if (Id == 0)
            {
                return RedirectToAction("Index");

            }
            var statereturn = locationservice.GetState(Id);
            return View(statereturn);
        }
        [HttpPost]
        public IActionResult Edit([Bind(include: "State_Id,State_Name,Country_Id")] State state)
        {
           var flag= locationservice.UpdateState(state);
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
        public IActionResult DeleteD(int id) { return View(locationservice.GetState(id)); }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var flag=locationservice.DeleteState(Id);
            if (flag) return RedirectToAction("Index");
            else return RedirectToAction("Delete");
        }
       
    }
}
