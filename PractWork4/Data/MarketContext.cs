using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PractWork4.Models;

namespace PractWork4.Data;

public partial class MarketContext : DbContext
{
    public MarketContext()
    {
    }

    public MarketContext(DbContextOptions<MarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source = prserver\\SQLEXPRESS;Initial Catalog = ispp1103;User ID = ispp1103;Password = 1103;TrustServerCertificate = true;");
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-O7C6TBI;Initial Catalog=ispp1103;Integrated Security=True;User ID=DESKTOP-O7C6TBI;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BC28CE3AD");

            entity.ToTable(tb => tb.HasTrigger("trSaveCategories"));

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer", tb => tb.HasTrigger("trSaveCustomer"));

            entity.HasIndex(e => e.Email, "UQ_CustomerEmail").IsUnique();

            entity.HasIndex(e => e.Login, "UQ_CustomerLogin").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Login)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Games__2AB897FDED198516");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trGamesRowCount");
                    tb.HasTrigger("trSaveGamePrice");
                });

            entity.HasIndex(e => e.CategoryId, "IX_Games_CategoryId");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImageFileName).HasMaxLength(255);
            entity.Property(e => e.KeysCount).HasDefaultValue((short)100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Games)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Categories");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.HasIndex(e => e.Title, "UQ_ManufacturerTitle").IsUnique();

            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .HasDefaultValue("Россия");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order", tb =>
                {
                    tb.HasTrigger("trDeleteOrderWithCustomer");
                    tb.HasTrigger("trOrderSetCurrentDate");
                });

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderedProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("OrderedProduct", tb => tb.HasTrigger("trAddOrderedProductsWithCheck"));

            entity.Property(e => e.Amount).HasDefaultValue((byte)1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedProduct_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedProduct_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", tb =>
                {
                    tb.HasTrigger("trAddLogs");
                    tb.HasTrigger("trDeleteProduct");
                });

            entity.HasIndex(e => new { e.Model, e.ManufacturerId }, "UQ_ProductModelManufacturerId").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.ProductionYear).HasDefaultValueSql("(datepart(year,getdate()))");
            entity.Property(e => e.Quantity).HasDefaultValue((byte)100);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasDefaultValue("смартфон");
            entity.Property(e => e.Weight).HasColumnType("decimal(4, 3)");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Manufacturer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
