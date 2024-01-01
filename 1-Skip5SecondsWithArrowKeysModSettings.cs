using System.Collections.Generic;

// Add settings to your mod by implementing IModSettings.
// IModSettings extends IAutoBoundMod,
// which makes an object of the type available in other scripts via Inject attribute.
// Mod settings are saved to file when the app is closed.
public class Skip5SecondsWithArrowKeysModSettings : IModSettings
{
    public int secondsToSkip = 5;

    public List<IModSettingControl> GetModSettingControls()
    {
        return new List<IModSettingControl>()
        {
            new IntModSettingControl(() => secondsToSkip, newValue => secondsToSkip = newValue) { Label = "Seconds to skip" },
        };
    }
}
