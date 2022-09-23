using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBall.Models
{
    public class Ball
    {
        public int Id { get; set; }
        

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Color { get; set; }
        

        
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        

        
        [Required]
        [Range(1, 100)]
        public int Size { get; set; }
        

        
        [Required]
        [StringLength(30)]
        public string Players { get; set; }
        
    }

    
}