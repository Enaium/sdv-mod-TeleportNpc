using EnaiumToolKit.Framework.Screen.Elements;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Characters;
using StardewValley.Menus;

namespace TeleportNpc.Framework.Screen.Elements;

public class NpcButton : BaseButton
{
    private NPC Npc;

    public NpcButton(string title, string description, NPC npc) : base(title, description)
    {
        Npc = npc;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Render2DUtils.DrawButton(b, x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
        if (Npc is not (Pet or Horse or TrashBear))
        {
            new ClickableTextureComponent("Mugshot", new Rectangle(x, y, Height, Height), "", "", Npc.Sprite.Texture,
                Npc.getMugShotSourceRect(), 0.7f * Game1.pixelZoom).draw(b);
        } else switch (Npc)
        {
            case Pet pet:
                new ClickableTextureComponent("Mugshot", new Rectangle(x, y, Height, Height), "", "", Npc.Sprite.Texture,
                    new Rectangle(0, pet.Sprite.SourceRect.Height * 2 - 24, pet.Sprite.SourceRect.Width, 24), 0.7f * Game1.pixelZoom).draw(b);
                break;
            case Horse horse:
                new ClickableTextureComponent("Mugshot", new Rectangle(x, y, Height, Height), "", "", Npc.Sprite.Texture,
                    new Rectangle(0, horse.Sprite.SourceRect.Height * 2 - 26, horse.Sprite.SourceRect.Width, 24), 0.7f * Game1.pixelZoom).draw(b);
                break;
            case TrashBear trashBear:
                new ClickableTextureComponent("Mugshot", new Rectangle(x, y, Height, Height), "", "", Npc.Sprite.Texture,
                    new Rectangle(0, trashBear.Sprite.SourceRect.Height, trashBear.Sprite.SourceRect.Width, 24), 0.7f * Game1.pixelZoom).draw(b);
                break;
        }

        base.Render(b, x, y);
    }
}