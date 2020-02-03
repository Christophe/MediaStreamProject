using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStreamProject.Models
{
    public class FilmWishList

    {
        public FilmWishList(int userId, List<Film> films)
        {
            UserId = userId;
            Films = films;
        }

        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        
        public virtual List<Film> Films { get; set; }

    }
}