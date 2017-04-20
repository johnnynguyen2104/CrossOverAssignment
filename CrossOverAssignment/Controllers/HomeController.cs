using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossOverAssignment.Business.Dtos;
using CrossOverAssignment.Business.Helpers;
using CrossOverAssignment.Business.Implementations;
using CrossOverAssignment.Business.Interfaces;
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

        public ActionResult Index(int page = 1)
        {
            int totalItem = 0;
            var result = new PagingDto<StockDto>()
            {
                Items = stockBusinessService.ReadStocksByUser(User.Identity.GetUserId(), out totalItem, page, ItemPerPage),
                Pager = new Pager(totalItem, page, ItemPerPage)
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