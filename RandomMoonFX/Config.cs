﻿using BepInEx.Configuration;

namespace RandomMoonFX
{
    internal class Config
    {
        public ConfigEntry<bool> CelestialTintAnimation;
        public ConfigEntry<bool> ExcludePreviouslyVisited;
        public ConfigEntry<bool> QuotaCheck;
        public ConfigEntry<bool> RandomizeLastDay;

        public Config(ConfigFile cfg)
        {
            cfg.SaveOnConfigSet = false;
            CelestialTintAnimation = cfg.Bind("Routing animation", "Celestial_Tint animation", true, "Enable compatibility with Celestial_Tint routing animation (which is a little bit longer than vanilla). Will be automatically false if Celestial_Tint is not installed.");
            ExcludePreviouslyVisited = cfg.Bind("Randomization method", "Exclude previously visited", false, "Enable this if you want to exclude already visited moons from the randomization method. This will reset when all moons have been seen once.");
            QuotaCheck = cfg.Bind("Last day check", "Quota check", true, "If true, the ship will route to Gordion on the last day if quota has not been met yet. If false, there will be no quota check and the ship will route to Gordion only on the last day.");
            RandomizeLastDay = cfg.Bind("Last day check", "Randomize last day", false, "Enable this if you don't want to auto route to Gordion on the last day if there is not enough scraps in the ship to meet quota (other players potential dead bodies included), this allows you to randomize a moon on the last day to mess around but you will be fired at the end of the day.");
            cfg.Save();
            cfg.SaveOnConfigSet = true;
        }
    }
}
