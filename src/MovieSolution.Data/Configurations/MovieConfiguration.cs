using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSolution.Core.Entities;

namespace MovieSolution.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(255);
        builder.Property(m => m.Desc)
               .IsRequired()
               .HasMaxLength(255);
        builder.Property(m => m.SalePrice)
               .IsRequired();
        builder.Property(m => m.CostPrice)
               .IsRequired();

        builder.HasOne(m => m.Genre)
               .WithMany(m => m.Movies)
               .HasForeignKey(m => m.GenreId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
