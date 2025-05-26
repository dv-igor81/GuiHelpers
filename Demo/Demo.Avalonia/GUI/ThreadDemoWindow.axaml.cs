using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GuiHelpers;
using GuiHelpers.Avalonia.Wrappers;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace Demo.Avalonia.GUI;

public partial class ThreadDemoWindow : Window, IThreadDemoView
{
    #region IThreadDemoView
        
    public IWindowWrapper Window { get; }
    
    public IButtonWrapper StartStopButton { get; }
    
    public ILabelWrapper DisplayModeWork { get; }
        
    #endregion
    
    #region Constructor
    
    public ThreadDemoWindow()
    {
        InitializeComponent();
        
        Window = new AWindowWrapper(this);
        StartStopButton = new AButtonWrapper(StartStop);
        DisplayModeWork = new ALabelWrapper(DisplayMode);
    }
    
    #endregion
}