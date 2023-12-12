using Bussines_MenuAPI;
using DateLayer_Bussiness_Contract;
using FakeItEasy;
using MenuAPI_Models;
using MenuAPI_Models.enums;

namespace ManuAPI_Test;

public class Tests
{
    private IMenuDAL _MenuDAL;
    private ICategoryDAL _CategroyDAL;

    [SetUp]
    public void Setup()
    {
        List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem()
            {
                MenuItemId = 1,
                CategoryId = 1,
                Category = new Category
                {
                    CategoryId=1,
                    CategoryName = "Test",
                    Type = OrderType.Bar,
                },
                DietaryInfo = "bacon",
                ImageURL = "bacon/bacon",
                Ingredients = "bacon",
                ItemDescription_Long= "not to short",
                ItemDescription_Short = "not to long",
                ItemName = "bacon",
                ItemPrice = 1,
                ItemStock = 100
            },
            new MenuItem()
            {
                MenuItemId = 2,
                CategoryId = 2,
                Category = new Category
                {
                    CategoryId=2,
                    CategoryName = "Test",
                    Type = OrderType.Kitchen,
                },
                DietaryInfo = "cola",
                ImageURL = "cola/cola",
                Ingredients = "cola",
                ItemDescription_Long= "not to short",
                ItemDescription_Short = "not to long",
                ItemName = "cola",
                ItemPrice = 1,
                ItemStock = 100
            },
        };
        _MenuDAL = A.Fake<IMenuDAL>();
        A.CallTo(() => _MenuDAL.GetAllMenuItemsAsync()).Returns(menuItems);

        List<Category> categories = new List<Category>()
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "burber",
                Type = OrderType.Bar
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "beers",
                Type = OrderType.Kitchen
            }
        };

        _CategroyDAL = A.Fake<ICategoryDAL>();
        A.CallTo(() => _CategroyDAL.GetAllCategoriesAsync()).Returns(categories);
    }

    [Test]
    public async Task GetAllMenuItemsAsync_GettingAllMenuitemsFromMock_ReturnsAllMenuitemsFromMock()
    {
        //arrange - variables, classes, mocks
        List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem()
            {
                MenuItemId = 1,
                CategoryId = 1,
                Category = new Category
                {
                    CategoryId=1,
                    CategoryName = "Test",
                    Type = OrderType.Bar,
                },
                DietaryInfo = "bacon",
                ImageURL = "bacon/bacon",
                Ingredients = "bacon",
                ItemDescription_Long= "not to short",
                ItemDescription_Short = "not to long",
                ItemName = "bacon",
                ItemPrice = 1,
                ItemStock = 100
            },
            new MenuItem()
            {
                MenuItemId = 2,
                CategoryId = 2,
                Category = new Category
                {
                    CategoryId=2,
                    CategoryName = "Test",
                    Type = OrderType.Kitchen,
                },
                DietaryInfo = "cola",
                ImageURL = "cola/cola",
                Ingredients = "cola",
                ItemDescription_Long= "not to short",
                ItemDescription_Short = "not to long",
                ItemName = "cola",
                ItemPrice = 1,
                ItemStock = 100
            },
        };
        var component = new MenuComponent(_MenuDAL);
        //act
        var result = await component.GetAllMenuItemsAsync();


        //assert
        Assert.NotNull(result);
        Assert.AreEqual(menuItems.Count(), result.Count());
        foreach (var item in result)
        {
            MenuItem menuItem = menuItems.Find(m => m.MenuItemId == item.MenuItemId);
            if (menuItem == item)
            {
                Assert.Pass();
            }
        }
    }
    [Test]
    public async Task GetAllCategoriesAsync_GetsAlltheCategoriesInTheMock_ReturnsAlltheCategoriesInTheMock()
    {
        //arrange - variables, classes, mocks

        List<Category> categories = new List<Category>()
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "burber",
                Type = OrderType.Bar
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "beers",
                Type = OrderType.Kitchen
            }
        };
        var component = new CategoryComponent(_CategroyDAL);
        //act

        var result = await component.GetAllCategoriesAsync();

        //assert
        Assert.NotNull(result);
        Assert.AreEqual(categories.Count(), result.Count());
        foreach (var item in result)
        {
            Category category = categories.Find(c => c.CategoryId == item.CategoryId );
            if (item == category)
            {
                Assert.Pass();
            }
        }
    }
    public void Template()
    {
        //arrange - variables, classes, mocks
        //act
        //assert
        Assert.Pass();
    }
}