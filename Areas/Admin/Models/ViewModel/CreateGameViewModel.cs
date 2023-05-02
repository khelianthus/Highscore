namespace Highscore.Areas.Admin.Models.ViewModel;

public class CreateGameViewModel
{
   public string Name { get; set; }
   public string Genre { get; set; }
   public int LaunchYear { get; set; }
   public string ImageUrl { get; set; }
   public string Description { get; set; }
   public string UrlSlug { get; set; }
   public List<string> Genres { get; set; }
}

