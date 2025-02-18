using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Fowler.Models;
using SQLitePCL;

namespace Mission6_Fowler.Controllers
{
    // HomeController handles requests related to movie data management
    public class HomeController : Controller
    {
        private MovieContext _context; // Declares the context to interact with the database

        // Constructor that initializes the controller with a MovieContext
        public HomeController(MovieContext someName) 
        {
            _context = someName; // Initializes the _context with the injected database context
        }

        // Action that renders the Index view
        public IActionResult Index() 
        {
            return View(); // Returns the default view for the homepage
        }

        // Action that renders a "Know Joel" page
        public IActionResult KnowJoel() 
        {
            return View(); // Returns the view for the "Know Joel" page
        }

        // GET action that renders the MovieForm for adding a new movie
        [HttpGet]
        public IActionResult MovieForm() 
        {
            ViewBag.Categories = _context.Categories.ToList(); // Passes categories to the view
            return View(new Form()); // Initializes a new Form object to be used in the view
        }

        // POST action that processes the form submission for adding a new movie
        [HttpPost]
        public IActionResult MovieForm(Form response) 
        {
            // Check if the model is valid (based on the form data)
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Adds the new movie to the database
                _context.SaveChanges(); // Saves changes to the database
                return View("Confirmation", response); // Displays the confirmation view
            }
            else
            {
                // If the form is invalid, reload categories and return the view with the current form data
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
        }

        // Action that fetches and displays the collection of movies
        public IActionResult MovieCollection()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList(); // Fetches all movies with their associated category
            return View(movies); // Returns the view with the list of movies
        }

        // GET action for editing an existing movie record based on its ID
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id); // Fetches the movie record to be edited
            ViewBag.Categories = _context.Categories.ToList(); // Passes categories to the view
            return View("MovieForm", recordToEdit); // Returns the movie form view populated with the existing movie data
        }

        // POST action that processes the updated movie data and saves changes to the database
        [HttpPost]
        public IActionResult Edit(Form updatedMovie)
        {
            _context.Update(updatedMovie); // Updates the movie record in the database
            _context.SaveChanges(); // Saves the changes to the database
            return RedirectToAction("MovieCollection"); // Redirects to the movie collection page after saving
        }

        // GET action to render the delete confirmation page for a specific movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id); // Fetches the movie record to be deleted
            return View("Delete", recordToDelete); // Returns the delete confirmation view with the movie data
        }

        // POST action to handle the deletion of a movie
        [HttpPost]
        public IActionResult Delete(Form recordToDelete)
        {
            _context.Movies.Remove(recordToDelete); // Removes the movie record from the database
            _context.SaveChanges(); // Saves the changes (deletes the movie)
            return RedirectToAction("MovieCollection"); // Redirects to the movie collection page after deletion
        }
    }
}
