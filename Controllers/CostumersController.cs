using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Interfaces;
using Project.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class CostumersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ICostumerRepository _costumerRepository;

        public CostumersController(ILogger<HomeController> logger, ICostumerRepository costumerRepository)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
        }

        [Authorize]
        public IActionResult CostumersView(string search)
        {
            var model = _costumerRepository.GetUsers(search);
            return View(model); ;
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            ViewBag.Id = id;
            var model = _costumerRepository.DeleteUser(id);
            return View(model); ;
        }

        [Authorize]
        public IActionResult Add(int Id, string names, string surname, string SecondName, string Aboniment)
        {
            _costumerRepository.AddUsers(Id, names, surname, SecondName, Aboniment);
            return View();
        }

        [Authorize]
        public IActionResult Update(int? Id, string names, string surname, string SecondName, string Aboniment)
        {
            ViewBag.Id = Id;
            ViewBag.Names = names;
            _costumerRepository.UpdateUser(Id, names, surname, SecondName, Aboniment);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
