using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{
    public class FilmHistorique
    {
        public FilmHistorique() { }

        public FilmHistorique(int userId, int filmId)
        {
            UserId = userId;
            this.filmId = filmId;
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int filmId { get; set; }

        

    }
}