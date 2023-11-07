using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        private List<Player> pList=new List<Player>{
            new Player{Id=1,Age=25,Name=Sunil Chhetri,Category=Football,BiddingPrice=10000},
            new Player{Id=2,Age=30,Name=Virat Kohli,Category=Cricket,BiddingPrice=20000},
            new Player{Id=3,Age=35,Name=Virender,Category=Boxing,BiddingPrice=30000},
            new Player{Id=4,Age=40,Name=,Category=Football,BiddingPrice=10000},
            
        }
        public IActionResult Index()
    }
}

