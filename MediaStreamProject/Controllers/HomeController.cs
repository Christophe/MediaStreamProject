using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class HomeController : Controller
    {
        static Model1 model = new Model1();
        // Vue Index du HomeController : propose de s'inscrire ou de se connecter
        public ActionResult Index()
        {
            return View();
        }
        // Vue avec les contenus : liste des films et series protege par Authorize
        [Authorize]
        public ActionResult Contenu()
        {
            ViewBag.list_series = model.Series.ToList();
            ViewBag.list_films = model.Films.ToList();
            return View();
        }
    }
}