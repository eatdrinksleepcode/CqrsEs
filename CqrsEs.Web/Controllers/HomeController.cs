using System;
using System.Net;
using System.Web.Mvc;
using CqrsEs.Web.Models;

namespace CqrsEs.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Data
            {
                SuccessUrl = Url.RouteUrl(new { Controller = "Home", Action = "Success" }),
                FailureUrl = Url.RouteUrl(new { Controller = "Home", Action = "Failure" }),
            });
        }

        public ActionResult Success()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Success!");
        }

        public ActionResult Failure()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Failure!");
        }
    }
}