using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCR1.Models;

namespace WebMVCR1.Controllers
{
    public class DefaultController : Controller
    {
        private static PersonRepository db = new PersonRepository();

        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро!" : "Добрый день!";
            ViewData["Message"] = "Хорошего дня";
            return View();
        }

        [HttpGet]
        public ViewResult InputData()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InputData(Person p)
        {
            db.AddResponse(p);
            return View("Hello", p);
        }

        public ViewResult ShowPersonList()
        {
            ViewBag.PersonList = db.GetAllResponses;
            ViewBag.PersonCount = db.NumberOfPeople;
            return View("ListPerson");
        }

        /*public string Index(string str)
        {
            string Greeting = ModelClass.ModelHello() + ", " + str; 
            return Greeting;
        }*/
    }
}