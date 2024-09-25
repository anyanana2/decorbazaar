using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.GameContent;
using Vintagestory.ServerMods.NoObf;

namespace DecorBazaar
{
    internal class DecorBazaarConfig
    {
        public static DecorBazaarConfig Current { get; set; }

        public float vegstorageVegetableDecay = 0.5f;
        public float vegstorageGrainDecay = 0.75f;
        public float breadboxVegetableDecay = 0.75f;
        public float breadboxGrainDecay = 0.5f;
        public float mushroomstorageVegetableDecay = 0.5f;
        public float mushroomstorageGrainDecay = 0.5f;
        public float meatstorageProteinDecay = 0.5f;
        public float compostbinVegetableDecay = 2.0f;
        public float compostbinGrainDecay = 2.0f;

        public static DecorBazaarConfig GetDefault()
        {
            DecorBazaarConfig config =  new DecorBazaarConfig();
            config.vegstorageVegetableDecay.ToString();
            config.vegstorageGrainDecay.ToString();
            config.breadboxVegetableDecay.ToString();
            config.breadboxGrainDecay.ToString();
            config.mushroomstorageVegetableDecay.ToString();
            config.mushroomstorageGrainDecay.ToString();
            config.meatstorageProteinDecay.ToString();
            config.compostbinVegetableDecay.ToString();
            config.compostbinGrainDecay.ToString();
            return config;
        }
    }
}
