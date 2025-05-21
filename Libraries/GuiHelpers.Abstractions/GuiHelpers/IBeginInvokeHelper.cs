using System;

namespace GuiHelpers;

/// <summary>
///     Для вызова методов в контексте потока, создавшего элементы управления
/// </summary>
public interface IBeginInvokeHelper
{
    /// <summary>
    ///     Блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    void Invoke(Delegate method);

    /// <summary>
    ///     Не блокировать вызывающий поток
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    void BeginInvoke(Delegate method);

    /// <summary>
    ///     Получает значение, показывающее, следует ли
    ///     вызывающему оператору обращаться к методу
    ///     invoke во время вызовов метода из элемента
    ///     управления, так как вызывающий оператор
    ///     находится не в том потоке, в котором был
    ///     создан элемент управления.
    /// </summary>
    bool InvokeRequired { get; }
}