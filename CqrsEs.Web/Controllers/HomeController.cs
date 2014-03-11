using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CqrsEs.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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