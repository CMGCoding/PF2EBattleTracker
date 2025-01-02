using Microsoft.EntityFrameworkCore;
using PF2EBattleTracker.API.Entities;

namespace PF2EBattleTracker.API.DbContexts
{
    public class CharacterInfoContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Condition> Conditions { get; set; }

        public CharacterInfoContext(DbContextOptions<CharacterInfoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character("Amanda", 3) { CharacterId = 1},
                new Character("Bob", 3) { CharacterId = 2 },
                new Character("Caitlyn", 3) { CharacterId = 3 }
                );

            modelBuilder.Entity<Condition>().HasData(
                new Condition("Clumsy") { ConditionId = 1, CharacterId = 1, Source = "Spell", Value = 1 },
                new Condition("Off Guard") { ConditionId = 2, CharacterId = 2, Source = "Flanked" },
                new Condition("Frightened") { ConditionId = 3, CharacterId = 3, Source = "Ghost", Value = 2 }
                );
        }
    }
}
 