﻿using MediaStreamProject.Models;
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
        public ActionResult NoterFilm(Note note, Film film)
        {
            // Recuperation du User courant via la Session["userId"]
            // Recuperation des Notes de ce Film et comparaison de UserId et Session["userId"]
            using (var model = new Model1())
            {
                note = (from nt in model.Notes
                        where nt.FilmId.Equals(film.Id) && nt.UserId.Equals(Session["userId"])
                        select nt).FirstOrDefault();
            }

            // Si note est vide alors User peut noter
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
                string alert = "Vous avez déjà noté ce film!";
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
        public ActionResult NoterSerie(Note note, Serie serie)
        {

            return View();
        }
    }
}