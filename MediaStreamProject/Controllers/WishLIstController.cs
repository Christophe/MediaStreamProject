using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishLIst
        static Model1 model = new Model1();
         
        
        public ActionResult AddFilmWishList(int id )
        {
            
            var user =(int) Session["userId"];

            var FilmWishList = model.FilmWishLists;
            FilmWishList filmavoir = null;
            var query = from FilmList in FilmWishList
                        where (FilmList.UserId == user) && (FilmList.FilmId == id)
                        select FilmList;

            foreach (var item in query)
            {
                filmavoir = item;
            }
                if (filmavoir == null)
                {
                    FilmWishList filmWishList = new FilmWishList(user, id);
                    model.FilmWishLists.Add(filmWishList);

                    
                }

                else
                {
                    ViewBag.message = "ce film fait déja partie de votre wishliste";
                }
            

            

            model.SaveChanges();


            return RedirectToAction("AfficherWishList");
            
        }

        public ActionResult AfficherWishList()
        {
            var Film = model.Films;
            var FilmWishList = model.FilmWishLists;
            var user = (int)Session["userId"];

            var joinQuery =
                from film in Film
                from filmList in FilmWishList
                where (filmList.FilmId == film.Id) && (filmList.UserId == user)
                select new NewClassWishList() { id = film.Id, titre = film.Title, image = film.Image, video = film.Video };
            
            ViewBag.List_WishList = joinQuery.ToList();
            return View("WishList");

        }


    }
}
