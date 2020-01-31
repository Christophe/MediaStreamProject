using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MediaStreamProject.Controllers
{
    public class LoginController : Controller
    {
        // Methode pour se connecter : GET
        public ActionResult Connexion()
        {
            // Booleen pour savoir si on a un cookie
            var Authenticate = HttpContext.User.Identity.IsAuthenticated;
            //Stockage du bool dans un ViewData
            ViewData["Authenticate"] = Authenticate;
            User user = null;
            if (Authenticate == true)
            {
                using (var model = new Model1())
                {
                    user = (from u in model.Users
                            where u.Login == HttpContext.User.Identity.Name
                            select u).FirstOrDefault();
                }
            }
            return View(user);
        }
        // Methode pour se connecter : POST
        [HttpPost]
        public ActionResult Connexion(User user)
        {
            // Initialisation d'un User
            User user1 = null;
            var model = new Model1();
            // Si le model renvoyer dans le formulaire est valide
            if (ModelState.IsValid)
            {
                // Requete Query pour afficher l'utilisateur qui a le bon Login
                user1 = (from u in model.Users
                         where u.Login.Equals(user.Login)
                         select u).FirstOrDefault();
                // Si le user.Password entre par l'utilisateur a le meme que celui crypte 
                if (Crypto.VerifyHashedPassword(user1.Password, user.Password))
                {
                    if (user1 != null)
                    {
                        // Si le Role n'est pas null alors il s'agit d'un admin
                        if (user1.Role != null)
                        {
                            FormsAuthentication.SetAuthCookie(user1.Login.ToString(), false);
                            ViewData["Authentifie"] = true;
                            return Redirect("/Admin/Index");
                        }
                        // Sinon c'est un utilisateur lambda
                        else
                        {
                            FormsAuthentication.SetAuthCookie(user1.Login.ToString(), false);
                            ViewData["Authentifie"] = true;

                            // On stock l'Id de l'User en Session
                            Session["userId"] = user.Id;

                            return Redirect("/Home/Contenu");
                        }
                    }
                }
            }
            return View(user);
        }

        // GET : Methode pour s'inscrire
        public ActionResult Inscription()
        {
            return View();
        }

        // POST : Methode pour s'inscrire
        [HttpPost]
        public ActionResult Inscription(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);
                using (var model = new Model1())
                {
                    model.Users.Add(user);
                    model.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(user.Login.ToString(), true);

                // On stock l'Id de l'User en Session
                Session["userId"] = user.Id;

                return Redirect("/Home/Contenu");
            }
            return View(user);
        }

        // Methode pour se deconnecter
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}