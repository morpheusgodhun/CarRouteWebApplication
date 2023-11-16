using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRouteWebApplication.Models;

namespace CarRouteWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (RouteEntities db = new RouteEntities())
            {
                var model = db.Routes.ToList();

                return View(model);
            }
        }
    }
}