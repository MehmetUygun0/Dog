using Microsoft.AspNetCore.Mvc;
using Rent_A_Dog.Data;
using Rent_A_Dog.Models;
using System.Diagnostics;

namespace Rent_A_Dog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext sql_İliskisi;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _sql_İliskisi)
        {
            _logger = logger;
            sql_İliskisi = _sql_İliskisi;
        }

        public IActionResult Index()
        {
            IEnumerable<KopekIlan> kopekIlans = sql_İliskisi.KopekIlan.ToList();
            return View(kopekIlans);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}