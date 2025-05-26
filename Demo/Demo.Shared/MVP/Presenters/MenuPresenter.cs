using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.MVP.Presenters;

public class MenuPresenter
{
    #region Private Fields

    private readonly IWindowWrapper _menuWindow;
    private readonly IButtonWrapper _intHelperButton;
    private readonly IButtonWrapper _threadHelperButton;
    private readonly ICheckBoxWrapper _hideMenuCheckBox;
    private readonly IButtonWrapper _closeFormButton;
    
    private readonly IApplicationController _appController;
    
    /// <summary>
    /// Текущее дочернее окно (если есть)
    /// </summary>
    private IWindowWrapper? _currentChildWindow;

    #endregion

    #region Constructor
    
    public MenuPresenter(
        IMenuView view, 
        IApplicationController appController)
    {
        // Сохранение
        _menuWindow = view.Window;
        _intHelperButton = view.IntHelperButton;
        _threadHelperButton = view.ThreadHelperButton;
        _hideMenuCheckBox = view.HideMenuCheckBox;
        _closeFormButton = view.CloseFormButton;
        _appController = appController;
        
        // Настройка
        _menuWindow.Show();
        _menuWindow.Activate();
        _menuWindow.ToCenterOfScreen();
        _menuWindow.SetCapture("Меню");
        _hideMenuCheckBox.Checked = true;
        _currentChildWindow = null;
        
        // Подпись на события
        _menuWindow.ClosingEvent += WindowOnClosingEvent;
        _intHelperButton.Click += IntHelperButtonOnClick;
        _threadHelperButton.Click += ThreadHelperButtonOnClick;
        _closeFormButton.Click += CloseFormButtonOnClick;
        _appController.ExitEvent += AppControllerOnExitEvent;
    }
    
    #endregion

    #region Private Event Handlers

    private bool WindowOnClosingEvent()
    {
        if (_currentChildWindow != null)
        {  // Есть форма, которую можно закрыть
            _currentChildWindow.Close();
            return true; // Запрет на закрытие основной формы
        }
        return false; // Закрыть основную форму
    }
    
    private void IntHelperButtonOnClick(object sender)
    {
        if (CreateWindowsCore())
        {
            _currentChildWindow = _appController.RunIntHelperDemo(_hideMenuCheckBox.Checked);
        }
    }
    
    private void ThreadHelperButtonOnClick(object sender)
    {
        if (CreateWindowsCore())
        {
            _currentChildWindow = _appController.RunThreadHelperDemo(_hideMenuCheckBox.Checked);
        }
    }
    
    private void CloseFormButtonOnClick(object sender)
    {
        if (_currentChildWindow != null)
        {  // Есть форма, которую можно закрыть
            _currentChildWindow.Close();
        }
        else
        { // Закрыть основную форму
            _menuWindow.Close();
        }
    }
    
    private void AppControllerOnExitEvent(object sender)
    {
        _currentChildWindow = null; // Нет формы, которую можно закрыть
    }

    #endregion
    
    #region Private Methods
    
    private bool CreateWindowsCore()
    {
        if (_currentChildWindow == null) return true;
        _currentChildWindow.Activate();
        _currentChildWindow.ToCenterOfScreen();
        return false; // Предотвратить повторное открытие формы
    }
    
    #endregion
}