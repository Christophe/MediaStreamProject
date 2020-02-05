using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStreamProject.Models
{
    public class FilmWishList

    {

        public FilmWishList() { }

        public FilmWishList(int userId, int filmId)
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