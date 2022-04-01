﻿using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using eCommerceForPeripherials.Models.ViewModels;
using HltvParser;

namespace eCommerceForPeripherials.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //HltvParser.HltvParser parser = new HltvParser.HltvParser();
            //var Players = await parser.GetTopPlayers();

            TempData["Home"] = "active";

            IEnumerable<Item> itemList = _db.Items;

            return View(itemList.OrderByDescending(x=>x.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
          
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Contact()
        {
            TempData["Contact"] = "active";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                //await _db.Contacts.AddAsync(contactViewModel);
                //await _db.SaveChangesAsync();
            }
            return View();
        }


    }
}
