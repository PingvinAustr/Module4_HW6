using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Models;

namespace Module4_HW6.Configurations
{
    public class ArtistsSongsConfiguration : IEntityTypeConfiguration<ArtistsSongs>
    {
        public void Configure(EntityTypeBuilder<ArtistsSongs> builder)
        {
            builder.ToTable("ArtistsSongs")
               .HasKey(x => x.ArtistsSongsId);

            builder.Property(x => x.ArtistsSongsId)
                .HasColumnName("ArtistsSongsId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.ArtistId)
                .HasColumnName("ArtistId")
                .IsRequired();

            builder.Property(x => x.SongId)
                .HasColumnName("SongId")
                .IsRequired();

            builder
               .HasOne(ep => ep.Artist)
               .WithMany(e => e.ArtistsSongs)
               .HasForeignKey(ep => ep.ArtistId);

            builder
                .HasOne(ep => ep.Song)
                .WithMany(p => p.ArtistsSongs)
                .HasForeignKey(ep => ep.SongId);
        }
    }
}
