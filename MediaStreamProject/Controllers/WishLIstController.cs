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
        public ActionResult AddFilmWishList(Film film)
        {
            if (Session["FilmWishList"] == null)
            {
                Session["FilmWishList"] = new List<Film>();
            }
            List<Film> filmavoir = (List<Film>)Session["FilmWishList"];
            filmavoir.Add(film);
            Session["FilmWishList"] = filmavoir;
            ViewBag.wishList = Session["FilmWishList"];

            



            return View("FilmWishList");
        }
        
        
    }
}
