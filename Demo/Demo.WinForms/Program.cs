using System;
using System.Windows.Forms;
using GuiHelpers.Demo.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Presenters;

namespace GuiHelpers.Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            FormMenu mainForm = new FormMenu();
            IViewLoader viewLoader = new ViewLoader();
            IApplicationController appController = new ApplicationController(mainForm, viewLoader);
            var unused = new MenuPresenter(mainForm, appController);
            
            Application.Run(mainForm);
        }
    }
}