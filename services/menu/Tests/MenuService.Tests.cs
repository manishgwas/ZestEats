using Microsoft.VisualStudio.TestTools.UnitTesting;
using MenuService.Domain;
using MenuService.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MenuService.Tests
{
    [TestClass]
    public class MenuServiceTests
    {
        [TestMethod]
        public async Task AddMenu_ShouldAddMenu()
        {
            var repo = new MenuRepository();
            var menu = new Menu { Id = "1", RestaurantId = "r1", Name = "Test Menu" };
            await repo.AddMenuAsync(menu);
            var result = await repo.GetMenuAsync("1");
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Menu", result.Name);
        }
        // More unit, integration, and contract tests can be added here
    }
}
