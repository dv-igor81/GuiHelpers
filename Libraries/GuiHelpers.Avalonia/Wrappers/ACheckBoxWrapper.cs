using Avalonia.Controls;
using GuiHelpers.Avalonia.GuiHelpers;
using Wrappers;

namespace GuiHelpers.Avalonia.Wrappers;

public class ACheckBoxWrapper : ASharedWrapper, ICheckBoxWrapper
{
    #region Private Fields

    private readonly CheckBox _checkBox;

    #endregion
    
    #region Properties

    public bool IsEnabled
    {
        get => _checkBox.IsEnabled; 
        set => _checkBox.IsEnabled = value;
    }
    
    public bool IsVisible
    {
        get => _checkBox.IsVisible;
        set => SetVisible(_checkBox, value);
    }

    public bool Checked
    {
        get => GetChecked(); 
        set => SetChecked(value);
    }
    
    public string Text
    {
        get => GetText(_checkBox); 
        set => SetText(_checkBox, value);
    }
    
    public GuiColor BackColor
    {
        get => AColorConverter.ColorToGui(_checkBox.Background);
        set => _checkBox.Background = AColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => AColorConverter.ColorToGui(_checkBox.Foreground);
        set => _checkBox.Foreground = AColorConverter.GuiToColor(value);
    }

    #endregion

    #region Events
    
    /// <summary>
    /// Изменение значения свойства Checked
    /// </summary>
    public event SenderEventHandler? CheckedChanged;

    #endregion

    #region Constructor

    public ACheckBoxWrapper(CheckBox checkBox)
    {
        _checkBox = checkBox;
        SubscribeToEvents(true);
    }

    #endregion

    #region Destructor
    
    ~ACheckBoxWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion

    #region Implement SubscribeHelper
    
    protected override void Subscribe()
    {
        _checkBox.IsCheckedChanged += CheckBoxOnCheckedChanged;
    }
    
    protected override void Unsubscribe()
    {
        _checkBox.IsCheckedChanged += CheckBoxOnCheckedChanged;
    }

    #endregion

    #region Private Event Handler
    
    private void CheckBoxOnCheckedChanged(object? sender, EventArgs e)
    {
        CheckedChanged?.Invoke(this);
    }

    #endregion
    
    #region Private Methods

    private bool GetChecked()
    {
        return _checkBox.IsChecked.HasValue && _checkBox.IsChecked.Value;
    }

    private void SetChecked(bool checkedState)
    {
        _checkBox.IsChecked = checkedState;
    }
    
    #endregion
}