using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Notify.Models;

namespace Notify.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var current_user_id = User.Identity.GetUserId();
                ViewBag.Usuario = db.Users.Find(current_user_id);
            }

            ViewBag.es_user_admin = Request.IsAuthenticated && db.Users.Find(User.Identity.GetUserId()).PhoneNumber != null;

            return View();
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