using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Team
    {
        public int TeamId{get;set;}
        public string Name{get;set;}
        public ICollection<Player> Player{get;set;}
    }
}