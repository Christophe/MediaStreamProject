using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class NoteController : Controller
    {
        // GET : Methode pour noter un film
        public ActionResult NoterFilm()
        {
            return View();
        }
        // POST : Methode pour noter un film
        [HttpPost]
        public ActionResult NoterFilm(int noteValeur, int filmId)
        {
            Film film = null;
            var userId = (int)Session["userId"];

            using (var model = new Model1())
            {
                // Recuperation des Notes de ce Film et comparaison de UserId avec Session["userId"]
                var note = (from nts in model.Notes
                            where nts.MediaId.Equals(filmId) && nts.UserId.Equals(userId)
                            select nts).FirstOrDefault();
                if (note == null)
                {
                    // Modification de la BDD Note
                    Note newNote = new Note(noteValeur, (int)Session["userId"], filmId);
                    model.Notes.Add(newNote);
                    model.SaveChanges();

                    // Modification de la BDD film
                    film = model.Films.Find(filmId);
                    film.NoteCompteur = film.NoteCompteur + 1;
                    film.NoteTotal = film.NoteTotal + newNote.ValeurNote;
                    film.Note = (film.NoteTotal / film.NoteCompteur);
                    model.SaveChanges();
                }
            }
            return View();
        }
        // GET : Methode pour noter une serie
        public ActionResult NoterSerie()
        {
            return View();
        }
        // POST : Methode pour noter une serie
        [HttpPost]
        public ActionResult NoterSerie(int noteValeur, int serieId)
        {
            Serie serie = null;
            var userId = (int)Session["userId"];

            using (var model = new Model1())
            {
                // Recuperation des Notes de cette Serie et comparaison avec UserId
                var note = (from nts in model.Notes
                            where nts.MediaId.Equals(serieId) && nts.UserId.Equals(userId)
                            select nts).FirstOrDefault();
                if (note == null)
                {
                    // Modification de la BDD Note
                    Note newNote = new Note(noteValeur, (int)Session["userId"], serieId);
                    model.Notes.Add(newNote);
                    model.SaveChanges();

                    // Modification de la BDD Serie
                    serie = model.Series.Find(serieId);
                    serie.NoteCompteur = serie.NoteCompteur + 1;
                    serie.NoteTotal = serie.NoteTotal + newNote.ValeurNote;
                    serie.Note = (serie.NoteTotal / serie.NoteCompteur);
                    model.SaveChanges();
                }
                return View();
            }
        }
    }
}