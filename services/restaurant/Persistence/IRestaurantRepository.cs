using Restaurant.Domain;

public interface IRestaurantRepository
{
    void Add(RestaurantEntity restaurant);
    IEnumerable<RestaurantEntity> GetAll(string? filter);
    RestaurantEntity? GetById(int id);
    // Add update, delete as needed
}
