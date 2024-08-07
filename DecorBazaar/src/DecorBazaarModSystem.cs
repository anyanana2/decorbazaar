using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace DecorBazaar
{
    public class DecorBazaarModSystem : ModSystem
    {

        public override void Start(ICoreAPI api)
        {
            api.RegisterBlockEntityClass("DecorBazaarStove", typeof(BlockEntityDecorStove));
        }

    }
}
