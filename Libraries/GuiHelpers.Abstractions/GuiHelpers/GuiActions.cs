namespace GuiHelpers;


// public delegate void LostFocusAction();

public delegate void NewSymbolEventHandler();

public delegate void ChangeTextEventHandler(object sender, string text);

public delegate void SenderEventHandler(object sender);

/// <summary>
/// Возврат: false - разрешить закрытие формы (окна),
/// true - запретить.
/// </summary>
public delegate bool WindowClosingEventHandler();
