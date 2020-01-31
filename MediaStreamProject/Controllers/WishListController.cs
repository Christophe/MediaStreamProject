using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStreamProject.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult AddToWishListFilm()
        {
            return View();
        }
    }
}