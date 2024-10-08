using Newtonsoft.Json.Linq;
using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.Common;
using Vintagestory.ServerMods.NoObf;
using Vintagestory.API.Datastructures;

namespace DecorBazaar
{
    public class DecorBazaarModSystem : ModSystem
    {
        ICoreAPI api;
        public override void Start(ICoreAPI api)
        {
            this.api = api;
            DecorBazaarConfig.loadConfig(api);
            
            api.RegisterBlockEntityClass("DecorBazaarStove", typeof(BlockEntityDecorStove));
        }

        
    }
}
