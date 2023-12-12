using Bussiness.Components;
using Contract_Data_Bussiness.Interfaces;
using Moq;

namespace MenuMasters_API_Unit_Tests.Components
{
	public class CategoryComponent_Tests
	{
        private readonly CategoryComponent _categoryComponent;

        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public CategoryComponent_Tests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _categoryComponent = new CategoryComponent(
                _categoryRepositoryMock.Object
            );
        }

		[Fact]
		public async Task GetAllCategoriesAsync_Test()
		{

		}

        [Fact]
        public async Task GetCategoryByIdAsync_Test()
        {

        }

        [Fact]
        public async Task CreateCategoryAsync_Test()
        {

        }

        [Fact]
        public async Task UpdateCategoryAsync_Test()
        {

        }

        [Fact]
        public async Task DeleteCategoryAsync_Test()
        {

        }
    }
}

