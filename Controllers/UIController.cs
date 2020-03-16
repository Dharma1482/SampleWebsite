using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWebsite.Controllers
{
    public class UIController : Controller
    {
        // GET: UI
        public ActionResult Index()
        {
            return View();
        }
    }
}