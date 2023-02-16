using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Floaty
{
    [BepInPlugin("farmk.Floaty", "Floaty", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class Floaty : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("farmk.Floaty");

        void Awake()
        {
            Debug.Log("Floaty Mod loaded. Adding Floating component to all ItemDrop objects.");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(ItemDrop), "Awake")]
        class Float_Patch
        {
            static void Prefix(ItemDrop __instance)
            {
                if (__instance.gameObject.GetComponent<Floating>() == null)
                {
                    Floating floating = __instance.gameObject.AddComponent<Floating>();
                    floating.m_waterLevelOffset = 0.5f;
                }
            }
        }
    }
}
