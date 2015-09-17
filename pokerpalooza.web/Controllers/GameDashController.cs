using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pokerpalooza.Controllers
{
    public class GameDashController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}