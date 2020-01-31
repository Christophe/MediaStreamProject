using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class Film
    {
        public Film() { }
        public Film(string title, string realName, Genre genre, int duration)
        {
            Title = title;
            RealName = realName;
            Genre = genre;
            Duration = duration;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string RealName { get; set; }
        public Genre Genre { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        public int Note { get; set; }
        public int NoteCompteur { get; set; }
        public int NoteTotal { get; set; }
    }
}