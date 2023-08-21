using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_A_Dog.Data;
using Rent_A_Dog.Models;

namespace Rent_A_Dog.Controllers
{
    public class KopekController : Controller
    {
        private readonly ApplicationDbContext sql_İliskisi;
        KopekIlan kopekIlan;
        Teklif teklif;
        public KopekController(ApplicationDbContext _sql_İliskisi)
        {
            sql_İliskisi = _sql_İliskisi;       
        }
        public IActionResult Index()
        {
			IEnumerable<KopekIlan> kopekIlans = sql_İliskisi.KopekIlan.Where(u => u.Email == User.Identity.Name).ToList();
			if (kopekIlans == null)
			{
				return NotFound();
			}
			return View(kopekIlans);
		}
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(KopekIlan obj)
        {
            //int rndm = rnd.Next(100000, 999999);
            //List<int> kopekIlans = sql_İliskisi.KopekIlan.Select(s => s.SeriNo).ToList();

            obj.Email = User.Identity.Name;
            sql_İliskisi.KopekIlan.Add(obj);
            sql_İliskisi.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            kopekIlan = sql_İliskisi.KopekIlan.Find(id);
            sql_İliskisi.KopekIlan.Remove(kopekIlan);
            sql_İliskisi.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            kopekIlan = sql_İliskisi.KopekIlan.Find(id);
            if (kopekIlan == null)
            {
                return NotFound();
            }
            return View(kopekIlan);
        }
        [HttpPost]
        public IActionResult Details(string? id) //Silmek
        {
            return Delete(Convert.ToInt32(id));
        }
        [HttpPost]
		public IActionResult Update(KopekIlan obj) //Update
		{
            obj.Email = User.Identity.Name;
			sql_İliskisi.KopekIlan.Update(obj);
			sql_İliskisi.SaveChanges();
            return Redirect("Details/"+obj.Id.ToString());
		}
        [HttpGet]
        [Authorize]
		public async Task<IActionResult> Teklif(int id) //Update
		{
            var  kopekIlan = await sql_İliskisi.KopekIlan.FirstOrDefaultAsync(u => u.Id == id) ?? new KopekIlan() { DogName="Geçersiz Köpek Bilgisi, Lütfen İletişime Geçin"};
            return View(new IlanVerDTO() { ReferansIlan=kopekIlan, TeklifIlan = new Teklif()} );
		}

        [HttpPost, ValidateAntiForgeryToken]
		public IActionResult Teklif(IlanVerDTO ilan) //Update
		{
            ilan.TeklifIlan.Email = User.Identity.Name;
            ilan.TeklifIlan.IlanEmail=ilan.ReferansIlan.Email;
            sql_İliskisi.Teklif.Add(ilan.TeklifIlan);
            sql_İliskisi.SaveChanges();
			return RedirectToAction("Index","Home");
		}

		public IActionResult Tekliflerim() //Update
        {
            IEnumerable<Teklif> tekliflerim = sql_İliskisi.Teklif.Where(u => u.Email == User.Identity.Name).ToList();
            return View(tekliflerim);
        }

		public IActionResult DeleteTeklif(int id)
        {
			Teklif teklif = sql_İliskisi.Teklif.Find(id);
            sql_İliskisi.Teklif.Remove(teklif);
            sql_İliskisi.SaveChanges();
            return RedirectToAction("Tekliflerim","Kopek");

		}
		public IActionResult GelenTeklifler()
        {
			IEnumerable<Teklif> teklifler = sql_İliskisi.Teklif.Where(u => u.IlanEmail == User.Identity.Name).ToList();
			return View(teklifler);
		}
        public IActionResult TeklifEnabled(int id)
        {
			Teklif obj = sql_İliskisi.Teklif.Find(id);
			obj.Enable = true;
            sql_İliskisi.Update(obj);
            sql_İliskisi.SaveChanges();
			return RedirectToAction("GelenTeklifler", "Kopek");
		}
		//[HttpPost]
		//public IActionResult Details(bool x) //Silmek
		//{
		//	sql_İliskisi.KopekIlan.Update();
		//	sql_İliskisi.SaveChanges();
		//	return View();
		//}

	}
}
