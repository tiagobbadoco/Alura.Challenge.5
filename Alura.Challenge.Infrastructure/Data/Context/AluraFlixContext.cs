using Alura.Challenge.Core.Entities;
using Alura.Challenge.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Alura.Challenge.Infrastructure.Data.Context
{
    public class AluraFlixContext : DbContext
    {
        public AluraFlixContext(DbContextOptions<AluraFlixContext> options) : base(options) { }

        #region "DbSets"
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyMappings();

            modelBuilder.ApplyGlobalConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}