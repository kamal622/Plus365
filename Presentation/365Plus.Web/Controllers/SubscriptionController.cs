using _365Plus.Service.Ebooks;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _365Plus.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using _365Plus.Service.Clients;
using _365Plus.Service.User;

namespace _365Plus.Web.Controllers
{
    public class SubscriptionController : Controller
    {

        private readonly EbookService _ebookService;
        private readonly ClientService _clientService;
        public SubscriptionController(EbookService ebookService,ClientService clientService)
        {
            this._ebookService = ebookService;
            this._clientService = clientService;

        }

        // GET: Subscription
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getClientsPoints()
        {
            var data = _clientService.getClientsPoints(Convert.ToInt32(User.Identity.GetUserId()));
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getClientsName()
        {
            var data = _clientService.getClientsName(Convert.ToInt32(User.Identity.GetUserId()));
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllEbooks()
        {
            var data = _ebookService.GetAllEbooks();
            return Json(data, JsonRequestBehavior.AllowGet);

            
        }

        public JsonResult GetSubscribedEbooks()
        {
            var data = _ebookService.GetAllEbooksForClient(Convert.ToInt32(User.Identity.GetUserId()));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult GetEbooksByID(double id)
        {
            var data = _ebookService.GetEbooksByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Lessons
        [Authorize]
        public ActionResult Lessons()
        {
            return View();
        }
    }
}