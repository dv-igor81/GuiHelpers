// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace GuiHelpers;

public class GuiColor(byte a, byte r, byte g, byte b)
{
    /// <summary>
    /// Цвет элемента управления по умолчанию
    /// </summary>
    public static GuiColor Control { get; }
    
    public static GuiColor LightGray { get; } 
    
    public static GuiColor Wheat { get; }
    
    public static GuiColor Gold { get; }
    
    public static GuiColor GreenYellow { get; }
    
    public static GuiColor Yellow { get; }
    
    public static GuiColor Red { get; }
    
    public static GuiColor Green { get; }
    
    public static GuiColor DarkSeaGreen { get; }
    
    public static GuiColor Lime { get; }
    
    public static GuiColor Blue { get; }
    
    public static GuiColor Aqua { get; } 
    
    /// <summary>
    /// Чёрный
    /// </summary>
    public static GuiColor Black { get; }
    
    /// <summary>
    /// Белый
    /// </summary>
    public static GuiColor White { get; }
    
    /// <summary>
    /// Цвет элемента "Только для чтения"
    /// </summary>
    public static GuiColor ReadOnlyColor { get; }

    static GuiColor()
    {
        Control = new GuiColor(0xF0, 0xF0, 0xF0);
        LightGray = new GuiColor(0xD3, 0xD3, 0xD3);
        Wheat = new GuiColor(0xF5, 0xDE, 0xB3); 
        Gold = new GuiColor(0xFF, 0xD7, 0x00);
        GreenYellow = new GuiColor(0xAD, 0xFF, 0x2F);
        Yellow = new GuiColor(0xFF, 0xFF, 0x00);
        Red = new GuiColor(0xFF, 0x00, 0x00);
        Green = new GuiColor(0x00, 0x80, 0x00);
        DarkSeaGreen = new GuiColor(0x8F, 0xBC, 0x8F);
        Lime = new GuiColor(0x00, 0xFF, 0x00);
        Blue = new GuiColor(0x00, 0x00, 0xFF);
        Aqua = new GuiColor(0x00, 0xFF, 0xFF);
        Black = new GuiColor(0x00, 0x00, 0x00);
        White = new GuiColor(0xFF, 0xFF, 0xFF);
        ReadOnlyColor = new GuiColor(0xC0, 0xDC, 0xC0); // 192, 220, 192
    }

    private GuiColor(byte r, byte g, byte b) : this(byte.MaxValue, r, g, b)
    {
    }

    public byte A { get; } = a;
    public byte R { get; } = r;
    public byte G { get; } = g;
    public byte B { get; } = b;

    public static GuiColor FromArgb(int alpha, int red, int green, int blue)
    {
        return new GuiColor((byte)(alpha & 0xFF), (byte)(red & 0xFF), (byte)(green & 0xFF), (byte)(blue & 0xFF));
    }
    
    public static GuiColor FromRgb(int red, int green, int blue)
    {
        return new GuiColor((byte)(red & 0xFF), (byte)(green & 0xFF), (byte)(blue & 0xFF));
    }
}