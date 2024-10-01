using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace RandomMoonFX
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("StartGame")]
        public static bool RandomizeMoonPatch()
        {
            if (Plugin.instance.IsStarting)
            {
                Plugin.instance.IsStarting = false;
                return true;
            }
            else
            {
                Plugin.instance.RouteRandomPlanet();
                return false;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("TravelToLevelEffects")]
        public static IEnumerator StartMoonPatch(IEnumerator result)
        {
            while (result.MoveNext())
            {
                yield return result.Current;
            }
            if (Plugin.instance.IsStarting)
            {
                StartMatchLever lever = Object.FindObjectOfType<StartMatchLever>();
                lever.triggerScript.interactable = false;
                yield return new WaitForSeconds(Plugin.instance.AnimationTime);
                lever.triggerScript.interactable = true;
                Plugin.instance.StartRandomPlanet();
            }
        }
    }

    [HarmonyPatch(typeof(StartMatchLever))]
    internal class StartMatchLeverPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("BeginHoldingInteractOnLever")]
        public static bool DisabledLastDayWarningPatch()
        {
            if (StartOfRound.Instance.CanChangeLevels() && Plugin.instance.LastDayOfQuota())
            {
                return false;
            }
            return true;
        }

        // COMPATIBILITY PATCH WITH LETHALFIXES MOD, NOT NEEDED IN VANILLA
        [HarmonyPostfix]
        [HarmonyPatch("BeginHoldingInteractOnLever")]
        public static void DisabledLongHoldTime(ref StartMatchLever __instance)
        {
            if (TimeOfDay.Instance.daysUntilDeadline <= 0 && __instance.playersManager.inShipPhase && StartOfRound.Instance.currentLevel.planetHasTime
                && Plugin.instance.LastDayOfQuota())
            {
                __instance.triggerScript.timeToHold = 0.7f;
            }
        }
    }
}
