using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Shapes;
using Wrappers;

namespace GuiHelpers.WPF.Wrappers;

public class WWindowWrapper : IWindowWrapper
{
    #region Private Fields
    
    private readonly Window _window;
    
    #endregion
    
    #region Events
    
    /// <summary>
    ///     Генерируется при попытке закрыть окно.
    /// </summary>
    public event WindowClosingEventHandler? ClosingEvent;
    
    #endregion
    
    #region Properties
    
    /// <summary>
    ///     Получает значение, показывающее, следует ли
    ///     вызывающему оператору обращаться к методу
    ///     invoke во время вызовов метода из элемента
    ///     управления, так как вызывающий оператор
    ///     находится не в том потоке, в котором был
    ///     создан элемент управления.
    /// </summary>
    public bool InvokeRequired => !_window.Dispatcher.CheckAccess();
    
    #endregion
    
    #region Constructor
    
    public WWindowWrapper(Window window)
    {
        _window = window;
        _window.Closing += WindowOnClosing;
    }

    private void WindowOnClosing(object sender, CancelEventArgs e)
    {
        if (ClosingEvent == null)
        {
            return;
        }
        bool cancel = ClosingEvent();
        e.Cancel = cancel;
    }

    #endregion
    
    #region Public Methods
    
    public void SetCapture(string text)
    {
        _window.Title = text;
    }

    public void Hide()
    {
        _window.Hide();
    }

    public void Show()
    {
        _window.Show();
    }

    public void Close()
    {
        _window.Close();
    }
    
    public void Activate()
    {
        _window.Activate();
        if (_window.WindowState == WindowState.Minimized)
        {
            _window.WindowState = WindowState.Normal;
        }
        

    }
    
    /// <summary>
    /// Переместить окно в центр экрана
    /// </summary>
    public void ToCenterOfScreen()
    {
        // Нужны ссылки на сборки:
        // 1) System.Windows.Forms;
        // 2) System.Drawing.
        Screen screen = Screen.PrimaryScreen;
        System.Drawing.Rectangle screenBounds = screen.WorkingArea;
        _window.Left = (screenBounds.Width - _window.Width) / 2; 
        _window.Top = (screenBounds.Height - _window.Height) / 2;
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void Invoke(Delegate method)
    {
        _window.Dispatcher.Invoke(method);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void BeginInvoke(Delegate method)
    {
        _window.Dispatcher.BeginInvoke(method);
    }
    
    #endregion
}