using Avalonia;
using Avalonia.Controls;

namespace GuiHelpers.Avalonia.GuiHelpers;

public abstract class ASharedWrapper : SubscribeHelper
{
    protected ASharedWrapper()
    {
        BackKey = '\b';
        DelKey = (char)(BackKey - 1);
    }

    protected char BackKey { get; }

    protected char DelKey { get; }
    
    #region Protected Methods

    protected void SetVisible(Visual control, bool visible)
    {
        control.IsVisible = visible;
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