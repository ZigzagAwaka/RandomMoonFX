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
            if (selectableLevel.PlanetName == "44 Liquidation" || Plugin.instance.CompanyMoons.Exists((i) => i.PlanetName == selectableLevel.PlanetName))
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
                if (Plugin.instance.VisitedMoons.Count >= StartOfRound.Instance.levels.Length - 1 - Plugin.instance.CompanyMoons.Count - Plugin.config.MoonsBlacklist.Count)
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
                return Plugin.config.MoonsBlacklist.Exists((i) => i == GetNormalizedMoonName(selectableLevel));
        }

        static public void SearchCompanyMoons()
        {
            if (Plugin.instance.CompanyMoons.Count > 0)
            {
                return;
            }
            foreach (var level in StartOfRound.Instance.levels)
            {
                if (!level.planetHasTime && !level.spawnEnemiesAndScrap  // these 2 flags deermine if the moon is a Company moon
                    && !IsMoonBlacklisted(level))
                {
                    Plugin.instance.CompanyMoons.Add(level);
                }
            }
        }

        static public string GetNormalizedMoonName(SelectableLevel selectableLevel)
        {
            return GetNormalizedMoonName(selectableLevel.PlanetName);
        }

        static public string GetNormalizedMoonName(string planetName)
        {
            var moonName = Regex.Replace(planetName, "^[0-9]+", string.Empty);
            if (moonName[0] == ' ' || moonName[0] == '-')
                moonName = moonName[1..];
            return moonName;
        }

        static public bool IsMoonValidFromConstellation(SelectableLevel selectableLevel)
        {
            return LethalConstellations.PluginCore.ClassMapper.IsLevelInConstellation(selectableLevel);
        }
    }
}