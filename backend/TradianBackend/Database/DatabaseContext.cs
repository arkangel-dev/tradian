using Microsoft.EntityFrameworkCore;

namespace TradianBackend.Database {
    public class DatabaseContext : DbContext {
        public DbSet<Entities.Post> Posts { get; set; }
        public DbSet<Entities.Container> Containers { get; set; }
        public DbSet<Entities.FooterLink> FooterLinks { get; set; }
        public DbSet<Entities.FooterSection> FooterSections { get; set; }
        public DbSet<Entities.Declaration> Declarations { get; set; }
        public DbSet<Entities.Login> Logins { get; set; }
        public DbSet<Entities.Page> Pages { get; set; }




        private IConfiguration configuration;
        public DatabaseContext(IConfiguration _configuration) {
            configuration = _configuration;
        }
   

        private static bool MigrationCheckComplete = false;
        public void CheckMigrations() {
            if (MigrationCheckComplete) return;
            MigrationCheckComplete = true;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("MainConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Entities.FooterSection>(e => {
                e
                .HasMany(x => x.Links)
                .WithOne(x => x.Section);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
