using Highscore.Data;
using Highscore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Highscore.Controllers;
public class GamesController : Controller
{

   private readonly ApplicationContext context;

   public GamesController(ApplicationContext context)
   {
      this.context = context; 
   }

   [Route("games/{urlSlug}")]
   public IActionResult Details(string urlSlug)
   {
      var game = context.Game.FirstOrDefault(g => g.UrlSlug == urlSlug);

      var scores = context.Score.Where(s => s.Game.UrlSlug == urlSlug).ToList();

      var highscores = scores.Select(s => new Highscores
      {
         Highscore = s.HighScore,
         GameTitle = s.Game.Name,
         GameLink = s.Game.UrlSlug,
         RecordDate = s.Year,
         RecordHolder = s.UserName
      }).ToList();

      List<Highscores> sortedHighscores = highscores.OrderByDescending(s => s.Highscore).Take(10).ToList();
      
      ViewData["Title"] = game.Name;

      var viewModel = new GameDetailsViewModel
      {
         Game = game,
         HighScores = sortedHighscores
      };

      return View(viewModel);
   }

}
