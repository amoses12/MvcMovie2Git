using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie2.Models;
using Newtonsoft.Json;

namespace MvcMovie2.Controllers
{
    public class MoviesController : Controller
    {
        private MovieModel db = new MovieModel();

        // GET: Movies
        public ActionResult Index()
        {
            //var GenreLst = new List<string>(); //creates new list of Genres empty list

            //var GenreQry = from d in myMovies //LINQ query retreieves genre of each movie in database (what is d?)
            //               orderby d.Genre
            //               select d.Genre;

            //GenreLst.AddRange(GenreQry.Distinct()); //adds a distinct filter to only use distinct genres
            //ViewBag.movieGenre = new SelectList(GenreLst); //stores list of genres as a SelectList object (dropdown menu) in ViewBag.movieGenre object

            //var movies = from m in db.Movies //LINQ query retrieves movies from database (what is m?)
            //             select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.MovieName.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre); //checks movieGenre parameter (what is x?)
            //}

            return View();
        }

        public ActionResult GetMovies()
        {
            List<Movie> movies = db.Movies.ToList();
            foreach(Movie movie in movies)
            {
                movie.StringReleaseDate = movie.ReleaseDate.ToShortDateString();
            }
            return Json(movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMovies(string Genre)
        {
            List<Movie> Movies = db.Movies.Where(x => x.Genre == Genre).ToList();
            return Json(Movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGenreList()
        {
            List<Movie> Movies = db.Movies.ToList();
            List<string> GenreNames = new List<string>();
            foreach( Movie movie in Movies)
            {
                if (GenreNames.IndexOf(movie.Genre) == -1)
                {
                    GenreNames.Add(movie.Genre);
                }
            }
            return Json(GenreNames, JsonRequestBehavior.AllowGet);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id); //Find method verifies that a movie has been found before the code trieds to do anything with it. keeps hackers from changing url and messing with database
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieName,ReleaseDate,Genre,Rating,Price")] Movie movie) //displays initial create form
        {
            if (ModelState.IsValid) //checks for any validation errors and redirects back to create form if there are. Otherwas it..
            {
                db.Movies.Add(movie); //adds movie to database
                db.SaveChanges();   //saves changes to database
                return RedirectToAction("Index");   //returns back to index view with saved changes
            }

            return View(movie); //returns movie view
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieName,ReleaseDate,Genre,Rating,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")] //helps with routing so there's no confusion between Delete and DeleteConfirmed methods
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
