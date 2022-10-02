namespace FitnessWebApi.Data
{
    using FitnessWebApi.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class FitnessWebApiDbContext : DbContext
    {
        public FitnessWebApiDbContext()
        {
        }

        public FitnessWebApiDbContext(DbContextOptions<FitnessWebApiDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<BodyPart> BodyParts { get; set; }

        public DbSet<TargetMuscle> TargetMuscles { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                JsonAppSettings appSettings = JsonConvert.DeserializeObject<JsonAppSettings>(File.ReadAllText(@"appsettings.json"));
    
                optionsBuilder.UseSqlServer(appSettings.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyPart>()
                .HasMany(b => b.Exercises)
                .WithOne(e => e.BodyPart)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<TargetMuscle>()
                .HasMany(t => t.Exercises)
                .WithOne(e => e.TargetMuscle)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Exercises)
                .WithOne(e => e.Equipment)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
