namespace GuiHelpers;

public abstract class BackDelKeys : SubscribeHelper
{
    protected BackDelKeys()
    {
        BackKey = '\b';
        DelKey = (char)(BackKey - 1);
    }

    protected char BackKey { get; }

    protected char DelKey { get; }
}