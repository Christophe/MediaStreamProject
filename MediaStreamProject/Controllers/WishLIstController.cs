using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class WishLIstController : Controller
    {
        // GET: WishLIst
        static Model1 model = new Model1();
        static List<Film> films = new List<Film>();
        public ActionResult AddFilmWishList(Film film)
        {
            films.Add(film);

            return View("FilmWishList");
        }
        
        
    }
}
