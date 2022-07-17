using HarmonyLib;
using UnityEngine;

namespace TNRD.Zeepkist.WASD.Patches;

[HarmonyPatch(typeof(DrivingController), nameof(DrivingController.SetPlayerOneKeyboardActions))]
public class DrivingController_SetPlayerOneKeyboardActions
{
    private static void Postfix(DrivingActions player)
    {
        if (!OnlyOnePlayer())
            return;

        player.armsUp.AddDefaultBinding(Plugin.Up.Value);
        player.brake.AddDefaultBinding(Plugin.Down.Value);
        player.left.AddDefaultBinding(Plugin.Left.Value);
        player.right.AddDefaultBinding(Plugin.Right.Value);
        player.quickReset.AddDefaultBinding(Plugin.MenuAccept.Value);
    }

    private static bool OnlyOnePlayer()
    {
        return GameObject.Find("Game Manager")
            .GetComponent<PlayerManager>().amountOfPlayers == 1;
    }
}
