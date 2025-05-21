using System;
using System.Threading;
using SharedUtils;

namespace GuiHelpers.Demo.MVP.Models;

public delegate void DisplayDelegate(string text, GuiColor guiColor);
public delegate void StartStopDelegate(string text);

public class ThreadDemoModel
{
    #region Private Fields
    
    private const string Start = "Старт";
    private const string Stop = "Стоп";
    private const int MaxNumberOfState = 5; 

    private readonly TaskHelper _taskHelper;

    private bool _inWork;
    private int _counter;
    private bool _exitFlag;
    
    #endregion

    #region Events

    public event DisplayDelegate? DisplayEvent;
    
    public event StartStopDelegate? StartStopEvent;
    
    public event Action? ExitEvent;

    #endregion

    #region Constructor

    public ThreadDemoModel()
    {
        _taskHelper = new TaskHelper();
        _inWork = false;
        _exitFlag = false;
    }

    #endregion

    #region Public Methods

    public void Init()
    {
        StartStopEvent?.Invoke(Start);
    }

    public void Exit()
    {
        _exitFlag = true;
        _inWork = false;
    }

    public bool IsRunning()
    {
        return _inWork || _exitFlag;
    }
    
    public void StartStop()
    {
        if (_inWork == false)
        {
            _inWork = true;
            if (_taskHelper.RunTask(Loop) == false)
            {
                _inWork = false;
            }
        }
        else
        {
            _inWork = false;
        }
    }

    #endregion

    #region Private Methods

    private void Loop()
    {
        // 1) Инициализация
        Initialize();
        // 2) Цикл
        while (_inWork)
        {
            Iterate();
        }
        // 3) Завершение
        Finish();
    }

    private void Initialize()
    {
        StartStopEvent?.Invoke(Stop);
        _counter = 0;
        _exitFlag = false;
    }

    private void Iterate()
    {
        switch (_counter)
        {
            case 0:
                DisplayEvent?.Invoke("В работе 1", GuiColor.Blue);
                break;
            case 1:
                DisplayEvent?.Invoke("В работе 2", GuiColor.Red);
                break;
            case 2:
                DisplayEvent?.Invoke("В работе 3", GuiColor.Green);
                break;
            case 3:
                DisplayEvent?.Invoke("В работе 4", GuiColor.White);
                break;
            case 4:
                DisplayEvent?.Invoke("В работе 5", GuiColor.Yellow);
                break;
        }
        _counter++;
        _counter %= MaxNumberOfState;
        Thread.Sleep(500);
    }

    private void Finish()
    {
        StartStopEvent?.Invoke(Start);
        if (_exitFlag)
        {
            DisplayEvent?.Invoke("Завершаю работу...", GuiColor.Lime);
            Thread.Sleep(1500);
            ExitEvent?.Invoke();
            _exitFlag = false;
        }
        else
        {
            DisplayEvent?.Invoke("На паузе", GuiColor.Control);
        }
    }

    #endregion
}