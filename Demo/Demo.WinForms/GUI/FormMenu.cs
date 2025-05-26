using System.Windows.Forms;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.GUI;

public partial class FormMenu : Form, IMenuView
{
    #region IMenuView

    public IWindowWrapper Window {get;}
    
    public IButtonWrapper IntHelperButton { get; }

    public IButtonWrapper ThreadHelperButton { get; }

    public ICheckBoxWrapper HideMenuCheckBox { get; }
    
    public IButtonWrapper CloseFormButton { get; }

    #endregion
    
    #region Constructor
    
    public FormMenu()
    {
        InitializeComponent();

        Init();
        
        Window = new FWindowWrapper(this);
        IntHelperButton = new FButtonWrapper(button_IntHelper);
        HideMenuCheckBox = new FCheckBoxWrapper(checkBox_HideMenu);
        CloseFormButton = new FButtonWrapper(button_CloseForm);
        ThreadHelperButton = new FButtonWrapper(button_ThreadHelper);
    }
    #endregion

    #region Private Methods
    
    private void Init()
    {
        //StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }
    
    #endregion
}