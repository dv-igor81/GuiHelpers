using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuiHelpers;

namespace Wrappers;

public class FWindowWrapper : IWindowWrapper
{
    #region Private Fields
    
    private readonly Form _form;
    
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
    public bool InvokeRequired => _form.InvokeRequired;
    
    #endregion
    
    #region Constructor
    
    public FWindowWrapper(Form form)
    {
        _form = form;
        
        _form.Closing += FormOnClosing;
    }

    private void FormOnClosing(object sender, CancelEventArgs e)
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
        _form.Text = text;
    }

    public void Hide()
    {
        _form.Hide();
    }

    public void Show()
    {
        _form.Show();
    }

    public void Close()
    {
        _form.Close();
    }

    public void Activate()
    {
        _form.Activate();
        
        if (_form.WindowState == FormWindowState.Minimized)
        {
            _form.WindowState = FormWindowState.Normal;
        }
    }

    /// <summary>
    /// Переместить окно в центр экрана
    /// </summary>
    public void ToCenterOfScreen()
    {
        Screen screen = Screen.PrimaryScreen;
        Rectangle screenBounds = screen.WorkingArea;
        _form.Location = new Point(
            (screenBounds.Width - _form.Width) / 2, 
            (screenBounds.Height - _form.Height) / 2);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void Invoke(Delegate method)
    {
        _form.Invoke(method);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public void BeginInvoke(Delegate method)
    {
        _form.BeginInvoke(method);
    }
    
    #endregion
}