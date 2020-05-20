using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Deliverable_29.Models
{
    public partial class MovieAPICreationDBContext : DbContext
    {
        public MovieAPICreationDBContext()
        {
        }

        public MovieAPICreationDBContext(DbContextOptions<MovieAPICreationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MoviesApi> MoviesApi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ANDREW-DESKTOP\\SQLEXPRESS;Database=MovieAPICreationDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<MoviesApi>(entity =>
            {
                entity.ToTable("MoviesAPI");

                entity.Property(e => e.Imdbrating)
                    .HasColumnName("IMDBRating")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MovieGenre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
