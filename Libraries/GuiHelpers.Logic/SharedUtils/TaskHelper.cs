using System;
using System.Threading.Tasks;

namespace SharedUtils;

/// <summary>
///     Для выполнения метода асинхронно.
///     Один экземпляр класса обеспечивает
///     одновременное выполнение только одного метода.
/// </summary>
public class TaskHelper
{
    #region Private Types

    private abstract class TypedActionHelpBase(Action? endedMethod)
    {
        /// <summary>
        ///     Обёртка, над основным методом, чтобы вызвать
        ///     метод, сигнализирующий о завершении основного
        ///     метода, если сигнализирующий метод определён.
        /// </summary>
        public void ExecuteMethodWrapper()
        {
            ExecuteMethod();
            endedMethod?.Invoke();
        }

        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        protected abstract void ExecuteMethod();
    }

    private class TypedActionHelp(Action method, Action? endedMethod) : TypedActionHelpBase(endedMethod)
    {
        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        private readonly Action _method = method;

        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        protected override void ExecuteMethod()
        {
            _method();
        }
    }

    private class TypedActionHelp<T>(Action<T> method, T paramIn, Action? endedMethod)
        : TypedActionHelpBase(endedMethod)
    {
        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        private readonly Action<T> _method = method;

        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        protected override void ExecuteMethod()
        {
            _method(paramIn);
        }
    }

    private class TypedActionHelp<T1, T2> : TypedActionHelpBase
    {
        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        private readonly Action<T1, T2> _method;

        private readonly T1 _paramIn1;
        private readonly T2 _paramIn2;

        public TypedActionHelp(Action<T1, T2> method, T1 paramIn1, T2 paramIn2, Action? endedMethod)
            : base(endedMethod)
        {
            _method = method;
            _paramIn1 = paramIn1;
            _paramIn2 = paramIn2;
        }

        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        protected override void ExecuteMethod()
        {
            _method(_paramIn1, _paramIn2);
        }
    }

    private class TypedActionHelp<T1, T2, T3> : TypedActionHelpBase
    {
        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        private readonly Action<T1, T2, T3> _method;

        private readonly T1 _paramIn1;
        private readonly T2 _paramIn2;
        private readonly T3 _paramIn3;

        public TypedActionHelp(Action<T1, T2, T3> method, T1 paramIn1, T2 paramIn2, T3 paramIn3, Action? endedMethod)
            : base(endedMethod)
        {
            _method = method;
            _paramIn1 = paramIn1;
            _paramIn2 = paramIn2;
            _paramIn3 = paramIn3;
        }

        /// <summary>
        ///     Основной метод, вызываемый во вторичном потоке
        /// </summary>
        protected override void ExecuteMethod()
        {
            _method(_paramIn1, _paramIn2, _paramIn3);
        }
    }

    #endregion

    #region Private Fields

    private TypedActionHelpBase _typedAction = null!;

    private bool _taskInWork;

    #endregion

    #region Private Methods

    private void RunTaskHelper()
    {
        _taskInWork = true;
        Task.Factory.StartNew(ExecuteMethodWrapper);
    }

    /// <summary>
    ///     Метод, выполняющийся асинхронно.
    ///     Обёртка, над основным методом, чтобы установить
    ///     флаг _taskInWork, после его выполнения.
    /// </summary>
    private void ExecuteMethodWrapper()
    {
        BeginInvokeWrapper();
    }

    private void BeginInvokeWrapper()
    {
        _typedAction.ExecuteMethodWrapper();
        _taskInWork = false;
    }

    #endregion

    #region Public Methods

    public bool RunTask(Action runMethod, Action? endMethod = null)
    {
        if (_taskInWork) return false;
        _typedAction = new TypedActionHelp(runMethod, endMethod);
        RunTaskHelper();
        return true;
    }

    public bool RunTask<T>(Action<T> runMethod, T p, Action? endMethod = null)
    {
        if (_taskInWork) return false;
        _typedAction = new TypedActionHelp<T>(runMethod, p, endMethod);
        RunTaskHelper();
        return true;
    }

    public bool RunTask<T1, T2>(Action<T1, T2> runMethod, T1 p1, T2 p2, Action? endMethod = null)
    {
        if (_taskInWork) return false;
        _typedAction = new TypedActionHelp<T1, T2>(runMethod, p1, p2, endMethod);
        RunTaskHelper();
        return true;
    }

    public bool RunTask<T1, T2, T3>(Action<T1, T2, T3> runMethod, T1 p1, T2 p2, T3 p3, Action? endMethod = null)
    {
        if (_taskInWork) return false;
        _typedAction = new TypedActionHelp<T1, T2, T3>(runMethod, p1, p2, p3, endMethod);
        RunTaskHelper();
        return true;
    }

    #endregion
}