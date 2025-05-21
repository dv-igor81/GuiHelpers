using System.Windows.Controls;
using GuiHelpers.WPF.GuiHelpers;
using Wrappers;

namespace GuiHelpers.WPF.Wrappers;

public class WLabelWrapper : SharedWrapper, ILabelWrapper
{
    #region Private Fields

    private readonly Label _label;

    #endregion

    #region Constructor

    public WLabelWrapper(Label label)
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
        get => WColorConverter.ColorToGui(_label.Background);
        set => _label.Background = WColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => WColorConverter.ColorToGui(_label.Foreground);
        set => _label.Foreground = WColorConverter.GuiToColor(value);
    }

    #endregion
    
    protected override void Subscribe()
    {
        throw new System.NotImplementedException();
    }

    protected override void Unsubscribe()
    {
        throw new System.NotImplementedException();
    }
}