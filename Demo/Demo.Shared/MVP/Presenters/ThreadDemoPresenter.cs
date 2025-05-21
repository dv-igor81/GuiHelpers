using GuiHelpers.Demo.MVP.Models;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.MVP.Presenters;

public class ThreadDemoPresenter
{
    #region Private Fields

    private readonly IWindowWrapper _window;
    private readonly IButtonWrapper _startStopButton;
    private readonly ILabelWrapper _displayModeWork;

    private readonly ThreadDemoModel _model;
    private readonly IApplicationController _appController;

    #endregion

    #region Constructor

    public ThreadDemoPresenter(
        IThreadDemoView view,
        ThreadDemoModel model,
        IApplicationController appController)
    {
        // Присвоения
        _window = view.Window;
        _startStopButton = view.StartStopButton;
        _displayModeWork = view.DisplayModeWork;
        _model = model;
        _appController = appController;
        // Вызов методов
        _window.SetCapture("Демонстрация асинхронности");
        _displayModeWork.Text = "*** Режим работы ***";
        // Подписка на события
        _window.ClosingEvent += WindowOnClosingEvent;
        _startStopButton.Click += StartStopButtonOnClick;
        _model.DisplayEvent += ModelOnDisplayEvent;
        _model.StartStopEvent += ModelOnStartStopEvent;
        _model.ExitEvent += ModelOnExitEvent;
        // Инициализация
        _model.Init();
    }

    #endregion

    #region Private EventHandler

    /// <summary>
    ///     Возврат: false - разрешить закрытие формы (окна),
    ///     true - запретить.
    /// </summary>
    private bool WindowOnClosingEvent()
    {
        if (_model.IsRunning() == false)
        {
            _appController.Exit();
            return false;
        }

        _model.Exit(); // Закрыть окно после завершения задачи
        return true; // Отменить закрытие формы
    }

    /// <summary>
    ///     Закрыть окно, после завершения задачи в модели
    /// </summary>
    private void ModelOnExitEvent()
    {
        _window.BeginInvokeEx(ExitEventHandler);
    }

    private void StartStopButtonOnClick(object sender)
    {
        _model.StartStop();
    }

    private void ModelOnDisplayEvent(string text, GuiColor guiColor)
    {
        _window.BeginInvokeEx(DisplayEventHandler, text, guiColor);
    }

    private void ModelOnStartStopEvent(string text)
    {
        _window.BeginInvokeEx(StartStopEventHandler, text);
    }

    #endregion

    #region Private Methods

    private void DisplayEventHandler(string text, GuiColor guiColor)
    {
        _displayModeWork.Text = text;
        _displayModeWork.BackColor = guiColor;
    }

    private void StartStopEventHandler(string text)
    {
        _startStopButton.Text = text;
    }

    /// <summary>
    ///     Закрыть окно, после завершения задачи в модели
    /// </summary>
    private void ExitEventHandler()
    {
        _appController.Exit();
        _window.Close();
    }

    #endregion
}