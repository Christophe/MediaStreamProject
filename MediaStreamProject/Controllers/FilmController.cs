using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class FilmController : Controller
    {
        // Appel du model en static
        static Model1 model = new Model1();

        // GET: Film
        public ActionResult Films()
        {
            var films = model.Films;
            // On stock tous les films dans ViewBag.Film
            var Query = from film in films
                        select film;
            ViewBag.Film = Query.ToList<Film>();
            return View();
        }
        // Methode pour afficher les films en player video
        public ActionResult VideoFilms(int id)
        {
            var f = model.Films;
            Film film = f.Find(id);
            ViewBag.Film = film;
            return View("VideoFilms");
        }
    }
}