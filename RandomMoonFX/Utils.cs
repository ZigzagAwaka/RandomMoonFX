using System.Linq;
using System.Text.RegularExpressions;

namespace RandomMoonFX
{
    internal class Utils
    {
        static public bool IsLastDayRandom()
        {
            if (TimeOfDay.Instance.daysUntilDeadline != 0 || !Plugin.config.RandomizeLastDay.Value)
                return false;
            else
            {
                bool? inShip = true;
                int potentialBodiesValue = 5 * (StartOfRound.Instance.allPlayerObjects.Length - 1);
                int scrapsValue = UnityEngine.Object.FindObjectsOfType<GrabbableObject>().Where(o => o.itemProperties.isScrap && o.itemProperties.minValue > 0
                    && !(o is RagdollGrabbableObject) && (!(o is StunGrenadeItem g) || !g.hasExploded || !g.DestroyGrenade)
                    && (!inShip.HasValue || (o.isInShipRoom == inShip && o.isInElevator == inShip))).ToList().Sum(s => s.scrapValue);
                if (scrapsValue + potentialBodiesValue + TimeOfDay.Instance.quotaFulfilled >= TimeOfDay.Instance.profitQuota)
                    return false;
                return true;
            }
        }

        static public bool IsMoonValid(SelectableLevel selectableLevel)
        {
            if (selectableLevel.PlanetName == "44 Liquidation" || selectableLevel.PlanetName == "71 Gordion" || (Plugin.instance.GaletryID != -99 && selectableLevel.PlanetName == "98 Galetry"))
                return false;
            if (IsMoonBlacklisted(selectableLevel) || (Plugin.instance.constellationsCompatibility && !IsMoonValidFromConstellation(selectableLevel)))
                return false;
            if (!Plugin.config.ExcludePreviouslyVisited.Value || Plugin.instance.constellationsCompatibility)
                return true;
            if (Plugin.instance.VisitedMoons.Count == 0 || !Plugin.instance.VisitedMoons.Contains(selectableLevel.PlanetName))
            {
                Plugin.instance.VisitedMoons.Add(selectableLevel.PlanetName);
                return true;
            }
            else
            {
                if (Plugin.instance.VisitedMoons.Count >= StartOfRound.Instance.levels.Length - 2 - (Plugin.instance.GaletryID != -99 ? 1 : 0) - Plugin.config.MoonsBlacklist.Count)
                {
                    Plugin.instance.VisitedMoons.Clear();
                    Plugin.instance.VisitedMoons.Add(selectableLevel.PlanetName);
                    return true;
                }
                return false;
            }
        }

        static public bool IsMoonBlacklisted(SelectableLevel selectableLevel)
        {
            if (Plugin.config.MoonsBlacklist.Count == 0)
                return false;
            else
            {
                var moonName = Regex.Replace(selectableLevel.PlanetName, "^[0-9]+", string.Empty);
                if (moonName[0] == ' ')
                    moonName = moonName[1..];
                return Plugin.config.MoonsBlacklist.Exists((i) => i == moonName);
            }
        }

        static public bool IsMoonValidFromConstellation(SelectableLevel selectableLevel)
        {
            return LethalConstellations.PluginCore.ClassMapper.IsLevelInConstellation(selectableLevel);
        }
    }
}