using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemManager.Areas.SystemManager.Controllers
{
    public class CustomController : Controller
    {
        // GET: SystemManager/Custom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Getstr()
        {
            return Content("sdfsdf");
        }
    }
}