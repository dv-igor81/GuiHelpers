using GuiHelpers;

namespace Wrappers;

public interface IButtonWrapper : IEnabledProperty, IVisibleProperty, IColorProperty, ITextProperty
{
    #region Events

    /// <summary>
    /// Клик мышкой по кнопке
    /// </summary>
    event SenderEventHandler Click;

    #endregion
}