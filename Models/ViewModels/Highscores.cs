namespace Highscore.Models.ViewModels;

public class Highscores
{
   public string GameTitle { get; set; }
   public string GameLink { get; set; }
   public string RecordHolder { get; set; }
   public DateTime RecordDate { get; set; }
   public int Highscore { get; set; }
}