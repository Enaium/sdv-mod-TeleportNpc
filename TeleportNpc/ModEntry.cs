using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using TeleportNpc.Framework;
using TeleportNpc.Framework.Gui;

namespace TeleportNpc;

public class ModEntry : Mod
{
    private Config _config;
    private static ModEntry _instance;

    public ModEntry()
    {
        _instance = this;
    }

    public override void Entry(IModHelper helper)
    {
        _config = helper.ReadConfig<Config>();
        helper.Events.Input.ButtonsChanged += ButtonsChanged;
    }

    private void ButtonsChanged(object? sender, ButtonsChangedEventArgs e)
    {
        if (!Context.IsWorldReady)
            return;
        if (!Context.IsPlayerFree)
            return;
        if (!_config.OpenTeleport.JustPressed())
            return;
        Game1.activeClickableMenu = new TeleportNpcScreen();
    }

    public static ModEntry GetInstance()
    {
        return _instance;
    }
}