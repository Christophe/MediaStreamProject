using System.ComponentModel.DataAnnotations;

namespace MediaStreamProject.Models
{
    public class NewClassWishList
    {
        public NewClassWishList()
        {
        }

        public int id { get; set; }
        public string titre { get; set; }
        public Genre genre { get; set; }
        public string image { get; set; }
        public string video { get; set; }
    }
}
