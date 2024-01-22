using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;

namespace MenuMasters_API_Unit_Tests.Repositories
{
	public class OrderRepository_Tests
	{
        private readonly DbContextOptions<MenuMastersDbContext> _options;

        public OrderRepository_Tests()
        {
            _options = new DbContextOptionsBuilder<MenuMastersDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase_{new Random().Next(int.MinValue, int.MaxValue)}")
                .Options;
        }

        [Fact]
		public async Task GetAllOrdersAsync_Test()
		{
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.Orders.Add(
                    new Order {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.Orders.Add(
                    new Order
                    {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Cola",
                                    ItemPrice = 1.00m,
                                    ItemDescription_Long = "A refreshing drink",
                                    ItemDescription_Short = "A refreshing drink",
                                    ItemStock = 10
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.SaveChanges();

                // Act
                IEnumerable<Order> result = await orderRepository.GetAllOrdersAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
                Assert.NotEmpty(result.ElementAt(0).OrderItems);
                Assert.NotEmpty(result.ElementAt(1).OrderItems);
                Assert.Contains(result, x => x.OrderItems.Any(x => x.MenuItem.ItemName == "Cola"));
                Assert.Contains(result, x => x.OrderItems.Any(x => x.MenuItem.ItemName == "Burger"));
            }
        }

        [Fact]
        public async Task GetAllOrdersByTypeAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.Orders.Add(
                    new Order
                    {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20,
                                    Category = new Category
                                    {
                                        CategoryName = "Burgers",
                                        Type = OrderType.Kitchen
                                    }
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.SaveChanges();

                // Act
                IEnumerable<Order> result = await orderRepository.GetAllOrdersByTypeAsync(OrderType.Bar);

                // Assert
                Assert.NotNull(result);
                Assert.Empty(result.First().OrderItems);
            }
        }

        [Fact]
        public async Task GetOrderByIdAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.Orders.Add(
                    new Order
                    {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.SaveChanges();

                // Act
                Order? result = await orderRepository.GetOrderByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result.OrderItems);
                Assert.Equal("Burger", result.OrderItems.First().MenuItem.ItemName);
            }
        }

        [Fact]
        public async Task CreateOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                Order newOrder = new Order
                {
                    OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                    StatusKitchen = OrderStatus.Pending,
                    StatusBar = OrderStatus.Pending,
                    DateTime = DateTime.Now
                };

                // Act
                Order? result = await orderRepository.CreateOrderAsync(newOrder);

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result.OrderItems);
                Assert.Equal("Burger", result.OrderItems.First().MenuItem.ItemName);
            }
        }

        [Fact]
        public async Task AddItemToOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                OrderItem newOrderItem = new OrderItem
                {
                    MenuItem = new MenuItem
                    {
                        ItemName = "Burger",
                        ItemPrice = 3.50m,
                        ItemDescription_Long = "A classic burger",
                        ItemDescription_Short = "A classic burger",
                        ItemStock = 20
                    },
                    Notes = "Extra cheese",
                    Quantity = 1
                };

                // Act
                OrderItem? result = await orderRepository.AddItemToOrderAsync(newOrderItem);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Burger", result.MenuItem.ItemName);
                Assert.Equal("Extra cheese", result.Notes);
                Assert.Equal(1, result.Quantity);
            }
        }

        [Fact]
        public async Task UpdateOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.Orders.Add(
                    new Order
                    {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.SaveChanges();
                Order updated = new Order
                {
                    OrderId = 1,
                    OrderItems = new List<OrderItem>(),
                    StatusKitchen = OrderStatus.Completed,
                    StatusBar = OrderStatus.Active,
                    DateTime = DateTime.Now
                };

                // Act
                Order? result = await orderRepository.UpdateOrderAsync(updated);

                // Assert
                Assert.NotNull(result);
                Assert.Empty(result.OrderItems);
                Assert.Equal(OrderStatus.Completed, result.StatusKitchen);
                Assert.Equal(OrderStatus.Active, result.StatusBar);
            }
        }

        [Fact]
        public async Task UpdateItemFromOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.OrderItems.Add(
                    new OrderItem
                    {
                        MenuItem = new MenuItem
                        {
                            ItemName = "Burger",
                            ItemPrice = 3.50m,
                            ItemDescription_Long = "A classic burger",
                            ItemDescription_Short = "A classic burger",
                            ItemStock = 20
                        },
                        Notes = "Extra cheese",
                        Quantity = 1
                    }
                );
                dbContext.SaveChanges();

                // Act
                OrderItem? result = await orderRepository.UpdateItemFromOrderAsync(1, 3);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Quantity);
            }
        }

        [Fact]
        public async Task DeleteOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.Orders.Add(
                    new Order
                    {
                        OrderItems = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                MenuItem = new MenuItem
                                {
                                    ItemName = "Burger",
                                    ItemPrice = 3.50m,
                                    ItemDescription_Long = "A classic burger",
                                    ItemDescription_Short = "A classic burger",
                                    ItemStock = 20
                                },
                                Notes = "Extra cheese",
                                Quantity = 1
                            }
                        },
                        StatusKitchen = OrderStatus.Pending,
                        StatusBar = OrderStatus.Pending,
                        DateTime = DateTime.Now
                    }
                );
                dbContext.SaveChanges();

                // Act
                bool result = await orderRepository.DeleteOrderAsync(1);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public async Task RemoveItemFromOrderAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                OrderRepository orderRepository = new OrderRepository(dbContext);
                dbContext.OrderItems.Add(
                    new OrderItem
                    {
                        MenuItem = new MenuItem
                        {
                            ItemName = "Burger",
                            ItemPrice = 3.50m,
                            ItemDescription_Long = "A classic burger",
                            ItemDescription_Short = "A classic burger",
                            ItemStock = 20
                        },
                        Notes = "Extra cheese",
                        Quantity = 1
                    }
                );
                dbContext.SaveChanges();

                // Act
                bool result = await orderRepository.RemoveItemFromOrderAsync(1);

                // Assert
                Assert.True(result);
            }
        }
    }
}

