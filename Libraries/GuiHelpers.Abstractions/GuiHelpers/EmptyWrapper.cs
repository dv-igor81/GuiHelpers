using System;
using Wrappers;

namespace GuiHelpers;

public class EmptyWrapper :
    IButtonWrapper,
    ICheckBoxWrapper,
    ILabelWrapper,
    ITextBoxWrapper,
    IWindowWrapper
{
    public EmptyWrapper()
    {
        ForeColor = GuiColor.White;
        Text = string.Empty;
        CurrentSymbol = '\0';
        SelectionLength = 0;
        InvokeRequired = false;
        BackColor = GuiColor.White;
    }

    public bool IsEnabled { get; set; }
    public bool IsVisible { get; set; }
    public GuiColor BackColor { get; set; }
    public GuiColor ForeColor { get; set; }
    public string Text { get; set; }
    public bool IsReadOnly { get; set; }
    public char CurrentSymbol { get; }
    public int SelectionStart { get; set; }
    public int SelectionLength { get; }
    public event NewSymbolEventHandler? NewSymbolEvent;
    public event SenderEventHandler? LostFocusEvent;
    public event SenderEventHandler? GotFocusEvent;
    public event SenderEventHandler? DisconnectEvent;

    public void Focus()
    {
    }

    public void DisconnectCommand()
    {
    }

    public event SenderEventHandler? Click;
    public event SenderEventHandler? CheckedChanged;
    public bool Checked { get; set; }

    public void Invoke(Delegate method)
    {
    }

    public void BeginInvoke(Delegate method)
    {
    }

    public bool InvokeRequired { get; }

    public event WindowClosingEventHandler? ClosingEvent;

    public void SetCapture(string text)
    {
    }

    public void Hide()
    {
    }

    public void Show()
    {
    }

    public void Close()
    {
    }

    public void Activate()
    {
    }

    /// <summary>
    ///     Переместить окно в центр экрана
    /// </summary>
    public void ToCenterOfScreen()
    {
    }
}