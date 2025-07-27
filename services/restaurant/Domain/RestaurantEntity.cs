namespace Restaurant.Domain;

public class RestaurantEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Cuisine { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
