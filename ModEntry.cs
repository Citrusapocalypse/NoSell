using System;
using System.Threading;
using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace NoSell

{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {

            var harmony = new Harmony(ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(StardewValley.Object), "sellToStorePrice"),
                postfix: new HarmonyMethod(typeof(ModEntry), nameof(SellToStorePrice_Postfix))
            );

            harmony.PatchAll();
        }




        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        public static void SellToStorePrice_Postfix(ref int __result)

        {
                __result = 0;
        }
    }
}
