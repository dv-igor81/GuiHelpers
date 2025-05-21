using System.Windows;
using System.Windows.Controls;

namespace GuiHelpers.WPF.GuiHelpers;

public abstract class SharedWrapper : SubscribeHelper
{
    protected SharedWrapper()
    {
        BackKey = '\b';
        DelKey = (char)(BackKey - 1);
    }

    protected char BackKey { get; }

    protected char DelKey { get; }
    
    #region Protected Methods

    protected void SetVisible(UIElement control, bool visible)
    {
        control.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
    }

    protected string GetText(ContentControl control)
    {
        if (control.Content is string text)
        {
            return text;
        }
        return string.Empty;
    }

    protected void SetText(ContentControl control, string text)
    {
        control.Content = text;
    }

    #endregion
}