using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Models;

namespace Module4_HW6.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres")
                .HasKey(x => x.GenreId);

            builder.Property(x => x.GenreId)
                .HasColumnName("GenreId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.GenreName)
               .HasColumnName("GenreName")
               .HasMaxLength(150)
               .IsRequired();
        }
    }
}
