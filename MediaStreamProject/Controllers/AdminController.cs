using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using MediaStreamProject.Models;

namespace MediaStreamProject.Controllers
{
    public class AdminController : Controller
    {
        static Model1 model = new Model1();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.list_series = model.Series.ToList(); //hollaaaa
            ViewBag.list_films = model.Films.ToList();
            return View();
        }
        // *********************** //
        // METHODE POUR LES FILMS //
        // *********************** //
        // Methode GET pour ajouter un film
        [Authorize]
        public ActionResult AddMovie()
        {
            return View();
        }
        // Methode POST pour ajouter un film qui prend en argument un film et deux File : Image et Video
        [HttpPost]
        public ActionResult AddMovie(Film film, HttpPostedFileBase fileImage, HttpPostedFileBase fileVideo)
        {
            if (fileImage != null && fileVideo != null && ModelState.IsValid)
            {
                try
                {
                    // File Image
                    string pathImage = Path.Combine(Server.MapPath("/Images/"),
                                                    Path.GetFileName(fileImage.FileName));
                    fileImage.SaveAs(pathImage);
                    film.Image = "/Images/" + fileImage.FileName;

                    // File Video
                    string pathVideo = Path.Combine(Server.MapPath("/Videos/"),
                                                    Path.GetFileName(fileVideo.FileName));
                    fileVideo.SaveAs(pathVideo);
                    film.Video = "/Videos/" + fileVideo.FileName;

                    ViewBag.Message = "File uploaded successfully";

                    // Sauvegarde les changement dans le model
                    model.Films.Add(film);
                    model.SaveChanges();
                    return Redirect("Admin/Index");
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Erreur" + e.Message.ToString();
                }
            }
            return View(film);
        }
        // *********************** //
        // METHODE POUR LES SERIES //
        // *********************** //
        // Methode GET pour ajouter une serie
        [Authorize]
        public ActionResult AddSerie()
        {
            return View("AddSerie");
        }
        // Methode POST pour ajouter une serie qui prend en argumant une serie et le file d'Image
        [HttpPost]
        public ActionResult AddSerie(Serie serie, HttpPostedFileBase fileImage)
        {
            if (fileImage != null && ModelState.IsValid)
            {
                try
                {
                    // File Image
                    string pathImage = Path.Combine(Server.MapPath("/Images/"),
                                                    Path.GetFileName(fileImage.FileName));
                    fileImage.SaveAs(pathImage);
                    serie.Image = "/Images/" + fileImage.FileName;

                    ViewBag.Message = "File uploaded successfully";

                    // Sauvegarde les changement dans le model
                    model.Series.Add(serie);
                    model.SaveChanges();
                    return View(serie);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Erreur" + e.Message.ToString();
                }

            }
            return View(serie);
        }
        // Methode GET pour ajouter une saison
        [Authorize]
        public ActionResult AddSeason()
        {
            ViewBag.list_series = model.Series.ToList();
            ViewBag.list_seasons = model.Seasons.ToList();
            return View("AddSeason");
        }
        // Methode POST pour ajouter une saison
        [HttpPost]
        public ActionResult AddSeason(Season season)
        {
            if (ModelState.IsValid)
            {
                model.Seasons.Add(season);
                model.SaveChanges();
            }
            ViewBag.list_series = model.Series.ToList();
            ViewBag.list_seasons = model.Seasons.ToList();
            return View();
        }
        // Methode GET pour ajouter un episode
        [Authorize]
        public ActionResult AddEpisode()
        {
            ViewBag.list_series = model.Series.ToList();
            ViewBag.list_seasons = model.Seasons.ToList();
            ViewBag.list_episodes = model.Episodes.ToList();
            return View("AddEpisode");
        }
        // Methode POST pour ajouter un episode qui prend en argumant un episode et un file Video
        [HttpPost]
        public ActionResult AddEpisode(Episode episode, HttpPostedFileBase fileVideo)
        {
            if (fileVideo != null && ModelState.IsValid)
            {
                try
                {
                    // File Video
                    string pathVideo = Path.Combine(Server.MapPath("/Videos/"),
                                                    Path.GetFileName(fileVideo.FileName));
                    fileVideo.SaveAs(pathVideo);
                    episode.Video = "/Videos/" + fileVideo.FileName;

                    ViewBag.Message = "File uploaded successfully";

                    // Sauvegarde les changement dans le model
                    model.Episodes.Add(episode);
                    model.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Erreur" + e.Message.ToString();
                }
            }
            ViewBag.list_series = model.Series.ToList();
            ViewBag.list_seasons = model.Seasons.ToList();
            ViewBag.list_episodes = model.Episodes.ToList();

            return View();
        }
    }
}