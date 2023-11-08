﻿using System;
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





        private static  List<Player> pList=new List<Player>();
        // {
        //     new Player{Id=1,Age=25,Name="Sunil Chhetri",Category="Football",BiddingAmount=10000},
        //     new Player{Id=2,Age=30,Name="Virat Kohli",Category="Cricket",BiddingAmount=20000},
        //     new Player{Id=3,Age=35,Name="Virender",Category="Boxing",BiddingAmount=30000},
        //     new Player{Id=4,Age=40,Name="Anup Kumar",Category="Kabaddi",BiddingAmount=40000},
        // };
            
        
        public IActionResult Index()
        {
            
            return View(pList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            pList.Add(player);
            
            return RedirectToAction("Index");
        }
        public IActionResult FindPlayer()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeletePlayer(int id)
        {
            var playerList=pList.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                return View(playerList);
            }
            else    
                return NotFound();
        }
        [HttpPost]
        public IActionResult DeletePlayer(int id,Player player)
        {
            var playerList=pList.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                pList.Remove(playerList);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            var playerList=pList.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                return View(playerList);
            }
            else    
                return NotFound();
        }
        [HttpPost]
        public IActionResult EditPlayer(int id,Player player)
        {
            var playerList=pList.FirstOrDefault(i=>i.Id==id);
            if(playerList!=null)
            {
                playerList.Age=player.Age;
                playerList.Name=player.Name;
                playerList.Category=player.Category;
                playerList.BiddingAmount=player.BiddingAmount;
                
            }
            return RedirectToAction("Index");
        }

    }
}




