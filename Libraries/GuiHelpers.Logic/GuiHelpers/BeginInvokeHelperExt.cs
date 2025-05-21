using System;

namespace GuiHelpers;

public static class BeginInvokeHelperExt
{
    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    public static void InvokeEx(this IBeginInvokeHelper control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
            return;
        }

        action();
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p"></param>
    public static void InvokeEx<T>(this IBeginInvokeHelper control, Action<T> action, T p)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T>(action, p);
            control.Invoke((Action)typedAction.ExecuteMethod);
            return;
        }

        action(p);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public static void InvokeEx<T1, T2>(this IBeginInvokeHelper control, Action<T1, T2> action, T1 p1, T2 p2)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2>(action, p1, p2);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public static void InvokeEx<T1, T2, T3>(this IBeginInvokeHelper control, Action<T1, T2, T3> action, T1 p1, T2 p2,
        T3 p3)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3>(action, p1, p2, p3);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public static void InvokeEx<T1, T2, T3, T4>(this IBeginInvokeHelper control, Action<T1, T2, T3, T4> action, T1 p1,
        T2 p2, T3 p3, T4 p4)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4>(action, p1, p2, p3, p4);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public static void InvokeEx<T1, T2, T3, T4, T5>(this IBeginInvokeHelper control, Action<T1, T2, T3, T4, T5> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5>(action, p1, p2, p3, p4, p5);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    public static void InvokeEx<T1, T2, T3, T4, T5, T6>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6> action, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5, T6>(action, p1, p2, p3, p4, p5, p6);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    public static void InvokeEx<T1, T2, T3, T4, T5, T6, T7>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6, T7> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5, T6, T7>(action, p1, p2, p3, p4, p5, p6, p7);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6, p7);
    }

    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    public static void InvokeEx<T1, T2, T3, T4, T5, T6, T7, T8>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
    {
        if (control.InvokeRequired)
        {
            var typedAction =
                new TypedActionHelp<T1, T2, T3, T4, T5, T6, T7, T8>(action, p1, p2, p3, p4, p5, p6, p7, p8);
            control.Invoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6, p7, p8);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    public static void BeginInvokeEx(this IBeginInvokeHelper control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.BeginInvoke(action);
            return;
        }

        action();
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p"></param>
    public static void BeginInvokeEx<T>(this IBeginInvokeHelper control, Action<T> action, T p)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T>(action, p);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    public static void BeginInvokeEx<T1, T2>(this IBeginInvokeHelper control, Action<T1, T2> action, T1 p1, T2 p2)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2>(action, p1, p2);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    public static void BeginInvokeEx<T1, T2, T3>(this IBeginInvokeHelper control, Action<T1, T2, T3> action, T1 p1,
        T2 p2, T3 p3)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3>(action, p1, p2, p3);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    public static void BeginInvokeEx<T1, T2, T3, T4>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4> action,
        T1 p1, T2 p2, T3 p3, T4 p4)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4>(action, p1, p2, p3, p4);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    public static void BeginInvokeEx<T1, T2, T3, T4, T5>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5>(action, p1, p2, p3, p4, p5);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    public static void BeginInvokeEx<T1, T2, T3, T4, T5, T6>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5, T6>(action, p1, p2, p3, p4, p5, p6);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    public static void BeginInvokeEx<T1, T2, T3, T4, T5, T6, T7>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6, T7> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
    {
        if (control.InvokeRequired)
        {
            var typedAction = new TypedActionHelp<T1, T2, T3, T4, T5, T6, T7>(action, p1, p2, p3, p4, p5, p6, p7);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6, p7);
    }

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="control"></param>
    /// <param name="action"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
    public static void BeginInvokeEx<T1, T2, T3, T4, T5, T6, T7, T8>(this IBeginInvokeHelper control,
        Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
        T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
    {
        if (control.InvokeRequired)
        {
            var typedAction =
                new TypedActionHelp<T1, T2, T3, T4, T5, T6, T7, T8>(action, p1, p2, p3, p4, p5, p6, p7, p8);
            control.BeginInvoke(typedAction.ExecuteMethod);
            return;
        }

        action(p1, p2, p3, p4, p5, p6, p7, p8);
    }

    private class TypedActionHelp<T>
    {
        private readonly Action<T> _method;
        private readonly T _p;

        public TypedActionHelp(Action<T> method, T p)
        {
            _method = method;
            _p = p;
        }

        public void ExecuteMethod()
        {
            if (_p != null)
            {
                _method.Invoke(_p);
            }
        }
    }

    private class TypedActionHelp<T1, T2>
    {
        private readonly Action<T1, T2> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;

        public TypedActionHelp(Action<T1, T2> method, T1 p1, T2 p2)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2);
        }
    }

    private class TypedActionHelp<T1, T2, T3>
    {
        private readonly Action<T1, T2, T3> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;

        public TypedActionHelp(Action<T1, T2, T3> method, T1 p1, T2 p2, T3 p3)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3);
        }
    }

    private class TypedActionHelp<T1, T2, T3, T4>
    {
        private readonly Action<T1, T2, T3, T4> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;
        private readonly T4 _p4;

        public TypedActionHelp(Action<T1, T2, T3, T4> method, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3, _p4);
        }
    }

    private class TypedActionHelp<T1, T2, T3, T4, T5>
    {
        private readonly Action<T1, T2, T3, T4, T5> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;
        private readonly T4 _p4;
        private readonly T5 _p5;

        public TypedActionHelp(Action<T1, T2, T3, T4, T5> method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
            _p5 = p5;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3, _p4, _p5);
        }
    }

    private class TypedActionHelp<T1, T2, T3, T4, T5, T6>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;
        private readonly T4 _p4;
        private readonly T5 _p5;
        private readonly T6 _p6;

        public TypedActionHelp(Action<T1, T2, T3, T4, T5, T6> method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
            _p5 = p5;
            _p6 = p6;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3, _p4, _p5, _p6);
        }
    }

    private class TypedActionHelp<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;
        private readonly T4 _p4;
        private readonly T5 _p5;
        private readonly T6 _p6;
        private readonly T7 _p7;

        public TypedActionHelp(Action<T1, T2, T3, T4, T5, T6, T7> method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6,
            T7 p7)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
            _p5 = p5;
            _p6 = p6;
            _p7 = p7;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3, _p4, _p5, _p6, _p7);
        }
    }

    private class TypedActionHelp<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> _method;
        private readonly T1 _p1;
        private readonly T2 _p2;
        private readonly T3 _p3;
        private readonly T4 _p4;
        private readonly T5 _p5;
        private readonly T6 _p6;
        private readonly T7 _p7;
        private readonly T8 _p8;

        public TypedActionHelp(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6,
            T7 p7, T8 p8)
        {
            _method = method;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
            _p5 = p5;
            _p6 = p6;
            _p7 = p7;
            _p8 = p8;
        }

        public void ExecuteMethod()
        {
            _method.Invoke(_p1, _p2, _p3, _p4, _p5, _p6, _p7, _p8);
        }
    }
}