using Avalonia.Controls;
using GuiHelpers;
using GuiHelpers.Avalonia.Wrappers;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace Demo.Avalonia.GUI;

public partial class MenuWindow : Window, IMenuView
{
    #region IMenuView

    public IWindowWrapper Window { get; }

    public IButtonWrapper IntHelperButton { get; }

    public IButtonWrapper ThreadHelperButton { get; }

    public ICheckBoxWrapper HideMenuCheckBox { get; }

    public IButtonWrapper CloseFormButton { get; }

    #endregion

    #region Constructor
    
    public MenuWindow()
    {
        InitializeComponent();
        
        Window = new AWindowWrapper(this);
        IntHelperButton = new AButtonWrapper(IntHelper);
        ThreadHelperButton = new AButtonWrapper(ThreadHelper);
        HideMenuCheckBox = new ACheckBoxWrapper(HideMenu);
        CloseFormButton = new AButtonWrapper(CloseForm);
    }
    
    #endregion
}