using GuiHelpers.Demo.MVP.Views;
using System.Windows.Forms;
using Wrappers;

namespace GuiHelpers.Demo.GUI;

public partial class FormThreadDemo : Form, IThreadDemoView
{
    #region IThreadDemoView
        
    public IWindowWrapper Window { get; }
    
    public IButtonWrapper StartStopButton { get; }
    
    public ILabelWrapper DisplayModeWork { get; }
        
    #endregion
        
    public FormThreadDemo()
    {
        InitializeComponent();
        Init();
            
        Window = new FWindowWrapper(this);
        StartStopButton = new FButtonWrapper(button_StartStop);
        DisplayModeWork = new FLabelWrapper(label_DisplayModeWork);
    }
        
    #region Private Methods

    private void Init()
    {
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }

    #endregion
}