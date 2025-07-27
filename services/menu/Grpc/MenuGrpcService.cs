using Grpc.Core;
using MenuService.Domain;
using MenuService.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MenuService.Grpc
{
    public class MenuGrpcService : MenuProto.MenuProtoBase
    {
        private readonly IMenuRepository _repo;
        public MenuGrpcService(IMenuRepository repo)
        {
            _repo = repo;
        }
        // Implement gRPC methods here (AddMenu, GetMenu, ListMenus, etc.)
    }
}
