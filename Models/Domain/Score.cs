using Highscore.Data;
using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace Highscore.Models.Models;

//[Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
public class Score
{
   public int Id { get; set; }
   public Game Game { get; set; }

   [MaxLength(50)]
   public string UserName { get; set; }
   public DateTime Year { get; set; }

   [MaxLength(50)]
   public int HighScore { get; set; }


}