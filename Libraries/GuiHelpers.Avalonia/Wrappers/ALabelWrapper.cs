using Avalonia.Controls;
using GuiHelpers.Avalonia.GuiHelpers;
using Wrappers;

namespace GuiHelpers.Avalonia.Wrappers;

public class ALabelWrapper : ASharedWrapper, ILabelWrapper
{
    #region Private Fields

    private readonly Label _label;

    #endregion

    #region Constructor

    public ALabelWrapper(Label label)
    {
        _label = label;
    }

    #endregion

    #region Properties
    
    public bool IsVisible
    {
        get => _label.IsVisible;
        set => SetVisible(_label, value);
    }

    public string Text
    {
        get => GetText(_label); 
        set => SetText(_label, value);
    }
    
    public GuiColor BackColor
    {
        get => AColorConverter.ColorToGui(_label.Background);
        set => _label.Background = AColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => AColorConverter.ColorToGui(_label.Foreground);
        set => _label.Foreground = AColorConverter.GuiToColor(value);
    }

    #endregion
    
    protected override void Subscribe()
    {
        throw new NotImplementedException();
    }

    protected override void Unsubscribe()
    {
        throw new NotImplementedException();
    }
}