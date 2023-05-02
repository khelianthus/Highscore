using Highscore.Data;
using Highscore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Highscore.Controllers;
public class HomeController : Controller
{

   private readonly ApplicationContext context;
   public HomeController(ApplicationContext context)
   {
      this.context = context;
   }

   public IActionResult Index()
   {

      var games = context.Game.ToList();
      var score = context.Score.ToList();

      var gameHighScores = context.Score
          .GroupBy(s => s.Game)
          .Select(g => new
          {
             GameName = g.Key.Name,
             GameLink = g.Key.UrlSlug,
             HighestScore = g.Max(s => s.HighScore),
             RecordHolder = g.OrderByDescending(s => s.HighScore).FirstOrDefault().UserName,
             Year = g.OrderByDescending(s => s.HighScore).FirstOrDefault().Year
          })
          .ToList();

      var ListComponentViewBoard = gameHighScores.Select(s =>
         new ListComponentViewBoard
         {
            GameTitle = s.GameName,
            GameLink = s.GameLink,
            RecordHolder = s.RecordHolder,
            RecordDate = s.Year,
            Highscore = s.HighestScore,
         });

      var globalLeaderBoard = new GlobalLeaderboard
      {
         ListComponent = ListComponentViewBoard
      };

      return View(globalLeaderBoard);
   }

}
