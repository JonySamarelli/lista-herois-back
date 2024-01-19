using Microsoft.EntityFrameworkCore;
using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public class SuperHeroisContext : DbContext
    {
        private IConfiguration Configuration { get; }
        private readonly string connecationString;
        public DbSet<Herois> Herois { get; set; } = null!;
        public DbSet<Superpoderes> Superpoderes { get; set; } = null!;
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; } = null!;

        public SuperHeroisContext(IConfiguration configuration)
        {
            Configuration = configuration;
            connecationString = Configuration["Database:ConnectionString"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(connecationString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Herois>()
                .Property(h => h.Id).IsRequired();

            modelBuilder.Entity<Superpoderes>()
                .Property(s => s.Id).IsRequired();

            modelBuilder.Entity<HeroisSuperpoderes>()
                .HasKey(hs => new { hs.HeroiId, hs.SuperpoderId });

        }

    }
}
