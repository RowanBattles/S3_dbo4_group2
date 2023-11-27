using Models;
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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tab> Tabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PC-Bas; Database=menumasters; Trusted_Connection=True; Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id");
            });

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

                entity.Property(e => e.ItemDescription_Short)
                    .HasColumnName("item_description_short")
                    .HasMaxLength(255);

                entity.Property(e => e.ItemDescription_Long)
                    .HasColumnName("item_description_long")
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

                entity.HasOne(e => e.MenuItem)
                    .WithMany()
                    .HasForeignKey(e => e.MenuItemId);

                entity.Property(e => e.Quantity)
                    .IsRequired()
                    .HasColumnName("quantity");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes");

                
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(400);
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
}

