using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossOverAssignment.Business.Implementations;
using CrossOverAssignment.Business.Interfaces;
using CrossOverAssignment.Dtos.Models;
using Microsoft.AspNet.Identity;

namespace CrossOverAssignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStockBusinessService stockBusinessService;
        private readonly int ItemPerPage = int.Parse(ConfigurationManager.AppSettings["ItemPerPage"]);

        public HomeController()
        {
            stockBusinessService = new StockBusinessService();
        } 

        public ActionResult Index(int currentIndex = 1)
        {
            int totalItem = 0;
            var result = new PagingDto<StockDto>()
            {
                Items = stockBusinessService.ReadStocksByUser(User.Identity.GetUserId(), out totalItem, currentIndex, ItemPerPage),
                //Pager = 
            };
            return View(result);
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