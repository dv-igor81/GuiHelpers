using Avalonia.Media;

namespace GuiHelpers.Avalonia.GuiHelpers;

public static class AColorConverter
{
    public static GuiColor ColorToGui(IBrush? brush)
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