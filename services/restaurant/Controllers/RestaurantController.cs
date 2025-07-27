using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantRepository _repository;

    public RestaurantController(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Register(RestaurantEntity restaurant)
    {
        _repository.Add(restaurant);
        return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string? filter)
    {
        var restaurants = _repository.GetAll(filter);
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var restaurant = _repository.GetById(id);
        if (restaurant == null) return NotFound();
        return Ok(restaurant);
    }
}
