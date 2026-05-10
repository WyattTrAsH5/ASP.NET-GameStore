using ASP.NET_GameStore.Data;
using ASP.NET_GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_GameStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return NotFound();
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}