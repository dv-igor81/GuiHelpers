using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Threading;
using Wrappers;

namespace GuiHelpers.Avalonia.Wrappers;

public delegate void MyAction();

public class AWindowWrapper : IWindowWrapper
{
    #region Private Fields
    
    private readonly Window _window;
    
    private readonly Dispatcher _dispatcher;
    
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
    public bool InvokeRequired => !_dispatcher.CheckAccess();
    
    #endregion
    
    #region Constructor
    
    public AWindowWrapper(Window window)
    {
        _window = window;
        _dispatcher = Dispatcher.UIThread;
        _window.Closing += WindowOnClosing;
    }

    private void WindowOnClosing(object? sender, CancelEventArgs e)
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
        Screen? screen = _window.Screens.Primary;
        if (screen != null)
        {
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;
            _window.Position = new PixelPoint(
                (int)(screenWidth - _window.Width) / 2,
                (int)(screenHeight - _window.Height) / 2);
        }
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void Invoke(Delegate method)
    {
        //_dispatcher.InvokeAsync((Action)method).Wait();
        InvokeHelper helper = new InvokeHelper(method);
        _dispatcher.InvokeAsync(helper.RunMethod).Wait();
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void BeginInvoke(Delegate method)
    {
        //_dispatcher.Post((Action)method);
        InvokeHelper helper = new InvokeHelper(method);
        _dispatcher.Post(helper.RunMethod);
    }
    
    #endregion
}

class InvokeHelper
{
    private readonly Delegate _method;
    public InvokeHelper(Delegate method)
    {
        _method = method;
    }

    public void RunMethod()
    {
        _method.DynamicInvoke();
    }
}