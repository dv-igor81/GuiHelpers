using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.MVP.Presenters;

public class MenuPresenter
{
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
    
    public MenuPresenter(
        IMenuView view, 
        IApplicationController appController)
    {
        _menuWindow = view.Window;
        _intHelperButton = view.IntHelperButton;
        _threadHelperButton = view.ThreadHelperButton;
        _hideMenuCheckBox = view.HideMenuCheckBox;
        _closeFormButton = view.CloseFormButton;
        
        _appController = appController;
        
        _currentChildWindow = null;
        
        _menuWindow.SetCapture("Меню");
        _hideMenuCheckBox.Checked = true;
        
        _menuWindow.ClosingEvent += WindowOnClosingEvent;
        _intHelperButton.Click += IntHelperButtonOnClick;
        _threadHelperButton.Click += ThreadHelperButtonOnClick;
        _closeFormButton.Click += CloseFormButtonOnClick;
        
        _appController.ExitEvent += AppControllerOnExitEvent;
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

    private bool CreateWindowsCore()
    {
        if (_currentChildWindow == null) return true;
        _currentChildWindow.Activate();
        _currentChildWindow.ToCenterOfScreen();
        return false; // Предотвратить повторное открытие формы
    }
    
    private void AppControllerOnExitEvent(object sender)
    {
        _currentChildWindow = null; // Нет формы, которую можно закрыть
    }
}