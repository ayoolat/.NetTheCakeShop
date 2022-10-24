using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace theCakeShop.DataLayer.Database;

public partial class CakeShopDatabaseContext : DbContext
{
    public CakeShopDatabaseContext()
    {
    }

    public CakeShopDatabaseContext(DbContextOptions<CakeShopDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cake> Cakes { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=theCakeShop;Port=5000;User Id=postgres;Password=toluwanimi");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cake>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cakes_pkey");

            entity.ToTable("cakes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_pkey");

            entity.ToTable("cart");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CakeId).HasColumnName("cake_id");
            entity.Property(e => e.Delivered).HasColumnName("delivered");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cakes_orders_fk");

            entity.HasOne(d => d.Id1).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_orders_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
