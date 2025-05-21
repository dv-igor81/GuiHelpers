using System.Windows.Forms;
using GuiHelpers;

namespace Wrappers;

public class FLabelWrapper : ILabelWrapper
{
    #region Private Fields

    private readonly Label _label;

    #endregion

    #region Constructor

    public FLabelWrapper(Label label)
    {
        _label = label;
    }

    #endregion

    #region Properties
    
    public bool IsVisible
    {
        get => _label.Visible;
        set => _label.Visible = value;
    }

    public string Text
    {
        get => _label.Text; 
        set => _label.Text = value;
    }
    
    public GuiColor BackColor
    {
        get => FColorConverter.ColorToGui(_label.BackColor);
        set => _label.BackColor = FColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => FColorConverter.ColorToGui(_label.ForeColor);
        set => _label.ForeColor = FColorConverter.GuiToColor(value);
    }

    #endregion
}