using Highscore.Models.Domain;
using Highscore.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Highscore.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
   public ApplicationContext(DbContextOptions<ApplicationContext> options)
      : base(options)
   {

   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);

      var administratorRole = new IdentityRole("Administrator");

      builder.Entity<IdentityRole>()
        .HasData(administratorRole);
   }

   public DbSet<Game> Game { get; set; }

   public DbSet<Score> Score { get; set; }
}