using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Data
{
    public class HallOfFameDbContext : DbContext
    {
        public HallOfFameDbContext(DbContextOptions<HallOfFameDbContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<SkillModel> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=test;Password=12345");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}