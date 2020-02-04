using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class SerieController : Controller
    {
        // Appel du model en static
        static Model1 model = new Model1();

        // Affichage des Series par genre
        public ActionResult Series()
        {
            var series = model.Series;
            // On stock toutes les series dans ViewBag.Serie
            var Query = from serie in series
                        select serie;
            ViewBag.Serie = Query.ToList<Serie>();
            return View();
        }
        // Saisons en fonction de l'Id de la Serie
        public ActionResult Seasons(int id)
        {
            var series = model.Series;
            var seasons = model.Seasons;
            Serie s = series.Find(id);
            var Query = from season in seasons
                        where season.SerieID == id
                        select season;
            ViewBag.Seasons = Query.ToList<Season>();
            return View("Seasons");
        }
        // Episodes en fonction de l'Id de l'Episode
        public ActionResult Episodes(int id)
        {
            var episodes = model.Episodes;
            var Query = from episode in episodes
                        where episode.SeasonID == id
                        select episode;
            ViewBag.Episodes = Query.ToList<Episode>();
            return View("Episodes");
        }
        // Methode pour afficher les Episodes en player video
        public ActionResult VideoEpisodes(int id)
        {
            var e = model.Episodes;
            Episode episode = e.Find(id);
            ViewBag.Episode = episode;
            return View("VideoEpisodes");
        }
        // Methode pour noter
        public ActionResult NoterSerie(int id)
        {
            var f = model.Series;
            Serie serie = f.Find(id);
            ViewBag.Serie = serie;
            return View();
        }
    }
}