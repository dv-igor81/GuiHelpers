namespace GuiHelpers;

public interface IColorProperty
{
    /// <summary>
    /// Цвет фона
    /// </summary>
    GuiColor BackColor { get; set; }
    
    /// <summary>
    /// Цвет текста
    /// </summary>
    GuiColor ForeColor { get; set; }
}