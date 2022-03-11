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
        // GET: Home
        /*public ActionResult Index()
        {
            return View();
        }*/

        public string Index(string str)
        {
            string Greeting = ModelClass.ModelHello() + ", " + str; 
            return Greeting;
        }
    }
}