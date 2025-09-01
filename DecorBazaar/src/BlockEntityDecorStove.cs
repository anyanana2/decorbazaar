using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace DecorBazaar
{
    public class BlockEntityDecorStove : BlockEntityFirepit
    {
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);

            //After base is initialized, lets immediately remove the custom renderer.
            //Gonna have to use reflection for this - It's not pretty.
            if (api is ICoreClientAPI)
            {
                //Get the private "renderer" field from 'this' object.
                Traverse field = Traverse.Create(this).Field("renderer");

                //Unregister the renderer that was just registered.
                (api as ICoreClientAPI).Event.UnregisterRenderer(field.GetValue<FirepitContentsRenderer>() as FirepitContentsRenderer, EnumRenderStage.Opaque);

                //Renderers need to be disposed to avoid memory leaks.
                (field.GetValue<FirepitContentsRenderer>())?.Dispose();

                //And set the private renderer field to null to prevent anything from using it further. 
                field.SetValue(null);
            }
        }

        public override bool OnTesselation(ITerrainMeshPool mesher, ITesselatorAPI tesselator)
        {
            return false;
        }
    }
}
