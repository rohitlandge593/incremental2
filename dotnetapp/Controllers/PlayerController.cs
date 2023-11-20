using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext context;

        public PlayerController(ApplicationDbContext _context)
        {
            context = _context;
        }





        private static  List<Player> pList=new List<Player>();
        // {
        //     new Player{Id=1,Age=25,Name="Sunil Chhetri",Category="Football",BiddingAmount=10000},
        //     new Player{Id=2,Age=30,Name="Virat Kohli",Category="Cricket",BiddingAmount=20000},
        //     new Player{Id=3,Age=35,Name="Virender",Category="Boxing",BiddingAmount=30000},
        //     new Player{Id=4,Age=40,Name="Anup Kumar",Category="Kabaddi",BiddingAmount=40000},
        // };
            
        [Route("Index")]
        public IActionResult Index()
        {
            var playerList=context.Players.Include("Team").ToList();
            
            return View(playerList);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.playerList=new SelectList(context.Players,"TeamId","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            //pList.Add(player);
            context.Players.Add(player);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FindPlayer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindPlayer(int id)
        {
            //var playerList=pList.FirstOrDefault(i=>i.Id==id);
            var playerList=context.Players.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                return View("Search",playerList);
            }
            else    
                return NotFound("ID Not Found");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var playerList=pList.FirstOrDefault(i=>i.Id==id);
            var playerList=context.Players.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                return View(playerList);
            }
            else    
                return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id,Player player)
        {
            //var playerList=pList.FirstOrDefault(i=>i.Id==id);
            var playerList=context.Players.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                //pList.Remove(playerList);
                context.Players.Remove(playerList);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var playerList=pList.FirstOrDefault(i=>i.Id==id);
            var playerList=context.Players.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                return View(playerList);
            }
            else    
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(int id,Player player)
        {
            //var playerList=pList.FirstOrDefault(i=>i.Id==id);
            var playerList=context.Players.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                playerList.Age=player.Age;
                playerList.Name=player.Name;
                playerList.Category=player.Category;
                playerList.BiddingAmount=player.BiddingAmount;
                context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

    }
}




