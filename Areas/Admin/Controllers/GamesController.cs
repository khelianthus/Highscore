using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Highscore.Data;
using Highscore.Models.Models;
using Highscore.Areas.Admin.Models.ViewModel;

namespace Highscore.Areas.Admin.Controllers
{
   [Area("Admin")]
   public class GamesController : Controller
   {
      private readonly ApplicationContext context;

      public GamesController(ApplicationContext context)
      {
         this.context = context;
      }

      // GET: Admin/Games
      public async Task<IActionResult> Index()
      {
         return context.Game != null ?
                     View(await context.Game.ToListAsync()) :
                     Problem("Entity set 'ApplicationContext.Game'  is null.");
      }

      // GET: Admin/Games/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null || context.Game == null)
         {
            return NotFound();
         }

         var game = await context.Game
             .FirstOrDefaultAsync(m => m.Id == id);
         if (game == null)
         {
            return NotFound();
         }

         return View(game);
      }

      // GET: Admin/Games/Create
      public IActionResult New()
      {
         var genres = context.Game.Select(g => g.Genre).Distinct().ToList();
         var viewModel = new CreateGameViewModel { Genres = genres };
         return View(viewModel);
      }

      // POST: Admin/Games/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Name,Genre,LaunchYear,ImageUrl,Description")] Game game)
      {
         if (ModelState.IsValid)
         {
            game.UrlSlug = GenerateUrlSlug(game.Name); 
            context.Add(game);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(game);
      }

      private string GenerateUrlSlug(string name)
      {
         string slug = name.ToLower().Replace(" ", "-"); 
         return slug;
      }

      // GET: Admin/Games/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null || context.Game == null)
         {
            return NotFound();
         }

         var game = await context.Game.FindAsync(id);
         if (game == null)
         {
            return NotFound();
         }
         return View(game);
      }

      // POST: Admin/Games/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Genre,LaunchYear,ImageUrl,Description,UrlSlug")] Game game)
      {
         if (id != game.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               context.Update(game);
               await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!GameExists(game.Id))
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
         return View(game);
      }

      // GET: Admin/Games/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null || context.Game == null)
         {
            return NotFound();
         }

         var game = await context.Game
             .FirstOrDefaultAsync(m => m.Id == id);
         if (game == null)
         {
            return NotFound();
         }

         return View(game);
      }

      // POST: Admin/Games/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         if (context.Game == null)
         {
            return Problem("Entity set 'ApplicationContext.Game'  is null.");
         }
         var game = await context.Game.FindAsync(id);
         if (game != null)
         {
            context.Game.Remove(game);
         }

         await context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool GameExists(int id)
      {
         return (context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
      }
   }
}
