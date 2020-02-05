using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{
    public class FilmHistorique
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int filmId { get; set; }

        

    }
}