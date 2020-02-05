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
<<<<<<< HEAD
            // Recuperation du User courant via la Session["userId"]
            // Recuperation des Notes de ce Film et comparaison de UserId et Session["userId"]
            using (var model = new Model1())
            {
                note = (from nt in model.Notes
                        where nt.MediaId.Equals(film.Id) && nt.UserId.Equals(Session["userId"])
                        select nt).FirstOrDefault();
            }
=======
            Film film = null;
            var userId = (int)Session["userId"];
>>>>>>> e479a2fefb872b9a7fc9ba6b7c4159ca224e525b

            using (var model = new Model1())
            {
                // Recuperation des Notes de ce Film et comparaison de UserId et Session["userId"]
                var note = (from nts in model.Notes
                            where nts.MediaId.Equals(filmId) && nts.UserId.Equals(userId)
                            select nts).FirstOrDefault();
                if (note == null)
                {
<<<<<<< HEAD
                // On incrémente le compteur NoteCompteur de 1
                film.NoteCompteur = film.NoteCompteur + 1;
                // On additionne la nouvelle note avec la NoteTotal
                film.NoteTotal = film.NoteTotal + note.ValeurNote;
                // La note du film est NoteTotal/NoteCompteur
                film.Note = (film.NoteTotal % film.NoteCompteur);
=======
                    // Modification de la BDD Note
                    Note newNote = new Note(noteValeur, (int)Session["userId"], filmId);
                    model.Notes.Add(newNote);
                    model.SaveChanges();
>>>>>>> e479a2fefb872b9a7fc9ba6b7c4159ca224e525b

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
                // Recuperation des Notes de cette Serie et comparaison de UserId
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