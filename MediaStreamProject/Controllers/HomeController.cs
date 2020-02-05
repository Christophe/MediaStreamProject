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
        [Authorize]
        [HttpPost]
        public ActionResult Research(string research)
        {
            var series = model.Series;
            var films = model.Films;
            var Query_series = from serie in series
                        where serie.Title.Contains(research)
                        select serie;
            ViewBag.ResearchSeries = Query_series.ToList<Serie>();

            var Query_films = from film in films
                              where film.Title.Contains(research) || film.RealName.Contains(research)
                              select film;
            ViewBag.ResearchFilms = Query_films.ToList<Film>();
            return View();
        }

        [Authorize]
        public ActionResult Quizz()
        {
            return View();
        }
    }
}