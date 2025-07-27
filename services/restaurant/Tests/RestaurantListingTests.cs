using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Persistence;

[TestClass]
public class RestaurantListingTests
{
    [TestMethod]
    public void CanListRestaurants()
    {
        var repo = new RestaurantRepository();
        repo.Add(new Restaurant.Domain.RestaurantEntity { Name = "Test", Address = "Addr", Cuisine = "Italian", IsActive = true });
        var list = repo.GetAll(null);
        Assert.AreEqual(1, list.Count());
    }
}
