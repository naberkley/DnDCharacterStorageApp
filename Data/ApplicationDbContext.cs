using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDCharacterStorageApp.Models;

namespace DnDCharacterStorageApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Character> Character { get; set; } = default!;
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Character>()
                .HasMany(c => c.AbilitiesList)
                .WithOne()
                .HasForeignKey(a => a.CharacterId);

            builder.Entity<Character>()
                .HasMany(c => c.SkillsList)
                .WithOne()
                .HasForeignKey(s => s.CharacterId);
        }
    }

}
