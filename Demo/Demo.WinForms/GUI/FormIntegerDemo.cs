using System.Windows.Forms;
using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.GUI;

public partial class FormIntegerDemo : Form, IIntegerDemoView
{
    #region IIntegerDemoView

    public IWindowWrapper Window { get; }
    
    public ILabelWrapper DisplayLabel { get; }
    
    public ITextBoxWrapper TextLineHelper { get; }
    
    public ITextBoxWrapper TextLineHelper2 { get; }
    
    public ITextBoxWrapper TextHelperInteger { get; }
    
    public ITextBoxWrapper TextHelperInteger2 { get; }
    
    public ITextBoxWrapper TextHelperInteger3 { get; }

    #endregion

    #region Constructor

    public FormIntegerDemo()
    {
        InitializeComponent();
        Init();

        Window = new FWindowWrapper(this);
        DisplayLabel = new FLabelWrapper(label_Display);
        TextLineHelper = new FTextBoxWrapper(textBox_TextLineHelper);
        TextLineHelper2 = new FTextBoxWrapper(textBox_TextLineHelper2);
        TextHelperInteger = new FTextBoxWrapper(textBox_TextHelperInteger);
        TextHelperInteger2 = new FTextBoxWrapper(textBox_TextHelperInteger2);
        TextHelperInteger3 = new FTextBoxWrapper(textBox_TextHelperInteger3);
    }

    #endregion

    #region Private Methods

    private void Init()
    {
        //StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        label_Display.Text = string.Empty;
    }

    #endregion
}