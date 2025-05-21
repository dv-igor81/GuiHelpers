using GuiHelpers;

namespace Wrappers;

public interface IWindowWrapper : IBeginInvokeHelper
{
    #region Events
    
    /// <summary>
    ///     Генерируется при попытке закрыть окно.
    /// </summary>
    event WindowClosingEventHandler? ClosingEvent;
    
    #endregion

    #region Methods

    /// <summary>
    /// Установить заголовок окна
    /// </summary>
    /// <param name="text"></param>
    void SetCapture(string text);

    /// <summary>
    /// Скрыть окно
    /// </summary>
    void Hide();
    
    /// <summary>
    /// Показать окно
    /// </summary>
    void Show();
    
    /// <summary>
    /// Закрыть окно
    /// </summary>
    void Close();
    
    /// <summary>
    /// Сделать окно активным, если оно свёрнуто - развернуть
    /// </summary>
    void Activate();
    
    /// <summary>
    /// Переместить окно в центр экрана
    /// </summary>
    void ToCenterOfScreen();

    #endregion
}