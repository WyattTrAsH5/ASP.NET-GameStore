using Microsoft.AspNetCore.Mvc;
using ASP.NET_GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_GameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, string genre, string platform)
        {
            var games = _context.Games.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                games = games.Where(g => g.Title.Contains(search));

            if (!string.IsNullOrEmpty(genre))
                games = games.Where(g => g.Genre == genre);

            if (!string.IsNullOrEmpty(platform))
                games = games.Where(g => g.Platform == platform);

            return View(await games.ToListAsync());
        }
    }
}