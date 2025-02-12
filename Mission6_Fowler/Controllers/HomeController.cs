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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult KnowJoel()
    {
        return View();
    }
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Form response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
}