using System.Drawing;

namespace GuiHelpers;

internal static class FColorConverter
{
    public static GuiColor ColorToGui(Color color)
    {
        return new GuiColor(color.A,color.R, color.G, color.B);
    }

    public static Color GuiToColor(GuiColor guiColor)
    {
        return Color.FromArgb(guiColor.R, guiColor.G, guiColor.B);
    }
}