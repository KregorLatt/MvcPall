using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcBall.Models
{
    public class MovieGenreViewModel
    {
        public List<Ball> Balls { get; set; }
        public SelectList Color { get; set; }
        public string BallColor { get; set; }
        public string SearchString { get; set; }
    }
}