## 1.4.1
- **Updated**
    - Updated to work for v73, and still works on older versions of the game

## 1.4.0
- **Added**
    - Added `Company routing mode` config that allows users to choose how to mod works when auto routing to a Company Moon on the last day
        - Random: will randomize between all your installed Company Moons (vanilla or modded) and select one
        - Select: allow users to specify in the `Selected Company` config which moon is going to be forced routed to on the last day
        - Manual: there will be no auto routing, and players must route manually to the chosen Company Moon
- **Updated**
    - Blacklisted moons names in the config are now normalized so writting a name with number or spaces will now work as expected (ie: both Assurance or 220-Assurance will work)
    - Company Moons that are blacklisted will now be ignored by the randomization when `Company routing mode = Random`
    - Removed the manual modded Company moons configs as it's not needed anymore
- **Fixed**
    - Fixed modded Company Moons detection not working in some cases

## 1.3.6
- **Updated**
    - Compatibility with [CodeRebirth](https://thunderstore.io/c/lethal-company/p/XuXiaolan/CodeRebirth/) : the chosen moon on the last day will be Oxyde instead of Gordion (false by default, needs to be activated in the config)
    - Company Moons should now all be ignored by the randomization, the ship will only route to the chosen one on the last day

## 1.3.5
- **Updated**
    - Recompiled for v70
    - Updated README

## 1.3.4
- **Added**
    - Added compatibility with [LethalConstellations](https://thunderstore.io/c/lethal-company/p/darmuh/LethalConstellations/) if you have it installed (`LethalConstellations check` config added)

## 1.3.3
- **Added**
    - Added compatibility with [Wesleys_Moons](https://thunderstore.io/c/lethal-company/p/Magic_Wesley/Wesleys_Moons/): Galetry will now be chosen on the last day instead of Gordion if you have this mod installed (`Galetry Company Moon` config added)
- **Updated**
    - Galetry is now ignored by the randomization method until the last day (no need to have it blacklisted anymore)

## 1.3.2
- **Fixed**
    - `Moons Blacklist` config is now comma separated

## 1.3.1
- **Updated**
    - Added a new config `Moons Blacklist`, empty by default
    - You can add any moons you want in this list to make them unable to be chosen by the randomization method

# 1.3.0
- **Added**
    - Added compatibility with [Chameleon](https://thunderstore.io/c/lethal-company/p/ButteryStancakes/Chameleon/) routing animation if you are using the `PlanetPreview` feature (`Chameleon animation` config added)
    - Added `Animation time override` config to allow changing the default routing animation time
- **Updated**
    - Added 2 configs, both of them true by default
        - `Activate Random Moons` allows the mod to actually randomize the moons, you can disable it for testing
        - `Activate Free Moons` make all moons free when manually routing in the terminal (avoid people wasting money by using the terminal to route to a moon). This config works even if `Activate Random Moons` is false

## 1.2.5
- **Updated**
    - Added a new config `Exclude previously visited`, false by default
    - You can set this to true if you want to exclude already visited moons from the randomization method. The visited moons list will reset when all moons have been seen once.

## 1.2.4
- **Updated**
    - Added Github repository

## 1.2.3
- **Updated**
    - Added a new config `Randomize last day`, false by default
    - If set to true, it allows the ship to perform a random route on the last day if and only if you don't have enough scraps on the ship to meet quota. This can be used to mess around on a moon but you will be fired at the end of the day
        - This config also takes into acount the number of players that you can potentially kill at the Company to gain an additional 5 credits per bodies
        - With this, routing to a moon will be announced by the classic 'Halt!' warning

## 1.2.2
- **Updated**
    - Added 2 configs `Celestial_Tint animation` and `Quota check`, both of them true by default
    - `Quota check` can be set to false to enable quota rollover mods compatibility

## 1.2.1
- **Fixed**
    - Compatibility patch with `Fix_LeverDeadline` of [LethalFixes](https://thunderstore.io/c/lethal-company/p/Dev1A3/LethalFixes/)

# 1.2.0
- **Added**
    - The ship will now use the vanilla routing animation when the random moon is selected
    - Added compatibility with weather and misc infos on extra monitors provided by [GeneralImprovements](https://thunderstore.io/c/lethal-company/p/ShaosilGaming/GeneralImprovements/)
    - Added compatibility with [Celestial_Tint](https://thunderstore.io/c/lethal-company/p/sfDesat/Celestial_Tint/)'s routing animation
- **Updated**
    - The chosen moon info on the ship's main monitor is  now synchronized to all players
    - Changed the 'Auto route to Gordion' feature : the ship will not auto route to the Company Building on the last day but upon using the ship's lever it will route to this moon directly
        - The 'Halt!' warning has been completly disabled to ensure a smooth routing process
    - Changed how the moon is chosen in the code, this should prevent some mods conflicts but has no impact on gameplay

# 1.1.0
- **Added**
    - Improve the routing process to the Company Building by auto routing to it on the last day of the quota
        - This will make the ship in orbit, you still need to pull the lever to start the level
- **Updated**
    - Compatible with v64 of Lethal Company

# 1.0.0
- **Initial release**
    - Full update of the original [RandomMoon](https://thunderstore.io/c/lethal-company/p/Beepsterr/RandomMoon/) mod