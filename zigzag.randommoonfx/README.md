# RandomMoonFX

This mod will randomized the selected moon every day **upon using the ship's lever** !

You don't need to route to a moon with the terminal, just use the ship's lever and the ship will route to a random moon before loading it, this can make the game more difficult...

When there is 0 days left for the profit quota, it will always route to the Company Building.

Compatible with v62/v64/v69/v70/v72 of Lethal Company.

![Preview](https://raw.githubusercontent.com/ZigzagAwaka/RandomMoonFX/main/preview.gif)

![Preview](https://raw.githubusercontent.com/ZigzagAwaka/RandomMoonFX/main/preview2.gif)

##

### Compatibility
- This mod is compatible with [LethalLevelLoader](https://thunderstore.io/c/lethal-company/p/IAmBatby/LethalLevelLoader/) and works with any custom moon that uses this API.
- Compatible with [Celestial_Tint](https://thunderstore.io/c/lethal-company/p/sfDesat/Celestial_Tint/) and [Chameleon](https://thunderstore.io/c/lethal-company/p/ButteryStancakes/Chameleon/) special routing animations.
- Compatibility with Modded Company Moons such as the ones in [Wesleys_Moons](https://thunderstore.io/c/lethal-company/p/Magic_Wesley/Wesleys_Moons/) or [CodeRebirth](https://thunderstore.io/c/lethal-company/p/XuXiaolan/CodeRebirth/)
- Works well with the better screens feature of [GeneralImprovements](https://thunderstore.io/c/lethal-company/p/ShaosilGaming/GeneralImprovements/).
- No issues from the ship's lever fix of [LethalFixes](https://thunderstore.io/c/lethal-company/p/Dev1A3/LethalFixes/).
- Compatible with [LethalConstellations](https://thunderstore.io/c/lethal-company/p/darmuh/LethalConstellations/) so that the moon is chosen from the current constellation
- Quota rollover mods are supported with the config `Quota check = false`

### Not compatible with
- [InfectedCompany](https://thunderstore.io/c/lethal-company/p/InfectedCompany/InfectedCompany/) : causes some infected players desyncs (I think?)
- `LLL Ship Lever Fix` feature in [ScienceBird_Tweaks](https://thunderstore.io/c/lethal-company/p/ScienceBird/ScienceBird_Tweaks/) : this should be disabled in the config

### About LLL
- Not directly concerning this mod, if you have LLL installed you may *sometimes* notice a softlock during the moon loading phase concerning the ship's lever (it depends on your installed mods). If you have this issue or just want to be safe, then install [LLLHotreloadPatch](https://thunderstore.io/c/lethal-company/p/dopadream/LLLHotreloadPatch/) and the issue should be fixed

### Features
This mod is an upgrade of the original **RandomMoon** mod and adds some bug fixes and improvements to make it compatible with the latest game updates.
- Uses the ship's routing animation before the start of the level
- Configurable time for the routing animation, other than the default values
- A config to make moons only be chosen once, will reset if every moons have been visited (false by default)
- Configurable moons blacklist to prevent specific moons to be chosen randomly
- An option to select one of your installed Company Moons (vanilla or modded) as the one routed to on the last day, OR have all your Company Moons randomized between them all
- Synchronize the chosen moon info on the ship's monitor
- Removes the 'Halt!' warning on the last day when auto routing to the Company Building
- Prevent the random selection of Company Moons before the last day of the quota
- Prevent the random selection of Liquidation since the moon is disabled in vanilla (fixed a softlock)
- A config to have all moons free even if you disable random moons
- Updated to the latest version of the game and compatible with LLL to avoid any desync between players

### Contact
If you want to suggest new features or contact me please go to the mod page in the [modding discord](https://discord.com/invite/lcmod).

###

##

# Credits

Original mod created by of [Beepsterr](https://thunderstore.io/c/lethal-company/p/Beepsterr/RandomMoon/)