using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Highscore.Data;
using Highscore.Models.Models;

namespace Highscore.Areas.Admin.Controllers
{
   [Area("Admin")]
   public class ScoresController : Controller
   {
      private readonly ApplicationContext context;

      public ScoresController(ApplicationContext context)
      {
         this.context = context;
      }

      // GET: Admin/Scores
      public async Task<IActionResult> Index()
      {
         //Join(Include) för att hämta games från score också.
         return context.Score != null ?
                     View(await context.Score
                     .Include(s => s.Game)
                     .ToListAsync()) :
                     Problem("Entity set 'ApplicationContext.Score'  is null.");
      }

      // GET: Admin/Scores/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null || context.Score == null)
         {
            return NotFound();
         }

         var score = await context.Score
             .FirstOrDefaultAsync(m => m.Id == id);
         if (score == null)
         {
            return NotFound();
         }

         return View(score);
      }

      // GET: Admin/Scores/Create
      public IActionResult Create()
      {
         return View();
      }

      // POST: Admin/Scores/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,UserName,Year,HighScore")] Score score)
      {
         if (ModelState.IsValid)
         {
            context.Add(score);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(score);
      }

      // GET: Admin/Scores/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null || context.Score == null)
         {
            return NotFound();
         }

         var score = await context.Score.FindAsync(id);
         if (score == null)
         {
            return NotFound();
         }
         return View(score);
      }

      // POST: Admin/Scores/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Year,HighScore")] Score score)
      {
         if (id != score.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               context.Update(score);
               await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!ScoreExists(score.Id))
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
         return View(score);
      }

      // GET: Admin/Scores/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Delete(int id)
      {
         var score = await context.Score.FindAsync(id);
         if (score == null)
         {
            return NotFound();
         }

         context.Score.Remove(score);
         await context.SaveChangesAsync();

         return RedirectToAction(nameof(Index));
      }

      private bool ScoreExists(int id)
      {
         return (context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
      }
   }
}
