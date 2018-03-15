using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Notify.Models;
using System.Globalization;


namespace Notify.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            
            if (Request.IsAuthenticated)
            {
                var current_user_id = User.Identity.GetUserId();

                var pedido_de_hoy = db.Pedido.Where(d => d.fecha.Day == DateTime.Today.Day && d.usuario.Id == current_user_id);

                ViewBag.pedidoDeHoy = pedido_de_hoy.Any();
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
        public ActionResult Tempdata()
        {
            TempData["Mensaje"] = "Comanda creada correctament";
            return View();
        }
    }
}