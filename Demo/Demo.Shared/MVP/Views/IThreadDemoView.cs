using Wrappers;

namespace GuiHelpers.Demo.MVP.Views;

public interface IThreadDemoView
{
    IWindowWrapper Window { get; }

    IButtonWrapper StartStopButton { get; }
    
    ILabelWrapper DisplayModeWork { get; }
}