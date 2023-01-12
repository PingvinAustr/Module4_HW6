using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Models;

namespace Module4_HW6.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists")
                .HasKey(x => x.ArtistId);

            builder.Property(x => x.ArtistId)
                .HasColumnName("ArtistId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.ArtistName)
               .HasColumnName("ArtistName")
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(x => x.DateOfBirth)
               .HasColumnName("DateOfBirth")
               .IsRequired();

            builder.Property(x => x.Phone)
               .HasColumnName("Phone");

            builder.Property(x => x.Email)
               .HasColumnName("Email");

            builder.Property(x => x.InstagramUrl)
                .HasColumnName("InstagramUrl");
        }
    }
}
