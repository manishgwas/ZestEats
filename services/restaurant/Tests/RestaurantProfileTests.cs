using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Domain;

[TestClass]
public class RestaurantProfileTests
{
    [TestMethod]
    public void CanCreateRestaurantProfile()
    {
        var restaurant = new RestaurantEntity { Name = "Test", Address = "Addr", Cuisine = "Italian", IsActive = true };
        Assert.AreEqual("Test", restaurant.Name);
    }
}
