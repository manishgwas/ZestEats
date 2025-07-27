using Restaurant.Domain;
using System.Collections.Concurrent;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly ConcurrentDictionary<int, RestaurantEntity> _restaurants = new();
    private int _idCounter = 1;

    public void Add(RestaurantEntity restaurant)
    {
        restaurant.Id = _idCounter++;
        _restaurants[restaurant.Id] = restaurant;
    }

    public IEnumerable<RestaurantEntity> GetAll(string? filter)
    {
        var query = _restaurants.Values.AsEnumerable();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(r => r.Name.Contains(filter) || r.Cuisine.Contains(filter));
        return query;
    }

    public RestaurantEntity? GetById(int id)
    {
        _restaurants.TryGetValue(id, out var restaurant);
        return restaurant;
    }
}
