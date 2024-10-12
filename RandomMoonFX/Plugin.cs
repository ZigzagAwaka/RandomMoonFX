using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace RandomMoonFX
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        const string GUID = "zigzag.randommoonfx";
        const string NAME = "RandomMoonFX";
        const string VERSION = "1.2.5";

        public static Plugin instance;
        private readonly Harmony harmony = new Harmony(GUID);
        internal static Config config { get; private set; } = null!;

        private readonly int GordionID = 3;
        public float AnimationTime = 1.5f;
        public bool IsStarting = false;
        public List<string> VisitedMoons = new List<string>();

        void Awake()
        {
            instance = this;
            SetParameters();
            harmony.PatchAll();
            Logger.LogInfo("RandomMoonFX is loaded !");
        }

        private void SetParameters()
        {
            config = new Config(base.Config);
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
            if (config.CelestialTintAnimation.Value && assemblies.Any(assembly => assembly.FullName.StartsWith("CelestialTint")))
            {
                AnimationTime = 4f;
            }
        }

        public bool LastDayOfQuota()
        {
            if (Utils.IsLastDayRandom())
                return false;
            if (config.QuotaCheck.Value)
                return TimeOfDay.Instance.daysUntilDeadline == 0 && TimeOfDay.Instance.profitQuota > TimeOfDay.Instance.quotaFulfilled;
            else
                return TimeOfDay.Instance.daysUntilDeadline == 0;
        }

        public void RouteRandomPlanet()
        {
            if (LastDayOfQuota())
            {
                Logger.LogInfo("Force navigating to the Company Building");
                StartOfRound.Instance.ChangeLevelServerRpc(GordionID, FindObjectOfType<Terminal>().groupCredits);
            }
            else
            {
                SelectableLevel selectableLevel = TimeOfDay.Instance.currentLevel;
                while (selectableLevel.PlanetName == TimeOfDay.Instance.currentLevel.PlanetName)
                {
                    selectableLevel = StartOfRound.Instance.levels[UnityEngine.Random.Range(0, StartOfRound.Instance.levels.Length)];
                    if (!Utils.IsMoonValid(selectableLevel))
                    {
                        selectableLevel = TimeOfDay.Instance.currentLevel;
                    }
                }
                Logger.LogInfo($"Navigating to {selectableLevel.PlanetName}");
                StartOfRound.Instance.ChangeLevelServerRpc(selectableLevel.levelID, FindObjectOfType<Terminal>().groupCredits);
            }
            IsStarting = true;
        }

        public void StartRandomPlanet()
        {
            StartOfRound.Instance.StartGameServerRpc();
        }
    }
}
