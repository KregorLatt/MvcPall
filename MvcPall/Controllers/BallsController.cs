using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBall.Models;
using MvcPall.Data;

namespace MvcPall.Controllers
{
    public class BallsController : Controller
    {
        private readonly MvcPallContext _context;

        public BallsController(MvcPallContext context)
        {
            _context = context;
        }

        // GET: Balls
        public async Task<IActionResult> Index(string BallColor, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> colorQuery = from m in _context.Ball
                                            orderby m.Color
                                            select m.Color;

            var balls = from m in _context.Ball
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                balls = balls.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(BallColor))
            {
                balls = balls.Where(x => x.Color == BallColor);
            }

            var ballColorVM = new BallColorViewModel
            {
                Color = new SelectList(await colorQuery.Distinct().ToListAsync()),
                Balls = await balls.ToListAsync()
            };

            return View(ballColorVM);
        }

        // GET: Balls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ball = await _context.Ball
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ball == null)
            {
                return NotFound();
            }

            return View(ball);
        }

        // GET: Balls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Balls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,color,Name,size")] Ball ball)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ball);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ball);
        }

        // GET: Balls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ball = await _context.Ball.FindAsync(id);
            if (ball == null)
            {
                return NotFound();
            }
            return View(ball);
        }

        // POST: Balls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,color,Name,size")] Ball ball)
        {
            if (id != ball.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ball);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BallExists(ball.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ball);
        }

        // GET: Balls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ball = await _context.Ball
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ball == null)
            {
                return NotFound();
            }

            return View(ball);
        }

        // POST: Balls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ball = await _context.Ball.FindAsync(id);
            _context.Ball.Remove(ball);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BallExists(int id)
        {
            return _context.Ball.Any(e => e.Id == id);
        }
    }
}
