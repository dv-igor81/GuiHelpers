using GuiHelpers;

namespace Wrappers;

public interface ITextBoxWrapper : IEnabledProperty, IVisibleProperty, IColorProperty
{
    #region Public Properties

    string? Text { set; }
    
    bool IsReadOnly { get; set; }

    char CurrentSymbol { get; }

    int SelectionStart { get; set; }

    int SelectionLength { get; }

    #endregion

    #region Events

    /// <summary>
    ///     Нажата клавиша для ввода символа
    /// </summary>
    event NewSymbolEventHandler NewSymbolEvent;

    /// <summary>
    ///     Генерируется при потере фокуса элементом управления
    /// </summary>
    event SenderEventHandler? LostFocusEvent;

    /// <summary>
    ///     Генерируется при получении фокуса элементом управления
    /// </summary>
    event SenderEventHandler? GotFocusEvent;
    
    /// <summary>
    ///     Генерируется для отсоединения от связанного объекта с логикой.
    /// </summary>
    event SenderEventHandler? DisconnectEvent;

    #endregion

    #region Methods

    void Focus();

    /// <summary>
    ///     Дать команду на отсоединение от связанного объекта с логикой
    ///     (в случае, когда объект ITextBoxWrapper с ней связан).
    /// </summary>
    public void DisconnectCommand();

    #endregion
}