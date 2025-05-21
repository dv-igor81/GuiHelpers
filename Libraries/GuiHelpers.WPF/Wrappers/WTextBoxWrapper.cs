using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GuiHelpers.WPF.GuiHelpers;
using Wrappers;

namespace GuiHelpers.WPF.Wrappers;

public class WTextBoxWrapper : SharedWrapper, ITextBoxWrapper
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

    public WTextBoxWrapper(TextBox textBox)
    {
        _textBox = textBox;
        _textBox.TextAlignment = TextAlignment.Center;
        _textBox.IsReadOnly = true;
        _textBox.IsReadOnlyCaretVisible = true;
        _textBox.CaretBrush = WColorConverter.GuiToColor(GuiColor.Black);
        CurrentSymbol = '\0';
        // По умолчанию компонент не только для чтения, но и для редактирования
        IsReadOnly = false;
    }

    #endregion

    #region Destructor

    ~WTextBoxWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion
    
    #region Event Handlers
    
    private void _textBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Back:
                CurrentSymbol = BackKey;
                break;
            case Key.Delete:
                CurrentSymbol = DelKey;
                break;
            case Key.Space:
                CurrentSymbol = ' ';
                break;
        }
        switch (e.Key)
        {
            case Key.Back:
            case Key.Delete:
            case Key.Space:
                NewSymbolEvent?.Invoke();
                break;
        }
    }
    
    private void _textBox_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                CursorPrevious();
                break;
            case Key.Down:
                CursorNext();
                break;
        }
    }
    
    private void TextBoxOnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (e.Text == null) return;
        if (e.Text.Length != 1) return;
        CurrentSymbol = e.Text[0];
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
        set => SetText(value);
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
        get => _textBox.IsEnabled;
        set => _textBox.IsEnabled = value;
    }

    public bool IsVisible
    {
        get => _textBox.IsVisible;
        set => SetVisible(_textBox, value);
    }
    
    public GuiColor BackColor
    {
        get => WColorConverter.ColorToGui(_textBox.Background);
        set => _textBox.Background = WColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => WColorConverter.ColorToGui(_textBox.Foreground);
        set => _textBox.Foreground = WColorConverter.GuiToColor(value);
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
        _textBox.PreviewKeyDown += _textBox_PreviewKeyDown;
        _textBox.KeyUp += _textBox_KeyUp;
        _textBox.PreviewTextInput += TextBoxOnPreviewTextInput;
        _textBox.LostFocus += _textBox_LostFocus;
        _textBox.GotFocus += _textBox_GotFocus;
    }
    
    protected override void Unsubscribe()
    {
        _textBox.PreviewKeyDown -= _textBox_PreviewKeyDown;
        _textBox.KeyUp -= _textBox_KeyUp;
        _textBox.PreviewTextInput -= TextBoxOnPreviewTextInput;
        _textBox.LostFocus -= _textBox_LostFocus;
        _textBox.GotFocus -= _textBox_GotFocus;
    }
    
    #endregion
    
    #region Private Methods
    
    private void SetText(string? text)
    {
        _textBox.Text = text ?? string.Empty;
    }
    
    private void CursorNext()
    {
        if (_textBox.CaretIndex >= _textBox.Text.Length) return;
        _textBox.CaretIndex++;
        _textBox.SelectionLength = 0;
    }

    private void CursorPrevious()
    {
        if (_textBox.CaretIndex <= 0) return;
        _textBox.CaretIndex--;
        _textBox.SelectionLength = 0;
    }
    
    #endregion
}