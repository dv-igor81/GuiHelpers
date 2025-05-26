using GuiHelpers.Demo.MVP.Views;
using Wrappers;

namespace GuiHelpers.Demo.MVP.Presenters;

public class IntegerDemoPresenter
{
    #region Private Fields

    private readonly IWindowWrapper _window;
    private readonly ILabelWrapper _displayLabel;
    
    // ReSharper disable once NotAccessedField.Local
    private readonly ITextLineHelper _textLineHelper;
    // ReSharper disable once NotAccessedField.Local
    private readonly ITextLineHelper _textLineHelper2;
    // ReSharper disable once NotAccessedField.Local
    private readonly ITextHelperInteger _textHelperInteger;
    // ReSharper disable once NotAccessedField.Local
    private readonly ITextHelperInteger _textHelperInteger2;
    // ReSharper disable once NotAccessedField.Local
    private readonly ITextHelperInteger _textHelperInteger3;
    
    private readonly IApplicationController _appController;

    #endregion
    
    #region Constructor
    
    public IntegerDemoPresenter(
        IIntegerDemoView view, 
        IApplicationController appController)
    {
        _window = view.Window;
        _displayLabel = view.DisplayLabel;
        _textLineHelper = CreateTextLineHelper(view.TextLineHelper, 10);
        _textLineHelper2 = CreateTextLineHelper(view.TextLineHelper2, 5);
        
        _textHelperInteger = CreateTextHelperInteger(view.TextHelperInteger,-128, 128, 55);
        _textHelperInteger2 = CreateTextHelperInteger(view.TextHelperInteger2,50, 256, 65);
        _textHelperInteger3 = CreateTextHelperInteger(view.TextHelperInteger3,-256, -50, -65);
        
        _appController = appController;
        
        _window.SetCapture("Демонстрация ввода чисел");
        
        _window.ClosingEvent += WindowOnClosingEvent;
    }
    
    #endregion
    
    private ITextLineHelper CreateTextLineHelper(ITextBoxWrapper wrapper, int maxTextLength)
    {
        ITextLineHelper textLineHelper = new TextLineHelper(wrapper, maxTextLength);
        textLineHelper.ChangeTextEvent += TextLineHelperOnChangeTextEvent;
        textLineHelper.GotFocusEvent += TextLineHelperOnGotFocusEvent;
        return textLineHelper;
    }
    
    private ITextHelperInteger CreateTextHelperInteger(ITextBoxWrapper wrapper, int min, int max, int def)
    {
        ITextHelperInteger textHelperInteger = new TextHelperInteger(min, max);
        textHelperInteger.SetTextBoxWrapper(wrapper);
        //textHelperInteger.IsReadOnly = true;
        textHelperInteger.ChangeTextEvent += TextHelperIntegerOnChangeTextEvent;
        textHelperInteger.GotFocusEvent += TextHelperIntegerOnGotFocusEvent;
        if (min <= def && def <= max)
        {
            textHelperInteger.Integer = def;
        }
        else
        {
            textHelperInteger.IsValid = false;
        }
        return textHelperInteger;
    }

    private void TextHelperIntegerOnGotFocusEvent(object sender)
    {
        if (sender is ITextHelperInteger helper)
        {
            _displayLabel.Text = @$"IsValid: {helper.IsValid}; Integer: {helper.Integer}; text: {helper.Text}";
        }
    }

    private void TextHelperIntegerOnChangeTextEvent(object sender, string text)
    {
        if (sender is ITextHelperInteger helper)
        {
            _displayLabel.Text = @$"IsValid: {helper.IsValid}; Integer: {helper.Integer}; text: {helper.Text}";
        }
    }

    private void TextLineHelperOnGotFocusEvent(object sender)
    {
        if (sender is ITextProperty property)
        {
            _displayLabel.Text = property.Text;
        }
    }

    private void TextLineHelperOnChangeTextEvent(object sender, string text)
    {
        _displayLabel.Text = text;
    }

    /// <summary>
    /// Возврат: false - разрешить закрытие формы (окна),
    /// true - запретить.
    /// </summary>
    bool WindowOnClosingEvent()
    {
        _appController.Exit();
        return false;
    }
}