     Проект библиотек помощников для элементов управления. Упрощает разработку приложений с использованием архитектурного
паттерна MVP (Model-View-Presenter). Логика приложений может быть перемешена в отдельную библиотеку, оставляя код в слое 
графического интерфейса лаконичным и понятным. Поддерживает: WinForms, WPF и Avalonia.UI, см. проекты в папке "Demo".
     Например, для WinForms-приложения, код графического интерфейса может выглядеть так:

public partial class FormThreadDemo : Form, IThreadDemoView
{        
    public IWindowWrapper Window { get; }
    
    public IButtonWrapper StartStopButton { get; }
    
    public ILabelWrapper DisplayModeWork { get; }       
        
    public FormThreadDemo()
    {
        InitializeComponent();
            
        Window = new FWindowWrapper(this);
        StartStopButton = new FButtonWrapper(button_StartStop);
        DisplayModeWork = new FLabelWrapper(label_DisplayModeWork);
    }
}
