using Wrappers;

namespace GuiHelpers.Demo.MVP.Views;

public interface IMenuView
{
    IWindowWrapper Window {get;}
    
    IButtonWrapper IntHelperButton { get; }
    
    IButtonWrapper ThreadHelperButton { get; }
    
    ICheckBoxWrapper HideMenuCheckBox { get; }
    
    IButtonWrapper CloseFormButton { get; }
}