using GuiHelpers;
using GuiHelpers.Demo.MVP.Views;
using GuiHelpers.WPF.Wrappers;
using Wrappers;

namespace Demo.WPF.GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MenuWindow : IMenuView
{
    #region IMenuView
    
    public IWindowWrapper Window {get;}
    
    public IButtonWrapper IntHelperButton { get; }
    
    public IButtonWrapper ThreadHelperButton { get; }
    
    public ICheckBoxWrapper HideMenuCheckBox { get; }
    
    public IButtonWrapper CloseFormButton { get; }

    #endregion
    
    #region Constructor
    
    public MenuWindow()
    {
        InitializeComponent();

        Window = new WWindowWrapper(this);
        IntHelperButton = new WButtonWrapper(IntHelper);
        ThreadHelperButton = new WButtonWrapper(ThreadHelper);
        HideMenuCheckBox = new WCheckBoxWrapper(HideMenu);
        CloseFormButton = new WButtonWrapper(CloseForm);
    }
    
    #endregion
}