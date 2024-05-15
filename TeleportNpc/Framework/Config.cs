using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace TeleportNpc.Framework;

public class Config
{
    public KeybindList OpenTeleport { get; set; } = new(SButton.B);
}