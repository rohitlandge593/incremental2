using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Team
    {
        [Key]
        public int TeamId{get;set;}
        [Required(ErrorMessage="Name is Required")]
        public string Name{get;set;}
        public ICollection<Player> Player{get;set;}
    }
}