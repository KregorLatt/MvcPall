using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBall.Models
{
    public class Ball
    {
        public int Id { get; set; }
        public string Color { get; set; }

        
        
        public string Name { get; set; }
        public int Size { get; set; }
        public string Players { get; set; }

    }
}