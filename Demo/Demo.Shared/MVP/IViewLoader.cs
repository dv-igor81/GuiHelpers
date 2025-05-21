using GuiHelpers.Demo.MVP.Views;

namespace GuiHelpers.Demo.MVP;

public interface IViewLoader
{
    IIntegerDemoView CreateIntegerDemoView();

    IThreadDemoView CreateThreadDemoView();
}