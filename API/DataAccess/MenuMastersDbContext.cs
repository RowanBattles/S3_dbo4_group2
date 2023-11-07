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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tab> Tabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-BATTLES\\SQLEXPRESS05;Database=menumaster;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("roleid");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryid");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryname")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("menuitem");

                entity.Property(e => e.MenuItemId)
                    .HasColumnName("menuitemid");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(100);

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("itemdescription")
                    .HasMaxLength(400);

                entity.Property(e => e.ItemPrice)
                    .IsRequired()
                    .HasColumnName("itemprice");

                entity.Property(e => e.ItemStock)
                    .HasColumnName("itemstock");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("categoryid");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderid");

                entity.Property(e => e.TabId)
                    .IsRequired()
                    .HasColumnName("tabid");

                entity.Property(e => e.ItemCount)
                    .IsRequired()
                    .HasColumnName("itemcount");

                entity.HasMany(e => e.MenuItems)
                    .WithMany()
                    .UsingEntity<OrderItem>(j =>
                    {
                        j.ToTable("orderitem");

                        j.Property(e => e.OrderItemId)
                            .HasColumnName("orderitemid");

                        j.Property(e => e.OrderId)
                            .IsRequired()
                            .HasColumnName("orderid");

                        j.Property(e => e.MenuItemId)
                            .IsRequired()
                            .HasColumnName("itemid");
                    });
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleid");

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
                    .HasColumnName("tabid");

                entity.Property(e => e.TableNumber)
                    .IsRequired()
                    .HasColumnName("tablenumber");

                entity.Property(e => e.TabTotal)
                    .HasColumnName("tabtotal");
            });
        }
    }
}

