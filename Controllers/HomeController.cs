using Final_cgp27.Models;
using Final_cgp27.Models.Data;
using Final_cgp27.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final_cgp27.Controllers
{
    public class HomeController : Controller
    {
        private IEntertainmentRepository repo;

        public HomeController(IEntertainmentRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entertainers()
        {
            EntertainersView entertainersView = new EntertainersView
            {
                EntertainersList = repo.Entertainers.ToList()
            };

            return View(entertainersView);
        }

        public IActionResult Details(long entertainerId)
        {
            Entertainers entertainer = repo.Entertainers.Where(x => x.EntertainerId == entertainerId).SingleOrDefault();

            return View(entertainer);
        }

        [HttpGet]
        public IActionResult AddEntertainer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEntertainer(Entertainers newEntry)
        {
            repo.AddEntertainer(newEntry);

            return RedirectToAction("Entertainers");
        }

        [HttpGet]
        public IActionResult DeleteEntertainer(long entertainerId)
        {
            Entertainers entertainer = repo.Entertainers.Where(x => x.EntertainerId == entertainerId).SingleOrDefault();
            repo.DeleteEntertainer(entertainer);

            return RedirectToAction("Entertainers");
        }

        [HttpGet]
        public IActionResult EditEntertainer(long entertainerId)
        {
            Entertainers entertainer = repo.Entertainers.Where(x => x.EntertainerId == entertainerId).SingleOrDefault();

            return View(entertainer);
        }

        [HttpPost]
        public IActionResult EditEntertainer(Entertainers entertainer)
        {

            repo.EditEntertainer(entertainer);

            return RedirectToAction("Entertainers");
        }
    }
}
