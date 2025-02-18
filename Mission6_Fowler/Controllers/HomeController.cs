using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Fowler.Models;
using SQLitePCL;

namespace Mission6_Fowler.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;

    public HomeController(MovieContext someName) // Constructor
    {
        _context = someName;
    }

    public IActionResult Index() // Index View
    {
        return View();
    }

    public IActionResult KnowJoel() // Get to know Joel page
    {
        return View();
    }
    [HttpGet]
    public IActionResult MovieForm() // Get for the movie form page
    {
        ViewBag.Categories =  _context.Categories.ToList();
        return View(new Form());
    }

    [HttpPost]
    public IActionResult MovieForm(Form response) // post of the Movie form page
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges(); 
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories =  _context.Categories.ToList();
            return View(response);
        }
    }
    
    public IActionResult MovieList()
    {
        var movies = _context.Movies.Include(x => x.Category).ToList();
        
        return View(movies);
    }
}