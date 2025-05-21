namespace GuiHelpers;

/// <summary>
/// Использование метода: SubscribeToEvents(bool subscribe)
/// предотвращает повторное подписывание
/// на одни и те же событие, и повторное
/// отписывание от них.
/// </summary>
public abstract class SubscribeHelper
{
    private bool _isSubscribe;

    /// <summary>
    /// Использование метода
    /// предотвращает повторное подписывание
    /// на одни и те же событие, и повторное
    /// отписывание от них.
    /// </summary>
    /// <param name="subscribe"></param>
    protected void SubscribeToEvents(bool subscribe)
    {
        if (subscribe)
        {
            if (_isSubscribe)
            {
                return;
            }
            _isSubscribe = true;
            Subscribe();
        }
        else
        {
            if (!_isSubscribe)
            {
                return;
            }
            _isSubscribe = false;
            Unsubscribe();
        }
    }

    protected abstract void Subscribe();

    protected abstract void Unsubscribe();
}