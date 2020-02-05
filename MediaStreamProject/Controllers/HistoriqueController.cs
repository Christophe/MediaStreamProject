using System;
using MediaStreamProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class HistoriqueController : Controller
    {
        static Model1 model = new Model1();
        
        public ActionResult AddFilmHistorique(int id)
        {

            var user = (int)Session["userId"];

            var FilmHistorique = model.FilmHistoriques;
            FilmHistorique filmvu = null;
            var query = from FilmList in FilmHistorique
                        where (FilmList.UserId == user) && (FilmList.filmId == id)
                        select FilmList;

            foreach (var item in query)
            {
                filmvu = item;
            }
            if (filmvu == null)
            {
                FilmHistorique filmHistorique = new FilmHistorique(user, id);
                model.FilmHistoriques.Add(filmHistorique);
            }

            else
            {
                ViewBag.message = "ce film fait déja partie de votre historique";
            }

            model.SaveChanges();


            return RedirectToAction("AfficherHistorique");

        }

        public ActionResult AfficherHistorique()
        {
            var Film = model.Films;
            var FilmHistorique = model.FilmHistoriques;
            var user = (int)Session["userId"];

            var joinQuery =
                from film in Film
                from filmList in FilmHistorique
                where (filmList.filmId == film.Id) && (filmList.UserId == user)
                select new NewClassWishList() { id = film.Id, titre = film.Title, genre= film.Genre , image = film.Image, video = film.Video };

            ViewBag.List_Historique = joinQuery.ToList();
            return View("Historique");

        }


    }
}