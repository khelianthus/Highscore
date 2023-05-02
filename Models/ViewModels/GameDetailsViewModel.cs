using Highscore.Models.Models;

namespace Highscore.Models.ViewModels;
public class GameDetailsViewModel
{
   public Game Game { get; set; }

   public IEnumerable<Highscores> HighScores { get; set; }
}