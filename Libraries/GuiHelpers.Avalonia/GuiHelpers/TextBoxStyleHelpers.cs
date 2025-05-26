using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Styling;

namespace GuiHelpers.Avalonia.GuiHelpers;

public static class TextBoxStyleHelpers
{
    private static Style? _pointeroverStyle;
    private static Style? _focusStyle;
    
    /// <summary>
    /// Добавить стили, которые позволят изменять цвет фона
    /// элемента управления, когда он в фокусе, и когда над
    /// ним указатель мышки.
    /// </summary>
    /// <param name="textBox"></param>
    public static void AddDefaultStyles(TextBox textBox)
    {
        _pointeroverStyle = new Style(x => 
            x.OfType<TextBox>()
                .Class(":pointerover")
                .Template()
                .OfType<Border>()
                .Name("PART_BorderElement")
        )
        {
            Setters =
            {
                new Setter(TemplatedControl.BackgroundProperty, new TemplateBinding(TemplatedControl.BackgroundProperty)),
            }
        };
        
        _focusStyle = new Style(x => 
            x.OfType<TextBox>()
                .Class(":focus")
                .Template()
                .OfType<Border>()
                .Name("PART_BorderElement")
        )
        {
            Setters =
            {
                new Setter(TemplatedControl.BackgroundProperty, new TemplateBinding(TemplatedControl.BackgroundProperty)),
            }
        };
        textBox.Styles.Add(_pointeroverStyle);
        textBox.Styles.Add(_focusStyle);
    }
}