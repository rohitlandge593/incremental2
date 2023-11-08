using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class TeamController : Controller
    {
        // private readonly ILogger<TeamController> _logger;

        // public TeamController(ILogger<TeamController> logger)
        // {
        //     _logger = logger;
        // }
        ApplicationDbContext _context;
        public TeamController(ApplicationDbContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var teamList=_context.Teams;
            return View(teamList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            _context.Teams.Add(team);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}