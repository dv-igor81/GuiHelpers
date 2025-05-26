using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Demo.Avalonia.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Presenters;

namespace Demo.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //desktop.MainWindow = new MenuWindow();

            MenuWindow mainView = new MenuWindow();
            IViewLoader viewLoader = new ViewLoader();
            IApplicationController appController = new ApplicationController(mainView, viewLoader);
            var unused = new MenuPresenter(mainView, appController);
            
            desktop.MainWindow = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}