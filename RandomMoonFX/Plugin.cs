using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using System.Collections.Generic;


namespace RandomMoonFX
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency("com.github.darmuh.LethalConstellations", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        const string GUID = "zigzag.randommoonfx";
        const string NAME = "RandomMoonFX";
        const string VERSION = "1.3.5";

        public static Plugin instance;
        private readonly Harmony harmony = new Harmony(GUID);
        internal static Config config { get; private set; } = null!;

        private readonly int GordionID = 3;
        public int GaletryID = -99;
        public float AnimationTime = 1.5f;
        public bool IsStarting = false;
        public Terminal? terminal;
        public int terminalCostOfItems = -5;
        public bool constellationsCompatibility = false;
        public List<string> VisitedMoons = new List<string>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051")]
        void Awake()
        {
            instance = this;
            SetParameters();
            if (config.ActivateRandomMoons.Value)
            {
                harmony.CreateClassProcessor(typeof(StartOfRoundPatch), true).Patch();
                harmony.CreateClassProcessor(typeof(StartMatchLeverPatch), true).Patch();
            }
            if (config.ActivateFreeMoons.Value)
            {
                harmony.CreateClassProcessor(typeof(TerminalPatch), true).Patch();
            }
            Logger.LogInfo("RandomMoonFX is loaded !");
        }

        private void SetParameters()
        {
            config = new Config(base.Config);
            config.SetupCustomConfigs();
            if (config.ChameleonAnimation.Value && Chainloader.PluginInfos.ContainsKey("butterystancakes.lethalcompany.chameleon"))
                AnimationTime = 7.5f;
            if (config.CelestialTintAnimation.Value && Chainloader.PluginInfos.ContainsKey("CelestialTint"))
                AnimationTime = 4f;
            if (config.AnimationTimeOverride.Value >= 0f)
                AnimationTime = config.AnimationTimeOverride.Value;
            if (config.GaletryCompany.Value && Chainloader.PluginInfos.ContainsKey("JacobG5.WesleyMoons"))
                GaletryID = -1;
            if (config.ConstellationsCheck.Value && Chainloader.PluginInfos.ContainsKey("com.github.darmuh.LethalConstellations"))
                constellationsCompatibility = true;
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
                if (GaletryID != -99)
                {
                    if (GaletryID == -1)
                    {
                        foreach (var level in StartOfRound.Instance.levels)
                        {
                            if (level.PlanetName == "98 Galetry")
                            {
                                GaletryID = level.levelID;
                                break;
                            }
                        }
                    }
                    if (GaletryID != -1)
                    {
                        Logger.LogInfo("Force navigating to 98 Galetry");
                        StartOfRound.Instance.ChangeLevelServerRpc(GaletryID, FindObjectOfType<Terminal>().groupCredits);
                        IsStarting = true;
                        return;
                    }
                    Logger.LogError("Galetry Moon was not found");
                }
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
