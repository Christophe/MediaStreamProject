using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaChill.Controllers
{
    public class QuizzController : Controller
    {
        static Model1 model = new Model1();
        static int score;
        static bool Quizz;
        static Dictionary<string, string> check = new Dictionary<string, string>();
        // GET: Quizz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuizzSerie()
        {

            ViewBag.ID = 0;
            Quizz = true;
            ViewBag.Quizz = Quizz;
            return View();

        }

        [HttpPost]
        public ActionResult Start()
        {
            int userID = Convert.ToInt32(Session["userId"]);
            var quizzresults = model.QuizzResults;
            QuizzResult queryQuizzresults = null;
            // On stock toutes les series dans ViewBag.Serie
            var Query = from result in quizzresults
                        where result.UserID == userID
                        select result;
            foreach (var item in Query)
            {
                queryQuizzresults = item;
            }

            if (queryQuizzresults == null)
            {
                score = 0;
                ViewBag.ID = 1;
                Quizz = true;
                ViewBag.Quizz = Quizz;

            }
            else
            {
                Quizz = false;
                ViewBag.Quizz = Quizz;
            }
            return View("QuizzSerie");
        }

        [HttpPost]
        public ActionResult Question1(string answer1)
        {

            if (Quizz)
            {
                ViewBag.ID = 2;
                try
                {
                    check.Add("6", answer1);

                }
                catch (Exception)
                {
                    check.Remove("6");
                    check.Add("6", answer1);
                }
            }
            ViewBag.Quizz = Quizz;
            return View("QuizzSerie");
        }

        [HttpPost]
        public ActionResult Question2(string answer2)
        {
            if (Quizz)
            {
                ViewBag.ID = 3;
                check.Add("5", answer2);
            }
            ViewBag.Quizz = Quizz;
            return View("QuizzSerie");
        }

        [HttpPost]
        public ActionResult Question3(string answer3)
        {
            int userID = Convert.ToInt32(Session["userId"]);
            var users = model.Users;
            User user = users.Find(userID);
            ViewBag.Quizz = Quizz;
            if (Quizz)
            {
                ViewBag.ID = 4;
                check.Add("2", answer3);
                Quizz = false;
            }


            foreach (KeyValuePair<string, string> entry in check)
            {
                if (entry.Key == entry.Value)
                {
                    score++;
                }
            }

            ViewBag.score = score;

            QuizzResult quizz = new QuizzResult();
            quizz.UserID = userID;
            quizz.Score = score;
            quizz.Theme = "serie";
            quizz.UserLogin = user.Login;
            model.QuizzResults.Add(quizz);
            model.SaveChanges();
            check.Clear();
            return View("QuizzSerie");
        }

        public ActionResult Results()
        {
            var quizzresults = model.QuizzResults;
            var Query = from result in quizzresults
                        orderby result.Score
                        select result;
            ViewBag.Results = Query.ToList<QuizzResult>();
            return View();
        }
    }
}