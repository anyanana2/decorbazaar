using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.GameContent;
using Vintagestory.ServerMods.NoObf;
using Vintagestory.API.Common;

namespace DecorBazaar
{
    internal class DecorBazaarConfig
    {

        public DecorBazaarConfig() { }
        public DecorBazaarConfig(Dictionary<string, dynamic> config)
        {
            foreach (var key in config.Keys)
            {
                this.configurables[key] = config[key];
            }
        }

        public Dictionary<string, dynamic> configurables = new Dictionary<string, dynamic> {
            {"vegstorageVegetableDecay", 0.5f},
            {"vegstorageGrainDecay", 0.75f},
            {"breadboxVegetableDecay", 0.75f},
            {"breadboxGrainDecay", 0.5f},
            {"mushroomstorageVegetableDecay", 0.5f},
            {"mushroomstorageGrainDecay", 0.5f},
            {"meatstorageProteinDecay", 0.5f},
            {"compostbinVegetableDecay", 2.0f},
            {"compostbinGrainDecay", 2.0f}
        };

        public static DecorBazaarConfig GetDefault()
        {
            
            DecorBazaarConfig config =  new DecorBazaarConfig();
            return config;
        }

        public static void loadConfig(ICoreAPI api)
        {
            DecorBazaarConfig DecorBazaarConfig = null;
            try
            {
                DecorBazaarConfig = new DecorBazaarConfig(api.LoadModConfig<Dictionary<string, dynamic>>("DecorBazaar.json"));
                if (DecorBazaarConfig != null)
                {
                    api.Logger.Notification("Mod Config successfully loaded.");
                }
                else
                {
                    api.Logger.Notification("No Mod Config specified. Falling back to default settings");
                    DecorBazaarConfig = DecorBazaarConfig.GetDefault();
                }
            }
            catch
            {
                DecorBazaarConfig = DecorBazaarConfig.GetDefault();
                api.Logger.Error("Failed to load custom mod configuration. Falling back to default settings!");
            }
            finally
            {
                api.StoreModConfig<Dictionary<string, dynamic>>(DecorBazaarConfig.configurables, "DecorBazaar.json");
            }
            setConfig(api, DecorBazaarConfig);
        }
        public static void setConfig(ICoreAPI api, DecorBazaarConfig DecorBazaarConfig)
        {
            foreach (var config in DecorBazaarConfig.configurables)
            {
                switch (config.Value)
                {
                    case int v:
                        api.World.Config.SetInt(config.Key, v);
                        break;
                    case double v:
                        api.World.Config.SetDouble(config.Key, v);
                        break;
                    case float v:
                        api.World.Config.SetFloat(config.Key, v);
                        break;
                    case string v:
                        api.World.Config.SetString(config.Key, v);
                        break;
                    case bool v:
                        api.World.Config.SetBool(config.Key, v);
                        break;
                    default:
                        throw new NotImplementedException("Type of config value is not handled");
                }
            }
        }
    }
}
