using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBall.Models
{
    public class Ball
    {
        public int Id { get; set; }
        public string color { get; set; }

        
        
        public string Name { get; set; }
        public int size { get; set; }
    }
}