using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPall.Data;
using System;
using System.Linq;

namespace MvcBall.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPallContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPallContext>>()))
            {
                // Look for any Balls.
                if (context.Ball.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ball.AddRange(
                    new Ball
                    {
                        Name = "Võrkpall",
                        Color = "Kollane",
                        Size = 4
                    },

                    new Ball
                    {
                        Name = "Jalgpall",
                        Color = "Valge",
                        Size = 5
                    },

                    new Ball
                    {
                        Name = "Käsipall",
                        Color = "Sinine",
                        Size = 2
                    },

                    new Ball
                    {
                        Name = "Korvpall",
                        Color = "Pruun",
                        Size = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}