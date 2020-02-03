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

            // Recuperation des Notes de ce Film et comparaison de UserId et Session["userId"]
            using (var model = new Model1())
            {
                var note = (from nts in model.Notes
                            where nts.FilmId.Equals(filmId) && nts.UserId.Equals(userId)
                            select nts).FirstOrDefault();
                if (note == null)
                {
                    // Modification de la BDD Note
                    Note newNote = new Note(noteValeur, (int)Session["userId"], filmId);
                    model.Notes.Add(newNote);
                    model.SaveChanges();

                    // Modification de la BDD film
                    // Recuperation de l'ID du film envoye par la note
                    film = model.Films.Find(filmId);
                    // On incrémente le compteur NoteCompteur de 1
                    film.NoteCompteur = film.NoteCompteur + 1;
                    // On additionne la nouvelle note avec la NoteTotal
                    film.NoteTotal = film.NoteTotal + newNote.Notes;
                    // La note du film est NoteTotal/NoteCompteur
                    film.Note = (film.NoteTotal / film.NoteCompteur);

                    // Sauvegarde les changements dans la BDD
                    model.SaveChanges();
                }
            }
            return View();
        }
    }
}