using Microsoft.EntityFrameworkCore;

namespace Rubiconmp_RectangleTask.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Rectangle> Rectangles { get; set; }
    }
}
