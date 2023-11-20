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
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teamList=_context.Teams.FirstOrDefault(i=>i.TeamId==id);
            if(teamList!=null)
            {
                return View(teamList);
            }
            else    
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(int id,Team team)
        {
            var teamList=_context.Teams.FirstOrDefault(i=>i.TeamId==id);
            if(teamList!=null)
            {
                teamList.TeamId=team.TeamId;
                teamList.Name=team.Name;
                _context.SaveChanges();
               return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}