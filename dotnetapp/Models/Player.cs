// Models/Player.cs
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Player 
    {
        [Key]
        public int Id{get;set;}
        public int Age{get;set;}
        [Required(ErrorMessage="Name is Required")]
        public string Name{get;set;}
        public int TeamId{get;set;}
        public string Category{get;set;}
        public decimal BiddingAmount{get;set;}
        public Team? Team{get;set;}
    }
}
