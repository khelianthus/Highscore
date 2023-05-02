using Highscore.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Highscore.Models.Models;

[Microsoft.EntityFrameworkCore.Index(nameof(UrlSlug), IsUnique = true)]
public class Game
{
   public int Id { get; set; }

   [MaxLength(50)]
   public string Name { get; set; }

   [MaxLength(50)]
   public string Genre { get; set; }
   public int LaunchYear { get; set; }

   [MaxLength(250)]
   [Url]
   public string ImageUrl { get; set; }

   [MaxLength(500)]
   public string Description { get; set; }

   [MaxLength(50)]
   public string? UrlSlug { get; set; }
   public List<Score> Scores { get; set; } = new List<Score>();

   public void AddScore(Score score)
   {
      Scores.Add(score);
   }
}
