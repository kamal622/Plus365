using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _365Plus.Web.Controllers
{
    public class PromoteController : Controller
    {
        // GET: Promote
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}