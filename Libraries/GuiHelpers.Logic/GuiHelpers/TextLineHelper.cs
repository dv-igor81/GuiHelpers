using Wrappers;

namespace GuiHelpers;

/// <summary>
/// Помощник для текстовой строки
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class TextLineHelper : BackDelKeys, ITextLineHelper
{
    #region Private Fields

    private ITextBoxWrapper? _textBoxWrapper;
    private readonly int _maxTextLength;

    /// <summary>
    /// Сохранённый текст
    /// </summary>
    private string _savedText;
    
    /// <summary>
    /// Предыдущий текст
    /// </summary>
    private string _previousText;
    
    private int _selStart;
    private int _selLength;
    private int _txtLength;
    
    private string? _leftText;
    private string? _rightText;

    private int _savedSelectionStart;
    
    #endregion
    
    #region Events

    /// <summary>
    ///     Генерируется при потере фокуса элементом управления
    /// </summary>
    public event SenderEventHandler? LostFocusEvent;

    /// <summary>
    ///     Генерируется при получении фокуса элементом управления
    /// </summary>
    public event SenderEventHandler? GotFocusEvent;

    /// <summary>
    ///     Генерируется при изменении текста в текстовом поле
    /// </summary>
    public event ChangeTextEventHandler? ChangeTextEvent;

    #endregion
    
    #region Public Properties

    public string Text
    {
        get => GetText();
        set => SetText(value, value.Length);
    }
    
    public bool IsReadOnly
    {
        get => GetReadOnly();
        set => SetReadOnly(value);
    }
    
    public bool IsEnabled
    {
        get => GetEnabled();
        set => SetEnabled(value);
    }
    
    public bool IsVisible
    {
        get => GetVisible();
        set => SetVisible(value);
    }
    
    public GuiColor BackColor
    {
        get => GetBackColor();
        set => SetBackColor(value);
    }

    public GuiColor ForeColor
    {
        get => GetForeColor();
        set => SetForeColor(value);
    }
    
    #endregion
    
    #region Private Properties

    private char KeyChar => GetKeyChar();

    #endregion
    
    #region Constructors
    
    public TextLineHelper(int maxTextLength)
    {
        _textBoxWrapper = null;
        _maxTextLength = maxTextLength;
        
        _savedText = string.Empty;
        _previousText = string.Empty;
    }
    
    public TextLineHelper(ITextBoxWrapper textBoxWrapper, int maxTextLength)
    {
        _textBoxWrapper = textBoxWrapper;
        _maxTextLength = maxTextLength;
        
        _savedText = string.Empty;
        _previousText = string.Empty;

        _textBoxWrapper.IsReadOnly = false; // Текст нужен, чтобы его записывать
        _textBoxWrapper.BackColor = GuiColor.White;

        _textBoxWrapper.DisconnectCommand(); // Если была связь с предыдущим объектом - разорвать её.
        
        SubscribeToEvents(true);
    }
    
    #endregion
    
    #region Destructor

    ~TextLineHelper()
    {
        SubscribeToEvents(false);
    }

    #endregion
    
    #region Implement SubscribeHelper
        
    protected override void Subscribe()
    {
        if (_textBoxWrapper == null) return;
        _textBoxWrapper.NewSymbolEvent += TextBoxWrapperOnNewSymbolEvent;
        _textBoxWrapper.LostFocusEvent += TextBoxWrapperOnLostFocusEvent;
        _textBoxWrapper.GotFocusEvent += TextBoxWrapperOnGotFocusEvent;
        _textBoxWrapper.DisconnectEvent += TextBoxWrapperOnDisconnectEvent;
    }
    
    protected override void Unsubscribe()
    {
        if (_textBoxWrapper == null) return;
        _textBoxWrapper.NewSymbolEvent -= TextBoxWrapperOnNewSymbolEvent;
        _textBoxWrapper.LostFocusEvent -= TextBoxWrapperOnLostFocusEvent;
        _textBoxWrapper.GotFocusEvent -= TextBoxWrapperOnGotFocusEvent;
        _textBoxWrapper.DisconnectEvent -= TextBoxWrapperOnDisconnectEvent;
    }
        
    #endregion
    
    #region Event Handlers
    
    private void TextBoxWrapperOnNewSymbolEvent()
    {
        if(_textBoxWrapper == null) return;
        _previousText = _savedText;
        SaveTextByKey(KeyChar, _maxTextLength);
        if (CheckSavedText(_savedText))
        { // Проверка завершилась удачно - сохранить текст
            _textBoxWrapper.Text = _savedText;
            _textBoxWrapper.SelectionStart = _savedSelectionStart;
            ChangeTextEvent?.Invoke(this, _savedText);
        }
        else
        { // Проверка завершилась ошибкой - отменить изменения текста
            _savedText = _previousText;
        }
    }
    
    private void TextBoxWrapperOnLostFocusEvent(object sender)
    {
        LostFocusEvent?.Invoke(this); // Передать событие
    }
    
    private void TextBoxWrapperOnGotFocusEvent(object sender)
    {
        GotFocusEvent?.Invoke(this); // Передать событие
    }
    
    /// <summary>
    /// Разорвать связь TextLineHelper и ITextBoxWrapper
    /// </summary>
    /// <param name="sender"></param>
    private void TextBoxWrapperOnDisconnectEvent(object sender)
    {
        SubscribeToEvents(false);
    }
    
    #endregion

    #region Public Methods

    public void SetTextBoxWrapper(ITextBoxWrapper textBoxWrapper)
    {
        _textBoxWrapper = textBoxWrapper;
        _textBoxWrapper.IsReadOnly = false; // Текст нужен, чтобы его записывать
        _textBoxWrapper.BackColor = GuiColor.White;
        _textBoxWrapper.DisconnectCommand(); // Если была связь с предыдущим объектом - разорвать её.
        SubscribeToEvents(true);
    }
    
    public ITextBoxWrapper? TextBoxWrapper(ITextBoxWrapper textBoxWrapper)
    {
        return _textBoxWrapper;
    }

    #endregion

    #region Protected Virtual Methods

    /// <summary>
    /// Проверка текста, в дочерних классах
    /// </summary>
    /// <param name="savedText"></param>
    /// <returns></returns>
    protected virtual bool CheckSavedText(string? savedText)
    {
        if (string.IsNullOrEmpty(savedText))
        {
            return true;
        }
        if (CheckTextForExcludeCharacters(savedText!, "\r\n") == false)
        { // Не допускать символы "\r\n"
            return false;
        }
        return true;
    }

    /// <summary>
    /// Проверить текст. Он не должен содержать символы
    /// из строки characters.
    /// </summary>
    /// <param name="text">Проверяемый текст</param>
    /// <param name="characters">Недопустимые символы</param>
    /// <returns>True - если текст не содержит символов из символов characters</returns>
    protected bool CheckTextForExcludeCharacters(string text, string characters)
    {
        int i;
        for (i = 0; i < text.Length; i++)
        {
            int j;
            for (j = 0; j < characters.Length; j++)
            {
                if (text[i] == characters[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    
    /// <summary>
    /// Проверить текст. Он должен состоять только из
    /// символов строки characters.
    /// </summary>
    /// <param name="text">Проверяемый текст</param>
    /// <param name="characters">Допустимые символы</param>
    /// <returns>True - если текст состоит только из символов characters</returns>
    protected bool CheckTextForValidCharacters(string text, string characters)
    {
        int i;
        for (i = 0; i < text.Length; i++)
        {
            bool find = false;
            int j;
            for (j = 0; j < characters.Length; j++)
            {
                if (text[i] != characters[j]) continue;
                // Найден допустимый символ
                // в текущей позиции текста.
                find = true;
                break;
            }
            if (find == false)
            {
                // в текущей позиции текста присутствует
                // недопустимый символ.
                return false;
            }
        }
        return true;
    }

    #endregion

    #region Protected Methods
    
    protected void SetText(string text, int selectionStart)
    {
        if (_textBoxWrapper == null)
        {
            return;
        }
        _savedText = text;
        _previousText = _savedText;
        _textBoxWrapper.Text = _savedText;
        _savedSelectionStart = selectionStart;
        _textBoxWrapper.SelectionStart = _savedSelectionStart;
    }
    
    #endregion

    #region Private Methods
    
    private bool GetReadOnly()
    {
        return _textBoxWrapper == null || _textBoxWrapper.IsReadOnly;
        // При нулевом объекте - только для чтения
    }

    private void SetReadOnly(bool readOnly)
    {
        if (_textBoxWrapper != null)
        {
            _textBoxWrapper.IsReadOnly = readOnly;
        }
    }

    private bool GetEnabled()
    {
        return _textBoxWrapper == null || _textBoxWrapper.IsEnabled;
    }
    
    private void SetEnabled(bool enabled)
    {
        if (_textBoxWrapper != null)
        {
            _textBoxWrapper.IsEnabled = enabled;
        }
    }

    private bool GetVisible()
    {
        return _textBoxWrapper == null || _textBoxWrapper.IsVisible;
    }
    
    private void SetVisible(bool visible)
    {
        if (_textBoxWrapper != null)
        {
            _textBoxWrapper.IsVisible = visible;
        }
    }

    private GuiColor GetBackColor()
    {
        return _textBoxWrapper != null ? _textBoxWrapper.BackColor : GuiColor.ReadOnlyColor;
    }

    private void SetBackColor(GuiColor color)
    {
        if (_textBoxWrapper != null)
        {
            _textBoxWrapper.BackColor = color;
        }
    }
    
    private GuiColor GetForeColor()
    {
        return _textBoxWrapper != null ? _textBoxWrapper.ForeColor : GuiColor.ReadOnlyColor;
    }

    private void SetForeColor(GuiColor color)
    {
        if (_textBoxWrapper != null)
        {
            _textBoxWrapper.ForeColor = color;
        }
    }

    private char GetKeyChar()
    {
        return _textBoxWrapper?.CurrentSymbol ?? '\0';
    }
    
    /// <summary>
    /// Сохранить текст, в зависимости от нажатой клавиши
    /// </summary>
    /// <param name="key">Нажатая в данный момент клавиша</param>
    /// <param name="maxValueLen">Максимально-допустимое количество символов в строке</param>
    private void SaveTextByKey(char key, int maxValueLen)
    {
        if(_textBoxWrapper == null) return;
        
        _selStart = _textBoxWrapper.SelectionStart;
        _selLength = _textBoxWrapper.SelectionLength;
        _txtLength = _savedText.Length;
        
        if (_txtLength - _selLength >= maxValueLen)
        {
            if (key != BackKey && key != DelKey)
            {
                _savedSelectionStart = _selStart;
                return; // Ограничение длины строки
            }
        }
        
        TextHelper(_savedText, key, _selStart, _selLength,
            out _leftText,
            out _rightText);

        if (key == BackKey || key == DelKey)
        {
            _savedSelectionStart = _leftText?.Length ?? 0;
            _savedText = $"{_leftText}{_rightText}";
        }
        else
        {
            _savedSelectionStart = _selStart + 1;
            _savedText = $"{_leftText}{key}{_rightText}";
        }
    }
    
    /// <summary>
    /// На основе входной строки, нажатой клавиши,
    /// стартовой позиции курсора и числа выделенных
    /// символов формирует две подстроки
    /// </summary>
    /// <param name="text">Текст в текстовом поле</param>
    /// <param name="key">Текущий символ</param>
    /// <param name="selStart">Начальная позиция текста, выбранного в текстовом поле</param>
    /// <param name="selLength">Число знаков, выделенных в текстовом поле</param>
    /// <param name="leftText">Левая подстрока</param>
    /// <param name="rightText">Правая подстрока</param>
    private void TextHelper(
        string? text,
        char key,
        int selStart,
        int selLength,
        out string? leftText,
        out string? rightText)
    {
        if (string.IsNullOrEmpty(text))
        {
            leftText = string.Empty;
            rightText = string.Empty;
            return;
        }
        // _txtLength - длинна текста в текстовом поле
        int txtLength = text!.Length;
        // leftLen - длина части текста в текстовом поле (с первого символа текста до начала выделения)
        int leftLen = selStart;
        // rightLen - длинна текста в текстовом поле 
        // (с первого символа после выделения до последнего)
        int rightLen = txtLength - leftLen;
        
        if (selLength < 0)
        {
            leftLen += selLength;
        }
        else if (selLength > 0)
        {
            selStart += selLength;
            rightLen -= selLength;
        }
        else
        {
            if (key == BackKey)
            {
                leftLen--;
            }
            else if (key == DelKey)
            {
                rightLen--;
                selStart++;
            }
        }
        leftText = leftLen > 0 ? text.Substring(0, leftLen) : string.Empty;
        rightText = rightLen > 0 ? text.Substring(selStart, rightLen) : string.Empty;
    }
    
    private string GetText()
    {
        return _savedText;
    }

    #endregion
}