using Grpc.Core;
using CartService.Domain;
using CartService.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CartService.Grpc
{
    public class CartGrpcService : CartProto.CartProtoBase
    {
        private readonly ICartRepository _repo;
        public CartGrpcService(ICartRepository repo)
        {
            _repo = repo;
        }
        // Implement gRPC methods here (AddOrUpdateCart, GetCart, ListCarts, etc.)
    }
}
