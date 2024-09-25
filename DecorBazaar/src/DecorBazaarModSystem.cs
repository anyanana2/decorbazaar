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
            loadConfig();            
            
            api.RegisterBlockEntityClass("DecorBazaarStove", typeof(BlockEntityDecorStove));
        }

        public void loadConfig()
        {
            try
            {
                DecorBazaarConfig DecorBazaarConfig = api.LoadModConfig<DecorBazaarConfig>("DecorBazaar.json");
                if (DecorBazaarConfig != null)
                {
                    api.Logger.Notification("Mod Config successfully loaded.");
                    DecorBazaarConfig.Current = DecorBazaarConfig;
                }
                else
                {
                    api.Logger.Notification("No Mod Config specified. Falling back to default settings");
                    DecorBazaarConfig.Current = DecorBazaarConfig.GetDefault();
                }
            }
            catch
            {
                DecorBazaarConfig.Current = DecorBazaarConfig.GetDefault();
                api.Logger.Error("Failed to load custom mod configuration. Falling back to default settings!");
            }
            finally
            {
                api.StoreModConfig<DecorBazaarConfig>(DecorBazaarConfig.Current, "DecorBazaar.json");
            }
            setConfig();
        }
        public void setConfig()
        {
            api.World.Config.SetFloat("vegstorageVegetableDecay", DecorBazaarConfig.Current.vegstorageVegetableDecay);
            api.World.Config.SetFloat("vegstorageGrainDecay", DecorBazaarConfig.Current.vegstorageGrainDecay);
            api.World.Config.SetFloat("breadboxVegetableDecay", DecorBazaarConfig.Current.breadboxVegetableDecay);
            api.World.Config.SetFloat("breadboxGrainDecay", DecorBazaarConfig.Current.breadboxGrainDecay);
            api.World.Config.SetFloat("mushroomstorageVegetableDecay", DecorBazaarConfig.Current.mushroomstorageVegetableDecay);
            api.World.Config.SetFloat("mushroomstorageGrainDecay", DecorBazaarConfig.Current.mushroomstorageGrainDecay);
            api.World.Config.SetFloat("meatstorageProteinDecay", DecorBazaarConfig.Current.meatstorageProteinDecay);
            api.World.Config.SetFloat("compostbinVegetableDecay", DecorBazaarConfig.Current.compostbinVegetableDecay);
            api.World.Config.SetFloat("compostbinGrainDecay", DecorBazaarConfig.Current.compostbinGrainDecay);
        }
    }
}
