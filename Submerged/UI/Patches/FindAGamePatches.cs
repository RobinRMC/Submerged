using System.Linq;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using InnerNet;
using Submerged.Resources;
using UnityEngine;

namespace Submerged.UI.Patches;

[HarmonyPatch]
public static class FindAGamePatches
{
    [HarmonyPatch(typeof(MatchMakerGameButton), nameof(MatchMakerGameButton.SetGame))]
    [HarmonyPrefix]
    public static void AddSubmergedIconPatch(MatchMakerGameButton __instance, GameListing gameListing)
    {
        if (__instance.MapIcons.Length < 5) __instance.MapIcons = UpdateMapIcons(__instance.MapIcons).ToArray();
    }

    private static SCG.IEnumerable<Sprite> UpdateMapIcons(Il2CppReferenceArray<Sprite> existingIcons)
    {
        yield return existingIcons[0]; // Skeld
        yield return existingIcons[1]; // MIRA HQ
        yield return existingIcons[2]; // Polus
        yield return existingIcons[0]; // Dleks
        yield return existingIcons[3]; // Airship
        yield return existingIcons[4]; // Fungle
        yield return ResourceManager.spriteCache["FilterIcon"];
    }
}
