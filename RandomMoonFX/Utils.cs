using System.Linq;

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
    }
}