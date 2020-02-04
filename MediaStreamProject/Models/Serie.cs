using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class Serie
    {
        public Serie(){}
        public Serie(string title, Genre genre, string synopsis)
        {
            Title = title;
            Genre = genre;
            Synopsis = synopsis;
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Synopsis { get; set; }
        public int Compteur { get; set; }
        public string Image { get; set; }

        public int Note { get; set; }
        public int NoteCompteur { get; set; }
        public int NoteTotal { get; set; }
    }
}