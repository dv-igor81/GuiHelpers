using GuiHelpers.Demo.MVP.Models;
using GuiHelpers.Demo.MVP.Presenters;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.MVP;

public class ApplicationController : IApplicationController
{
    #region Private Fields

    private readonly IWindowWrapper _window;
    private readonly IViewLoader _viewLoader;

    private bool _hideMenu;

    #endregion

    #region Public Events

    /// <summary>
    ///     Был выход из дочерней формы
    /// </summary>
    public event SenderEventHandler? ExitEvent;

    #endregion

    #region Constructor

    public ApplicationController(IMenuView view, IViewLoader viewLoader)
    {
        _window = view.Window;
        _viewLoader = viewLoader;
    }

    #endregion

    #region IApplicationController

    /// <summary>
    ///     Открыть форму демонстрации возможностей
    ///     библиотеки текстовых помощников
    /// </summary>
    /// <param name="hideMenu">True - скрыть форму меню</param>
    public IWindowWrapper RunIntHelperDemo(bool hideMenu)
    {
        var formIntegerDemo = _viewLoader.CreateIntegerDemoView();
        IWindowWrapper window = formIntegerDemo.Window;
        var unused = new IntegerDemoPresenter(formIntegerDemo, this);
        RunWindowCore(hideMenu, window);
        return window;
    }

    public IWindowWrapper RunThreadHelperDemo(bool hideMenu)
    {
        var formThreadDemo = _viewLoader.CreateThreadDemoView();
        IWindowWrapper window = formThreadDemo.Window;
        ThreadDemoModel model = new ThreadDemoModel();
        var unused = new ThreadDemoPresenter(formThreadDemo, model, this);
        RunWindowCore(hideMenu, window);
        return window;
    }

    /// <summary>
    ///     Вернуться к показу главной формы
    /// </summary>
    public void Exit()
    {
        if (_hideMenu) _window.Show();
        ExitEvent?.Invoke(this);
    }

    #endregion

    #region Private Methods

    private void RunWindowCore(bool hideMenu,IWindowWrapper window)
    {
        _hideMenu = hideMenu;
        if (_hideMenu) _window.Hide();
        window.Show();
        window.Activate();
        window.ToCenterOfScreen();
    }

    #endregion
}