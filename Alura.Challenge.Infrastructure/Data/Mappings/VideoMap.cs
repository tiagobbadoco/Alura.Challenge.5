using Alura.Challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.Challenge.Infrastructure.Data.Mappings
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Titulo).IsRequired();

            builder.Property(x => x.Descricao).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}