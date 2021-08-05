using System;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStore.DataAccess
{
    public partial class BookStoreContext : DbContext
    {
        internal readonly object GenresTable;

        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorsTable> AuthorsTables { get; set; }
        public virtual DbSet<BooksTable> BooksTables { get; set; }
        public virtual DbSet<GenresTable> GenresTables { get; set; }
        public virtual DbSet<OrderedBook> OrderedBooks { get; set; }
        public virtual DbSet<OrdersTable> OrdersTables { get; set; }
        public virtual DbSet<PublishersTable> PublishersTables { get; set; }
        public virtual DbSet<UsersTable> UsersTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\Mssqllocaldb;Database=BookStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuthorsTable>(entity =>
            {
                entity.ToTable("AuthorsTable");

                entity.Property(e => e.NameSurname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BooksTable>(entity =>
            {
                entity.ToTable("BooksTable");

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(250)
                    .HasColumnName("imgPath");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("smallmoney");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksTable_AuthorsTable");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksTable_GenresTable");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksTable_PublishersTable");
            });

            modelBuilder.Entity<GenresTable>(entity =>
            {
                entity.ToTable("GenresTable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OrderedBook>(entity =>
            {
                entity.ToTable("OrderedBook");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderedBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedBookId_BooksTable");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedBooks)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedBookId_OrdersTable");
            });

            modelBuilder.Entity<OrdersTable>(entity =>
            {
                entity.ToTable("OrdersTable");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrdersTables)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersTable_UsersTable");
            });

            modelBuilder.Entity<PublishersTable>(entity =>
            {
                entity.ToTable("PublishersTable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UsersTable>(entity =>
            {
                entity.ToTable("UsersTable");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.NameSurname).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
