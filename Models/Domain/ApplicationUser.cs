using Highscore.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Highscore.Models.Domain;

public class ApplicationUser : IdentityUser
{

   [StringLength(50, MinimumLength = 1)]
   public string? FirstName { get; set; }

   [MaxLength(50)]
   public string? LastName { get; set; }

   public IList<Score> Scores { get; set; } = new List<Score>();

}