using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace TNRD.Zeepkist.WASD
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Zeepkist.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<InControl.Key> Left { get; private set; }
        public static ConfigEntry<InControl.Key> Right { get; private set; }
        public static ConfigEntry<InControl.Key> Up { get; private set; }
        public static ConfigEntry<InControl.Key> Down { get; private set; }
        public static ConfigEntry<InControl.Key> QuickReset { get; private set; }
        public static ConfigEntry<InControl.Key> MenuAccept { get; private set; }

        private void Awake()
        {
            Up = Config.Bind("General",
                "up",
                InControl.Key.W,
                "Key replacing the up arrow");

            Down = Config.Bind("General",
                "down",
                InControl.Key.S,
                "Key replacing the down arrow");

            Left = Config.Bind("General",
                "left",
                InControl.Key.A,
                "Key replacing the left arrow");

            Right = Config.Bind("General",
                "right",
                InControl.Key.D,
                "Key replacing the right arrow");

            QuickReset = Config.Bind("General",
                "right",
                InControl.Key.RightShift,
                "Key replacing the quick reset");

            MenuAccept = Config.Bind("General",
                "menuAccept",
                InControl.Key.RightShift,
                "Key replacing the right shift");

            Harmony harmony = new Harmony("net.tnrd.zeepkist.wasd");
            harmony.PatchAll();

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
