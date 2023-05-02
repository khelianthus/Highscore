using Highscore.Data;
using Highscore.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Highscore.Controllers;
public class HighscoresController : Controller
{
   private readonly ApplicationContext context;
   public HighscoresController(ApplicationContext context)
   {
      this.context = context;
   }

   [Authorize]
   public IActionResult New()
   {
      var games = context.Game.ToList();
      return View(games);
   }

   [HttpPost]
   public async Task <IActionResult> New([FromForm] Form form)
   {
      var gameName = form.Game.Name;
      var game = context.Game.FirstOrDefault(x => x.Name == gameName);

      if (game == null)
      {
         return BadRequest("Game not found");
      }

      var newScore = new Score
      {
         Game = game,
         UserName = form.UserName,
         Year = form.Year,
         HighScore = form.Highscore
      };

      game.AddScore(newScore);
      context.SaveChanges();

      return Redirect($"/highscores/new");

   }

   public class Form
   {
      public string UserName { get; set; }
      public DateTime Year { get; set; }
      public Game Game { get; set; }
      public int Highscore { get; set; }
   }
}
