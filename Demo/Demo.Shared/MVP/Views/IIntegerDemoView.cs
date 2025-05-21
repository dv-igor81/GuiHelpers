using Wrappers;

namespace GuiHelpers.Demo.MVP.Views;

public interface IIntegerDemoView
{
    IWindowWrapper Window {get;}
    
    ILabelWrapper DisplayLabel { get; }
    
    ITextBoxWrapper TextLineHelper { get; }
    
    ITextBoxWrapper TextLineHelper2 { get; }
    
    ITextBoxWrapper TextHelperInteger { get; }
    
    ITextBoxWrapper TextHelperInteger2 { get; }
    
    public ITextBoxWrapper TextHelperInteger3 { get; }
}