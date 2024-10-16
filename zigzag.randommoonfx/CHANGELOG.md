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