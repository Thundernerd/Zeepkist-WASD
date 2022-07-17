using HarmonyLib;

namespace TNRD.Zeepkist.WASD.Patches;

[HarmonyPatch(typeof(DrivingController), "SetMenuActionsKeyboard")]
public class DrivingController_SetMenuActionsKeyboard
{
    private static void Postfix(DrivingActions player)
    {
        player.up.AddDefaultBinding(Plugin.Up.Value);
        player.down.AddDefaultBinding(Plugin.Down.Value);
        player.left.AddDefaultBinding(Plugin.Left.Value);
        player.right.AddDefaultBinding(Plugin.Right.Value);
    }
}
