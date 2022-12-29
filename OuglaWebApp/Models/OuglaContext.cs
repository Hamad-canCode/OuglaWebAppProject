using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OuglaWebApp.Models;

public partial class OuglaContext : DbContext
{

    public OuglaContext(DbContextOptions<OuglaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<Record> Records { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.Sitename).HasName("PK__info__4331A98824DEB4E3");

            entity.ToTable("info");

            entity.Property(e => e.Sitename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sitename");
            entity.Property(e => e.Ownername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ownername");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Filepath).HasName("PK__records__DFE356BF5D06DAFA");

            entity.ToTable("records");

            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("filepath");
            entity.Property(e => e.Sitename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sitename");

            entity.HasOne(d => d.SitenameNavigation).WithMany(p => p.Records)
                .HasForeignKey(d => d.Sitename)
                .HasConstraintName("FK__records__sitenam__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
