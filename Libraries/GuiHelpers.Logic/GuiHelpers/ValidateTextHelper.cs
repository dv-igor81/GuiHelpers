using Wrappers;

namespace GuiHelpers;

public class ValidateTextHelper : TextLineHelper
{
    #region Private Fields
    
    private bool _isValid;
    
    #endregion

    #region Protected Fields

    /// <summary>
    ///     True - значение может быть скорректировано
    /// </summary>
    protected bool CanBeAdjusted;

    /// <summary>
    ///     Скорректированный текст, для применения при потере фокуса
    /// </summary>
    protected string AdjustedText = string.Empty;

    #endregion
    
    #region Constructors
    
    protected ValidateTextHelper(int maxTextLength) 
        : base(maxTextLength)
    {
    }
    
    protected ValidateTextHelper(ITextBoxWrapper textBoxWrapper, int maxTextLength) 
        : base(textBoxWrapper, maxTextLength)
    {
    }
    
    #endregion
    
    #region Public Properties
    
    public bool IsValid
    {
        get => _isValid;
        set
        {
            _isValid = value;
            DisplayColor();
        }
    }

    public new bool IsReadOnly
    {
        get => base.IsReadOnly;
        set
        {
            base.IsReadOnly = value;
            DisplayColor();
        }
    }
    
    #endregion
    
    #region Private Methods

    private void DisplayColor()
    {
        var mainColor = base.IsReadOnly ? GuiColor.ReadOnlyColor : GuiColor.White;
        var errorColor = base.IsReadOnly ? GuiColor.ReadOnlyColor : GuiColor.Red;
        var backColor = _isValid ? mainColor : errorColor;
        // Цвет для текстового поля ввода
        BackColor = backColor;
    }

    #endregion
}