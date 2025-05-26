using System.Windows;
using Demo.WPF.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Presenters;

namespace Demo.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MenuWindow mainView = new MenuWindow();
            IViewLoader viewLoader = new ViewLoader();
            IApplicationController appController = new ApplicationController(mainView, viewLoader);
            var unused = new MenuPresenter(mainView, appController);
        }
    }
}