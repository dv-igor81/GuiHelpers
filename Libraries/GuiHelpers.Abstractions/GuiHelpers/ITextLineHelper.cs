using Wrappers;

namespace GuiHelpers;

public interface ITextLineHelper : ITextProperty, IVisibleProperty, IEnabledProperty, IReadOnlyProperty, IColorProperty
{
    #region Events

    /// <summary>
    ///     Генерируется при потере фокуса элементом управления
    /// </summary>
    event SenderEventHandler? LostFocusEvent;

    /// <summary>
    ///     Генерируется при получении фокуса элементом управления
    /// </summary>
    event SenderEventHandler? GotFocusEvent;

    /// <summary>
    ///     Генерируется при изменении текста в текстовом поле
    /// </summary>
    event ChangeTextEventHandler? ChangeTextEvent;

    #endregion
    
    #region Public Methods

    /// <summary>
    ///     Установить объект обёртку
    /// </summary>
    /// <param name="textBoxWrapper"></param>
    void SetTextBoxWrapper(ITextBoxWrapper textBoxWrapper);

    /// <summary>
    ///     Вернуть объект обёртку
    /// </summary>
    /// <param name="textBoxWrapper"></param>
    /// <returns></returns>
    ITextBoxWrapper? TextBoxWrapper(ITextBoxWrapper textBoxWrapper);

    #endregion
}