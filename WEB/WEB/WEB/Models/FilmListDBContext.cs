using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEB.Models
{
    public partial class FilmListDBContext : DbContext
    {
        public FilmListDBContext()
        {
        }

        public FilmListDBContext(DbContextOptions<FilmListDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN-5GES44ELL84\\MSSQLDEVSERVER;Database=FilmListDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Comments_Films");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SubscriberId)
                    .HasConstraintName("FK_Comments_Subscribers");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.FilmId)
                    .ValueGeneratedNever()
                    .HasColumnName("FilmID");

                entity.Property(e => e.FilmName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReviewID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Reviews_Films");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.SubscriberId)
                    .HasConstraintName("FK_Reviews_Subscribers");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.SubscriberId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubscriberID");

                entity.Property(e => e.SubscriberNick)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
