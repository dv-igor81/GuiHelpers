using Wrappers;

namespace GuiHelpers.Demo.MVP;

public interface IApplicationController
{
    #region Events

    /// <summary>
    ///     Был выход из дочерней формы
    /// </summary>
    event SenderEventHandler? ExitEvent;

    #endregion

    #region Methods

    /// <summary>
    ///     Открыть форму демонстрации возможностей
    ///     библиотеки текстовых помощников
    /// </summary>
    /// <param name="hideMenu">True - скрыть форму меню</param>
    IWindowWrapper RunIntHelperDemo(bool hideMenu);


    /// <summary>
    ///     Открыть форму демонстрации возможностей
    ///     асинхронного программирования
    /// </summary>
    /// <param name="hideMenu">True - скрыть форму меню</param>
    /// <returns></returns>
    IWindowWrapper RunThreadHelperDemo(bool hideMenu);

    /// <summary>
    ///     Вернуться к показу главной формы
    /// </summary>
    void Exit();

    #endregion
}