using Avalonia.Controls;
using GuiHelpers.Avalonia.Wrappers;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace Demo.Avalonia.GUI;

public partial class IntegerDemoWindow : Window, IIntegerDemoView
{
    #region IDemoView

    public IWindowWrapper Window { get; }
    
    public ILabelWrapper DisplayLabel { get; }
    
    public ITextBoxWrapper TextLineHelper { get; }
    
    public ITextBoxWrapper TextLineHelper2 { get; }
    
    public ITextBoxWrapper TextHelperInteger { get; }
    
    public ITextBoxWrapper TextHelperInteger2 { get; }
    
    public ITextBoxWrapper TextHelperInteger3 { get; }

    #endregion
    
    #region Constructor
    
    public IntegerDemoWindow()
    {
        InitializeComponent();
        
        Window = new AWindowWrapper(this);
        DisplayLabel = new ALabelWrapper(LabelDisplay);
        TextLineHelper = new ATextBoxWrapper(TextBoxTextLineHelper);
        TextLineHelper2 = new ATextBoxWrapper(TextBoxTextLineHelper2);
        TextHelperInteger = new ATextBoxWrapper(TextBoxTextHelperInteger);
        TextHelperInteger2 = new ATextBoxWrapper(TextBoxTextHelperInteger2);
        TextHelperInteger3 = new ATextBoxWrapper(TextBoxTextHelperInteger3);
    }
    
    #endregion
}