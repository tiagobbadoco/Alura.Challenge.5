using Alura.Challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.Challenge.Infrastructure.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Titulo).IsRequired();

            builder.Property(x => x.Cor).IsRequired();

            builder.HasData(new { Id = 1L, Titulo = "Livre", Cor = "Verde" });
        }
    }
}