using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FastfoodCenter.Entities.Models;

namespace FastfoodCenter.Data
{
    public partial class FastfoodCenterContext : DbContext
    {
        public FastfoodCenterContext()
        {
        }

        public FastfoodCenterContext(DbContextOptions<FastfoodCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantFoods> RestaurantFoods { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:xambootcamp.database.windows.net,1433;Initial Catalog=FastfoodCenter;Persist Security Info=False;User ID=xambootcamp;Password=10isIlleg@l;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("imageUrl")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("imageUrl")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RateStars).HasColumnName("rateStars");

                entity.Property(e => e.Ratings).HasColumnName("ratings");
            });

            modelBuilder.Entity<RestaurantFoods>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FoodId).HasColumnName("foodId");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantId");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.RestaurantFoods)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantFoods_Food");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantFoods)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantFoods_Restaurant");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(25)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
