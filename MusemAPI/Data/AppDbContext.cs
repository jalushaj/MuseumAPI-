﻿using Microsoft.EntityFrameworkCore;
using MuseumAPI.Data.Models;
using Projekti.Models;
using ShoppingCartAPI.Models;


namespace MuseumAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketDetail>()
       .Property(t => t.Price)
       .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<ArtistModel>()
         .HasMany(a => a.Paintings) // Artist has many Paintings
         .WithOne(p => p.Artist) // Each Painting has one Artist
         .HasForeignKey(p => p.ArtistId) // Foreign key in Painting table
         .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<workModel>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(w => w.Artist)
                    .HasMaxLength(100);

                entity.Property(w => w.Category)
                    .HasMaxLength(50);

                entity.Property(w => w.CreationDateText)
                    .HasMaxLength(50);

                entity.Property(w => w.Era)
                    .HasMaxLength(50);
            });
        }

        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<PaintingsModel> Paintings { get; set; }
        public DbSet<GiftsModel> Gifts { get; set; }
        public DbSet<TicketsModel>Tickets { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<workModel> Work { get; set; }






    }
}
