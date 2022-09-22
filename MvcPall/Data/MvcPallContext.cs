using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBall.Models;

namespace MvcPall.Data
{
    public class MvcPallContext : DbContext
    {
        public MvcPallContext (DbContextOptions<MvcPallContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBall.Models.Ball> Ball { get; set; }
    }
}
