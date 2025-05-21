using System;
using Wrappers;

namespace GuiHelpers;

/// <summary>
///     Оптимизированная версия класса
///     SimpleIntegerTextHelper
/// </summary>
public class TextHelperInteger : ValidateTextHelper, ITextHelperInteger
{
    #region Private Fields

    /// <summary>
    ///     Минимально-допустимое число
    /// </summary>
    private readonly int _minValue;

    /// <summary>
    ///     Максимально-допустимое число
    /// </summary>
    private readonly int _maxValue;

    /// <summary>
    ///     Длина строки минимально-допустимого числа
    /// </summary>
    private readonly int _maxLengthMin;

    /// <summary>
    ///     Длина строки максимально-допустимого числа
    /// </summary>
    private readonly int _maxLengthMax;
    
    private int _integer;
    
    #endregion

    #region Public Properties

    public int Integer
    {
        get => _integer; 
        set => SetInteger(value);
    }

    #endregion

    #region Constructor
    
    public TextHelperInteger(
        int min, int max,
        bool isReadOnly = false)
        : base(GetMaxTextLength(min, max))
    {
        // Защита от ошибки, когда min и max поменялись значениями (перепутаны)
        _minValue = Math.Min(min, max);
        _maxValue = Math.Max(min, max);
        
        _maxLengthMin = _minValue.ToString().Length;
        _maxLengthMax = _maxValue.ToString().Length;

        IsReadOnly = isReadOnly;

        LostFocusEvent += OnLostFocusEvent;
    }
    
    public TextHelperInteger(
        ITextBoxWrapper textBoxWrapper,
        int min, int max,
        bool isReadOnly = false)
        : base(textBoxWrapper, GetMaxTextLength(min, max))
    {
        // Защита от ошибки, когда min и max поменялись значениями (перепутаны)
        _minValue = Math.Min(min, max);
        _maxValue = Math.Max(min, max);
        
        _maxLengthMin = _minValue.ToString().Length;
        _maxLengthMax = _maxValue.ToString().Length;

        IsReadOnly = isReadOnly;

        LostFocusEvent += OnLostFocusEvent;
    }
    
    #endregion

    #region Event Handler

    private void OnLostFocusEvent(object sender)
    {
        if (!CanBeAdjusted) return;
        SetText(AdjustedText, AdjustedText.Length);
        IsValid = true;
    }

    #endregion

    #region Protected Override Methods

    /// <summary>
    ///     Проверка текста, в дочерних классах
    /// </summary>
    /// <param name="savedText"></param>
    /// <returns></returns>
    protected override bool CheckSavedText(string? savedText)
    {
        if (string.IsNullOrEmpty(savedText))
        {
            IsValid = false; // Пустая строка не является допустимым числом
            CanBeAdjusted = false; // Не может быть скорректировано или не нуждается в этом
            return true; // Разрешить изменение текста
        }
        if (CheckTextForValidCharacters(savedText!, "+-0123456789") == false)
        {
            return false; // Не изменять текст
        }
        bool tryParse = int.TryParse(savedText, out var value);
        if (tryParse == false)
        {
            if (savedText == "-" && _minValue < 0)
            {
                IsValid = false; // Знаки "-" и "+" не является допустимым числом
                CanBeAdjusted = false; // Не может быть скорректировано или не нуждается в этом
                return true; // Разрешить изменение текста
            }
            if (savedText == "+" && _maxValue >= 0)
            {
                IsValid = false; // Знаки "-" и "+" не является допустимым числом
                CanBeAdjusted = false; // Не может быть скорректировано или не нуждается в этом
                return true; // Разрешить изменение текста
            }
            return false; // Не изменять текст
        }
        if (savedText![0] == '-')
        {
            if (savedText.Length > _maxLengthMin) 
            {
                return false; // Не изменять текст
            }
        }
        else if (savedText[0] == '+')
        {
            if (savedText.Length > _maxLengthMax + 1) 
            {
                return false; // Не изменять текст
            }
        }
        else
        {
            if (savedText.Length > _maxLengthMax) 
            {
                return false; // Не изменять текст
            }
        }
        if (value < _minValue)
        {
            if (value >= 0)
            {
                IsValid = false; // Промежуточное состояние
                value = _minValue;
                _integer = value;
                AdjustedText = $"{_integer}";
                CanBeAdjusted = true; // Должно быть скорректировано, при потере фокуса ввода
                return true; // Разрешить изменение текста
            }
            return false; // Не изменять текст
        }
        if (value > _maxValue)
        {
            if (value <= 0)
            {
                IsValid = false; // Промежуточное состояние
                value = _maxValue;
                _integer = value;
                AdjustedText = $"{_integer}";
                CanBeAdjusted = true; // Должно быть скорректировано, при потере фокуса ввода
                return true; // Разрешить изменение текста
            }
            return false; // Не изменять текст
        }
        
        _integer = value;
        AdjustedText = $"{_integer}";
        CanBeAdjusted = AdjustedText != savedText;
        IsValid = true;
        return true;
    }

    #endregion

    #region Private Methods

    private void SetInteger(int integer)
    {
        if (integer < _minValue || integer > _maxValue)
        {
            return;
        }
        _integer = integer;
        AdjustedText = $"{integer}";
        SetText(AdjustedText, AdjustedText.Length);
        IsValid = true;
    }
    
    #endregion

    #region Private Static Methods

    private static int GetMaxTextLength(int min, int max)
    {
        var maxLengthMin = min.ToString().Length;
        var maxLengthMax = max.ToString().Length + 1; // Знак '+' 
        var maxLength = Math.Max(maxLengthMin, maxLengthMax);
        return maxLength;
    }

    #endregion
}