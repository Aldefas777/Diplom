using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Interfaces;
using Project.Classes;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public ICostumerRepository _costumerRepository;

    public HomeController(ILogger<HomeController> logger, ICostumerRepository costumerRepository)
    {
        _logger = logger;
        _costumerRepository = costumerRepository;
    }

    public IActionResult Index()
    {
        var model = _costumerRepository.GetUsers();
        return View(model); ;
    }

    public IActionResult Delete(int? id)
    {
        ViewBag.Id = id;
        var model = _costumerRepository.DeleteUser(id);
        return View(model); ;
    }

    public IActionResult Privacy(int Id, string names, string surname, string SecondName, string Aboniment)
    {
        _costumerRepository.AddUsers(Id, names, surname, SecondName, Aboniment);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
