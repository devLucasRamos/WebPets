using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ViewModel;
using WebPets.Models;

namespace WebPets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext Context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            Context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = Context.Pets.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pets pets)
        {
            Context.Pets.Add(pets);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public Pets GetById(int id) => Context.Pets.FirstOrDefault(x => x.Id == id);

        public void Remove(int id)
        {
            var pet = Context.Pets.Find(id);
            Context.Pets.Remove(pet);
            Context.SaveChanges();
        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = GetById(id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public void Update(int id)
        {
            var pet = Context.Pets.Find(id);
            Context.Pets.Update(pet);
            Context.SaveChanges();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = GetById(id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            Update(id);
            return RedirectToAction(nameof(Index));
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
