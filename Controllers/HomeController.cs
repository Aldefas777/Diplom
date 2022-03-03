using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Interfaces;
using Project.Classes;

namespace Project.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult FAQ()
    {
        return View(); 
    }

    public IActionResult Gallery()
    {
        return View();
    }

}
