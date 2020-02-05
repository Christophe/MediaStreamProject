using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{
    public class SerieWishList
    {
        public SerieWishList() { }
        public SerieWishList(int userId, int filmId)
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