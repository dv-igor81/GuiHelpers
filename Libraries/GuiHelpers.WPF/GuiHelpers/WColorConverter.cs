using System.Windows.Media;

namespace GuiHelpers.WPF.GuiHelpers;

public static class WColorConverter
{
    public static GuiColor ColorToGui(Brush brush)
    {
        if (brush is SolidColorBrush colorBrush)
        {
            Color color = colorBrush.Color;
            return new GuiColor(color.A, color.R, color.G, color.B);
        }
        return GuiColor.Black;
    }

    public static Brush GuiToColor(GuiColor guiColor)
    {
        Color color = Color.FromArgb(guiColor.A, guiColor.R, guiColor.G, guiColor.B);
        return new SolidColorBrush(color);
    }
}