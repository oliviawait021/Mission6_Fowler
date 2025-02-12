using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Form response) // post of the Movie form page
    {
        _context.Movies.Add(response);
        _context.SaveChanges(); // Save Changes in the database
        return View("Confirmation", response);
    }
}