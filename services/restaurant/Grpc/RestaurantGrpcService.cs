using Grpc.Core;
using Restaurant.Domain;
using System.Threading.Tasks;
using System.Linq;
using Restaurant.Persistence;
using Restaurant.Grpc;

namespace Restaurant.Grpc
{
    public class RestaurantGrpcService : RestaurantService.RestaurantServiceBase
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantGrpcService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public override Task<GetRestaurantResponse> GetRestaurant(GetRestaurantRequest request, ServerCallContext context)
        {
            var restaurant = _repository.GetById(request.Id);
            if (restaurant == null)
                return Task.FromResult(new GetRestaurantResponse());
            return Task.FromResult(new GetRestaurantResponse
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Address = restaurant.Address,
                Cuisine = restaurant.Cuisine,
                IsActive = restaurant.IsActive
            });
        }

        public override Task<ListRestaurantsResponse> ListRestaurants(ListRestaurantsRequest request, ServerCallContext context)
        {
            var restaurants = _repository.GetAll(request.Filter)
                .Select(r => new GetRestaurantResponse
                {
                    Id = r.Id,
                    Name = r.Name,
                    Address = r.Address,
                    Cuisine = r.Cuisine,
                    IsActive = r.IsActive
                }).ToList();
            var response = new ListRestaurantsResponse();
            response.Restaurants.AddRange(restaurants);
            return Task.FromResult(response);
        }

        public override Task<RegisterRestaurantResponse> RegisterRestaurant(RegisterRestaurantRequest request, ServerCallContext context)
        {
            var restaurant = new RestaurantEntity
            {
                Name = request.Name,
                Address = request.Address,
                Cuisine = request.Cuisine,
                IsActive = true
            };
            _repository.Add(restaurant);
            return Task.FromResult(new RegisterRestaurantResponse { Id = restaurant.Id });
        }
    }
}
