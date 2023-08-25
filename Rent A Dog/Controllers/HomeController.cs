using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Kullanıcı ilk girdiğinde boşverilerin olduğu sayfayı hazırlar
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var ilanlar =await sql_İliskisi.KopekIlan.ToListAsync();
			return View(new Filtre()
			{
				kopekIlan = ilanlar,
				FiltreEndTime = ilanlar.Max(s => s.DogEndTime),
				FiltreStartTime = ilanlar.Min(s => s.DogStartTime),
                MaxDate = ilanlar.Max(s => s.DogEndTime),
                MinDate = ilanlar.Min(s => s.DogStartTime)
			});
        }

        [HttpPost]
		public async Task<IActionResult> Index(Filtre filtre)
		{
			filtre.kopekIlan = await sql_İliskisi.KopekIlan.Where(u=>u.DogStartTime>=filtre.FiltreStartTime 
            && u.DogEndTime<=filtre.FiltreEndTime
            && (u.DogType == filtre.FiltreDogType || string.IsNullOrWhiteSpace(filtre.FiltreDogType)) ).ToListAsync();
			return View(filtre);
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