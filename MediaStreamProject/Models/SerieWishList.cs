using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{
    public class SerieWishList
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }


        public virtual int FilmId { get; set; }

    }
}