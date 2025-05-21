using System.Windows;
using GuiHelpers.Demo.MVP.Views;
using GuiHelpers.WPF.Wrappers;
using Wrappers;

namespace Demo.WPF.GUI;

public partial class ThreadDemoWindow : Window, IThreadDemoView
{
    #region IThreadDemoView
        
    public IWindowWrapper Window { get; }
    
    public IButtonWrapper StartStopButton { get; }
    
    public ILabelWrapper DisplayModeWork { get; }
        
    #endregion
    
    public ThreadDemoWindow()
    {
        InitializeComponent();
        
        Window = new WWindowWrapper(this);
        StartStopButton = new WButtonWrapper(StartStop);
        DisplayModeWork = new WLabelWrapper(DisplayMode);
    }
}