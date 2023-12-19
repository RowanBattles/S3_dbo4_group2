﻿using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MenuMasters_API_Unit_Tests.Repositories
{
	public class TabRepository_Tests
	{
        private readonly DbContextOptions<MenuMastersDbContext> _options;

        public TabRepository_Tests()
        {
            _options = new DbContextOptionsBuilder<MenuMastersDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase_{new Random().Next(0, 100)}")
                .Options;
        }

        [Fact]
		public async Task GetAllTabsAsync_Test()
		{
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 10, PaidCash = 5, PaidPIN = 5 });
                dbContext.Tabs.Add(new Tab { TableNumber = 11, TabTotal = 15, PaidCash = 0, PaidPIN = -3 });
                dbContext.SaveChanges();

                // Act
                IEnumerable<Tab> result = await tabRepository.GetAllTabsAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
                Assert.Contains(result, x => x.TableNumber == 12 && x.TabTotal == 0 && x.MoneyRemaining == -10 && x.Paid);
                Assert.Contains(result, x => x.TableNumber == 11 && x.TabTotal == 0 && x.MoneyRemaining == 3 && !x.Paid);
            }
        }

        [Fact]
        public async Task GetTabByIdAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 0, PaidCash = 0, PaidPIN = -10 });
                dbContext.SaveChanges();

                // Act
                Tab? result = await tabRepository.GetTabByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(12, result.TableNumber);
                Assert.Equal(0, result.TabTotal);
                Assert.Equal(10, result.MoneyRemaining);
                Assert.False(result.Paid);
            }
        }

        [Fact]
        public async Task GetOpenTabWithTableNumberAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 0, PaidCash = 5, PaidPIN = 5 });
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 0, PaidCash = -7, PaidPIN = -3 });
                dbContext.SaveChanges();

                // Act
                Tab? result = await tabRepository.GetOpenTabWithTableNumberAsync(12);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(12, result.TableNumber);
                Assert.Equal(0, result.TabTotal);
                Assert.Equal(10, result.MoneyRemaining);
                Assert.False(result.Paid);
            }
        }

        [Fact]
        public async Task CreateTabAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                Tab newTab = new Tab { TableNumber = 12, TabTotal = 0, PaidCash = 0, PaidPIN = 0 };

                // Act
                Tab? result = await tabRepository.CreateTabAsync(newTab);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(12, result.TableNumber);
                Assert.Equal(0, result.TabTotal);
                Assert.Equal(0, result.MoneyRemaining);
                Assert.True(result.Paid);
            }
        }

        [Fact]
        public async Task UpdateTabAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 0, PaidCash = 0, PaidPIN = 0 });
                dbContext.SaveChanges();
                Tab updated = new Tab { TabId = 1, TableNumber = 10, TabTotal = 0, PaidCash = -10, PaidPIN = -5 };

                // Act
                Tab? result = await tabRepository.UpdateTabAsync(updated);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(10, result.TableNumber);
                Assert.Equal(0, result.TabTotal);
                Assert.Equal(15, result.MoneyRemaining);
                Assert.False(result.Paid);
            }
        }

        [Fact]
        public async Task DeleteTabAsync_Test()
        {
            using (MenuMastersDbContext dbContext = new MenuMastersDbContext(_options))
            {
                // Arrange
                TabRepository tabRepository = new TabRepository(dbContext);
                dbContext.Tabs.Add(new Tab { TableNumber = 12, TabTotal = 0, PaidCash = 0, PaidPIN = 0});
                dbContext.SaveChanges();

                // Act
                bool result = await tabRepository.DeleteTabAsync(1);

                // Assert
                Assert.True(result);
            }
        }
    }
}

