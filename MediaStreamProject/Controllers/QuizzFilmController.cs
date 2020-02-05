using MediaStreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaChill.Controllers
{
    public class QuizzFilmController : Controller
    {
        static Model1 model = new Model1();
        static DateTime DateStart;
        static Dictionary<string, string> userAnswers = new Dictionary<string, string>();
        // GET: Quizz

        public ActionResult QuizzFilm()
        {
            bool Quizz =true;
            ViewBag.ID = 0;
            ViewBag.Quizz = Quizz;
            return View();

        }

        [HttpPost]
        public ActionResult Start()
        {
            bool Quizz;
            DateStart = DateTime.Now;
            int userID = Convert.ToInt32(Session["userId"]);
            var quizzresults = model.QuizzResults;
            QuizzResult queryQuizzresults = null;
            // On stock toutes les series dans ViewBag.Serie
            var Query = from result in quizzresults
                        where result.UserID == userID && result.Theme == "film"
                        select result;
            foreach (var item in Query)
            {
                queryQuizzresults = item;
            }

            if (queryQuizzresults == null)
            { 
                ViewBag.ID = 1;
                Quizz = true;
                ViewBag.Quizz = Quizz;

            }
            else
            {
                Quizz = false;
                ViewBag.Quizz = Quizz;
            }
            return View("QuizzFilm");
        }

        [HttpPost]
        public ActionResult Question1(string answer1)
        {
            bool Quizz = true;
            if (Quizz)
            {
                ViewBag.ID = 2;
                try
                {
                    userAnswers.Add("Question1", answer1);

                }
                catch (Exception)
                {
                    userAnswers.Remove("Question1");
                    userAnswers.Add("Question1", answer1);
                }
            }
            ViewBag.Quizz = Quizz;
            return View("QuizzFilm");
        }

        [HttpPost]
        public ActionResult Question2(string answer2)
        {
            bool Quizz = true;
            if (Quizz)
            {
                ViewBag.ID = 3;
                try
                {
                    userAnswers.Add("Question2", answer2);
                }
                catch (Exception)
                {
                    userAnswers.Remove("Question2");
                    userAnswers.Add("Question2", answer2);

                }
            }
            ViewBag.Quizz = Quizz;
            return View("QuizzFilm");
        }

        [HttpPost]
        public ActionResult Question3(string answer3)
        {
            bool Quizz = true;
            TimeSpan timeDiff = DateTime.Now - DateStart;
            double time = timeDiff.TotalSeconds;
            
            int userID = Convert.ToInt32(Session["userId"]);
            var users = model.Users;
            int score = 0;
            User user = users.Find(userID);
            ViewBag.Quizz = Quizz;
            if (Quizz)
            {
                ViewBag.ID = 4;
                try
                {
                    userAnswers.Add("Question3", answer3);
                }
                catch (Exception)
                {
                    userAnswers.Remove("Question3");
                    userAnswers.Add("Question3", answer3);

                }
                Quizz = false;
            }

            Dictionary<string, string> goodAnswers = new Dictionary<string, string>() { { "Question1", "Il a été accusé d'avoir ouvert la Chambre des Secrets" }, 
                { "Question2", "Miss Teigne" }, { "Question3", "Remus, Sirius, Peter et James" } };
            foreach (var key in userAnswers.Keys)
            {
                if (userAnswers[key].Equals(goodAnswers[key]))
                {
                    score++;
                }
            }

            ViewBag.score = score;

            QuizzResult quizz = new QuizzResult();
            quizz.UserID = userID;
            quizz.Score = score;
            quizz.Theme = "film";
            quizz.UserLogin = user.Login;
            quizz.Time = time;
            model.QuizzResults.Add(quizz);
            model.SaveChanges();
            userAnswers.Clear();
            ViewBag.time=time;
            return View("QuizzFilm");
        }

        public ActionResult Results()
        {
            List<QuizzResult> allresults = new List<QuizzResult>();
            var quizzresults = model.QuizzResults;
            var Query = from result in quizzresults
                        orderby result.Score
                        select result;
            List<QuizzResult> list_results = Query.ToList<QuizzResult>();
            foreach (var item in list_results)
            {
                if (item.Theme == "film")
                {
                    allresults.Add(item);
                }
            }
            ViewBag.Results = allresults.ToList<QuizzResult>();
            return View();
        }
    }
}