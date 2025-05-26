using GuiHelpers.Demo.MVP.Views;
using GuiHelpers.WPF.Wrappers;
using Wrappers;

namespace Demo.WPF.GUI;

public partial class IntegerDemoWindow : IIntegerDemoView
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
        
        Window = new WWindowWrapper(this);
        DisplayLabel = new WLabelWrapper(LabelDisplay);
        TextLineHelper = new WTextBoxWrapper(TextBoxTextLineHelper);
        TextLineHelper2 = new WTextBoxWrapper(TextBoxTextLineHelper2);
        TextHelperInteger = new WTextBoxWrapper(TextBoxTextHelperInteger);
        TextHelperInteger2 = new WTextBoxWrapper(TextBoxTextHelperInteger2);
        TextHelperInteger3 = new WTextBoxWrapper(TextBoxTextHelperInteger3);
    }
    
    #endregion
}