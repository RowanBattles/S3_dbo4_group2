using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MenuMastersDbContext : DbContext
    {
        public MenuMastersDbContext()
        {
        }

        public MenuMastersDbContext(DbContextOptions<MenuMastersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tab> Tabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=menumaster; User=sa; Password=Admin123; Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("account")
                .HasOne(e => e.Role)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();

            modelBuilder.Entity<Category>().ToTable("category");

            modelBuilder.Entity<MenuItem>().ToTable("menuitem")
                .HasOne(e => e.Category)
                .WithMany(e => e.MenuItems)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Order>().ToTable("order")
                .HasMany(e => e.MenuItems)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderItem>(j =>
                {
                    j.ToTable("orderitem");
                });

            //modelBuilder.Entity<OrderItem>().ToTable("orderitem")
            //    .HasOne(e => e.Order)
            //    .WithMany(e => e.OrderItems)
            //    .HasForeignKey(e => e.TabId)
            //    .IsRequired();

            modelBuilder.Entity<Role>().ToTable("role");

            modelBuilder.Entity<Tab>().ToTable("tab")
                .HasMany(e => e.Orders)
                .WithOne(e => e.Tab)
                .HasForeignKey(e => e.TabId)
                .IsRequired();
        }
    }
}

