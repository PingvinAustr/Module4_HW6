using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Models;

namespace Module4_HW6.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs")
                .HasKey(x => x.SongId);

            builder.Property(x => x.SongId)
                .HasColumnName("SongId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.SongTitle)
               .HasColumnName("SongTitle")
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.SongDuration)
               .HasColumnName("SongDuration")
               .IsRequired();

            builder.Property(x => x.ReleaseDate)
               .HasColumnName("ReleaseDate")
               .IsRequired();

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Songs)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
