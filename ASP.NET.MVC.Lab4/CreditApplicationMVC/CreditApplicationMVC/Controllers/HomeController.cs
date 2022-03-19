using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditApplicationMVC.Models;

namespace CreditApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private CreditContext creditContext = new CreditContext();
        public ActionResult Index()
        {
            ShowCredits();
            return View();
        }

        private void ShowCredits()
        {
            var creditList = creditContext.Credits.ToList<Credit>();
            ViewBag.CreditList = creditList;
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            ShowCredits();
            var allBids = creditContext.Bids.ToList<Bid>(); 
            ViewBag.BidList = allBids; 
            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.bidDate = DateTime.Now;
            creditContext.Bids.Add(newBid);
            creditContext.SaveChanges();
            return "Спасибо, <b>" + newBid.PersonName + "</b>, за выбор нашего банка. Ваша заявка будет рассмотрена в течении 10 дней.";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}