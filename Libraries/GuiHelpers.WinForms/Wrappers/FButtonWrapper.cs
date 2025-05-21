using System;
using System.Windows.Forms;
using GuiHelpers;

namespace Wrappers;

public class FButtonWrapper : SubscribeHelper, IButtonWrapper
{
    #region Private Fields

    private readonly Button _button;

    #endregion
        
    #region Constructor

    public FButtonWrapper(Button button)
    {
        _button = button;
        SubscribeToEvents(true);
    }

    #endregion

    #region Destructor

    ~FButtonWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion
        
    #region Properties

    public bool IsEnabled
    {
        get => _button.Enabled;
        set => _button.Enabled = value;
    }
    
    public bool IsVisible
    {
        get => _button.Visible;
        set => _button.Visible = value;
    }
        
    public string Text
    {
        get => _button.Text; 
        set => _button.Text = value;
    }
    
    public GuiColor BackColor
    {
        get => FColorConverter.ColorToGui(_button.BackColor);
        set => _button.BackColor = FColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => FColorConverter.ColorToGui(_button.ForeColor);
        set => _button.ForeColor = FColorConverter.GuiToColor(value);
    }

    #endregion

    #region Events

    public event SenderEventHandler? Click;

    #endregion

    #region Implement SubscribeHelper

    protected override void Subscribe()
    {
        _button.Click += ButtonOnClick;
    }
        
    protected override void Unsubscribe()
    {
        _button.Click -= ButtonOnClick;
    }

    #endregion

    #region Control Event Handler

    private void ButtonOnClick(object sender, EventArgs e)
    {
        Click?.Invoke(this);
    }

        
    #endregion
}