﻿using Avalonia.Controls;
using GuiHelpers.Avalonia.GuiHelpers;
using Wrappers;

namespace GuiHelpers.Avalonia.Wrappers;

public class AButtonWrapper : ASharedWrapper, IButtonWrapper
{
    #region Private Fields

    private readonly Button _button;

    #endregion
        
    #region Constructor

    public AButtonWrapper(Button button)
    {
        _button = button;
        SubscribeToEvents(true);
    }

    #endregion

    #region Destructor

    ~AButtonWrapper()
    {
        SubscribeToEvents(false);
    }

    #endregion
        
    #region Properties

    public bool IsEnabled
    {
        get => _button.IsEnabled;
        set => _button.IsEnabled = value;
    }
    
    public bool IsVisible
    {
        get => _button.IsVisible;
        set => SetVisible(_button, value);
    }
        
    public string Text
    {
        get => GetText(_button);
        set => SetText(_button, value);
    }
    
    public GuiColor BackColor
    {
        get => AColorConverter.ColorToGui(_button.Background);
        set => _button.Background = AColorConverter.GuiToColor(value);
    }

    public GuiColor ForeColor
    {
        get => AColorConverter.ColorToGui(_button.Foreground);
        set => _button.Foreground = AColorConverter.GuiToColor(value);
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

    private void ButtonOnClick(object? sender, EventArgs e)
    {
        Click?.Invoke(this);
    }
    
    #endregion
}