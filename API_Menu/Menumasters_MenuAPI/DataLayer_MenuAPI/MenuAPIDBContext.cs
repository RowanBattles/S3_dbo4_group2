using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security.Principal;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer_MenuAPI;
public class MenuAPIDBContext : DbContext
{
    public MenuAPIDBContext()
    {

    }
    public MenuAPIDBContext(DbContextOptions<MenuAPIDBContext> options)
            : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Tab> Tabs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; Database=menumaster; User=sa; Password=Nientendo2003; Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.CategoryId)
                .HasColumnName("category_id");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasColumnName("category_name")
                .HasMaxLength(255);

            entity.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.ToTable("menuitem");

            entity.Property(e => e.MenuItemId)
                .HasColumnName("menuitem_id");

            entity.Property(e => e.ItemName)
                .IsRequired()
                .HasColumnName("item_name")
                .HasMaxLength(255);

            entity.Property(e => e.ItemDescription)
                .HasColumnName("item_description")
                .HasMaxLength(512);

            entity.Property(e => e.ItemPrice)
                .IsRequired()
                .HasColumnName("item_price");

            entity.Property(e => e.ItemStock)
                .HasColumnName("item_stock");

            entity.Property(e => e.CategoryId)
                .IsRequired()
                .HasColumnName("category_id");

            entity.Property(e => e.ImageURL)
                .HasColumnName("image_url")
                .HasMaxLength(512);

            entity.Property(e => e.DietaryInfo)
                .HasColumnName("dietary_info")
                .HasMaxLength(255);

            entity.Property(e => e.Ingredients)
                .HasColumnName("ingredients")
                .HasMaxLength(512);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id");

            entity.Property(e => e.TabId)
                .IsRequired()
                .HasColumnName("tab_id");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status")
                .HasMaxLength(255);

            entity.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasMaxLength(512);

            entity.Property(e => e.DateTime)
                .IsRequired()
                .HasColumnName("datetime");

            entity.HasMany(e => e.OrderItems)
                .WithOne()
                .HasForeignKey(e => e.OrderId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("orderitem");

            entity.Property(e => e.OrderItemId)
                .HasColumnName("orderitem_id");

            entity.Property(e => e.OrderId)
                .IsRequired()
                .HasColumnName("order_id");

            entity.Property(e => e.MenuItemId)
                .IsRequired()
                .HasColumnName("item_id");

            entity.Property(e => e.Quantity)
                .IsRequired()
                .HasColumnName("quantity");

            entity.HasOne(e => e.MenuItem)
                .WithMany()
                .HasForeignKey(e => e.MenuItemId);
        });

        modelBuilder.Entity<Tab>(entity =>
        {
            entity.ToTable("tab");

            entity.Property(e => e.TabId)
                .HasColumnName("tab_id");

            entity.Property(e => e.TableNumber)
                .IsRequired()
                .HasColumnName("table_number");

            entity.Property(e => e.TabTotal)
                .HasColumnName("tab_total");
        });
    }
}

