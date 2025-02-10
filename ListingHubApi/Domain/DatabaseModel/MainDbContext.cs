using DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingDescription> ListingDescriptions { get; set; }
        public DbSet<ListingField> ListingFields { get; set; }
        public DbSet<ListingPhoto> ListingPhotos { get; set; }
        public DbSet<SubNeighbourhood> SubNeighbourhoods { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.HasDefaultSchema("ListingHub");
        }
    }
}
