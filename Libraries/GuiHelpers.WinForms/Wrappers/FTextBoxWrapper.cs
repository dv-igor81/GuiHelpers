using System;
using System.Windows.Forms;
using GuiHelpers;

namespace Wrappers;

/// <summary>
///     Обертка для TextBox WinForms
/// </summary>
public class FTextBoxWrapper : BackDelKeys, ITextBoxWrapper
{
    #region Private Fields

    private readonly TextBox _textBox;
    private bool _isReadOnly;

    #endregion
    
    #region Events

    /// <summary>
    ///     Генерируется при потере фокуса элементом управления
    /// </summary>
    public event SenderEventHandler? LostFocusEvent;

    /// <summary>
    ///     Генерируется при получении фокуса элементом управления
    /// </summary>
    public event SenderEventHandler? GotFocusEvent;

    /// <summary>
    ///     Нажата клавиша для ввода символа
    /// </summary>
    public event NewSymbolEventHandler? NewSymbolEvent;
    
    /// <summary>
    ///     Генерируется для отсоединения от связанного объекта с логикой.
    /// </summary>
    public event SenderEventHandler? DisconnectEvent;

    #endregion

    #region Constructor

    public FTextBoxWrapper(TextBox textBox)
    {
        _textBox = textBox;
        _textBox.TextAlign = HorizontalAlignment.Center; // !!! 30.09.2021
        _textBox.ReadOnly = true;
        //_isFocused = _textBox.Focused;
        CurrentSymbol = '\0';
        // По умолчанию компонент не только для чтения, но и для редактирования
        IsReadOnly = false;
        //_isReadOnly = false; 
        //SubscribeToEvents(!_isReadOnly);
    }

    #endregion

    #region Destructor

    ~FTextBoxWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion
    
    #region Event Handlers

    private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!(sender is TextBox)) return;
        CurrentSymbol = e.KeyChar;
        NewSymbolEvent?.Invoke();
    }

    private void _textBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(sender is TextBox)) return;
        if (e.KeyValue != 46) return;
        CurrentSymbol = DelKey;
        NewSymbolEvent?.Invoke();
    }

    private void _textBox_LostFocus(object sender, EventArgs e)
    {
        LostFocusEvent?.Invoke(this);
    }
    
    private void _textBox_GotFocus(object sender, EventArgs e)
    {
        GotFocusEvent?.Invoke(this);
    }

    #endregion

    #region Properties

    public string? Text
    {
        set => _textBox.Text = value;
    }

    /// <summary>
    ///     True - текстовое поле ввода только для чтения
    /// </summary>
    public bool IsReadOnly
    {
        set
        {
            _isReadOnly = value;
            SubscribeToEvents(!_isReadOnly);
        }
        get => _isReadOnly;
    }

    public char CurrentSymbol { get; private set; }

    public int SelectionStart
    {
        get => _textBox.SelectionStart;
        set => _textBox.SelectionStart = value;
    }

    public int SelectionLength => _textBox.SelectionLength;

    public bool IsEnabled
    {
        get => _textBox.Enabled;
        set => _textBox.Enabled = value;
    }

    public bool IsVisible
    {
        get => _textBox.Visible;
        set => _textBox.Visible = value;
    }
    
    public GuiColor BackColor
    {
        get => FColorConverter.ColorToGui(_textBox.BackColor);
        set => _textBox.BackColor = FColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => FColorConverter.ColorToGui(_textBox.ForeColor);
        set => _textBox.ForeColor = FColorConverter.GuiToColor(value);
    }

    #endregion

    #region Public Methods

    public void Focus()
    {
        _textBox.Focus();
    }

    /// <summary>
    ///     Дать команду на отсоединение от связанного объекта с логикой
    ///     (в случае, когда объект FTextBoxWrapper с ней связан).
    /// </summary>
    public void DisconnectCommand()
    {
        DisconnectEvent?.Invoke(this);
    }

    #endregion

    #region SubscribeHelper

    protected override void Subscribe()
    {
        _textBox.KeyDown += _textBox_KeyDown;
        _textBox.KeyPress += _textBox_KeyPress;
        _textBox.LostFocus += _textBox_LostFocus;
        _textBox.GotFocus += _textBox_GotFocus;
    }

    protected override void Unsubscribe()
    {
        _textBox.KeyDown -= _textBox_KeyDown;
        _textBox.KeyPress -= _textBox_KeyPress;
        _textBox.LostFocus -= _textBox_LostFocus;
        _textBox.GotFocus -= _textBox_GotFocus;
    }
    
    #endregion
}