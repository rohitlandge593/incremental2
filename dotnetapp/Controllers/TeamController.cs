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
        public TeamController(Applicatio)

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}