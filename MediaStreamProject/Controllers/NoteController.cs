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
        public ActionResult Noter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NoterFilm(Note note, Film film)
        {
            // Recuperation de la note du film a noter et de l'id du film
            using (var model = new Model1())
            {
               Note notes = (from nt in model.Notes
                             where nt.FilmId.Equals(film.Id) && nt.UserId.Equals(Session["userId"])
                            // User courant est recupere via la Session["userId"]
                             select nt).FirstOrDefault();
            }
            // Si la note est vide alors il peut noter
            if (note == null)
            {
                // On incrémente le compteur NoteCompteur de 1
                film.NoteCompteur = film.NoteCompteur + 1;
                // On additionne la nouvelle note avec la NoteTotal
                film.NoteTotal = film.NoteTotal + note.Notes;
                // La note du film est NoteTotal/NoteCompteur
                film.Note = (film.NoteTotal % film.NoteCompteur);
            }
            // Sinon on renvoie un message disant qu'il a déjà vote
            else
            {
                // Vous avez deja note ce film
                string alert = "ake";
            }

            return View("/Home/Index");
        }
    }
}