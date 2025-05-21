using System;
using System.Windows.Forms;
using GuiHelpers;

namespace Wrappers;

public class FCheckBoxWrapper : SubscribeHelper, ICheckBoxWrapper
{
    #region Private Fields

    private readonly CheckBox _checkBox;

    #endregion
    
    #region Properties

    public bool IsEnabled
    {
        get => _checkBox.Enabled; 
        set => _checkBox.Enabled = value;
    }
    
    public bool IsVisible
    {
        get => _checkBox.Visible;
        set => _checkBox.Visible = value;
    }

    public bool Checked
    {
        get => _checkBox.Checked; 
        set => _checkBox.Checked = value;
    }
    
    public string Text
    {
        get => _checkBox.Text; 
        set => _checkBox.Text = value;
    }
    
    public GuiColor BackColor
    {
        get => FColorConverter.ColorToGui(_checkBox.BackColor);
        set => _checkBox.BackColor = FColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => FColorConverter.ColorToGui(_checkBox.ForeColor);
        set => _checkBox.ForeColor = FColorConverter.GuiToColor(value);
    }

    #endregion

    #region Events
    
    /// <summary>
    /// Изменение значения свойства Checked
    /// </summary>
    public event SenderEventHandler? CheckedChanged;

    #endregion

    #region Constructor

    public FCheckBoxWrapper(CheckBox checkBox)
    {
        _checkBox = checkBox;
        SubscribeToEvents(true);
    }

    #endregion

    #region Destructor
    
    ~FCheckBoxWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion

    #region Implement SubscribeHelper
    
    protected override void Subscribe()
    {
        _checkBox.CheckedChanged += CheckBoxOnCheckedChanged;
    }
    
    protected override void Unsubscribe()
    {
        _checkBox.CheckedChanged -= CheckBoxOnCheckedChanged;
    }

    #endregion

    #region Private Event Handler
    
    private void CheckBoxOnCheckedChanged(object sender, EventArgs e)
    {
        CheckedChanged?.Invoke(this);
    }

    #endregion
}