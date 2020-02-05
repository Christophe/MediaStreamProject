using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{


    public class SerieHistorique
    {
        public SerieHistorique() { }
        public SerieHistorique(int userId, int filmId)
        {
            UserId = userId;
            FilmId = filmId;
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }


        public virtual int FilmId { get; set; }

    }
}