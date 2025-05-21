using GuiHelpers.Demo.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Views;

namespace GuiHelpers.Demo;

public class ViewLoader : IViewLoader
{
    public IIntegerDemoView CreateIntegerDemoView()
    {
        return new FormIntegerDemo();
    }

    public IThreadDemoView CreateThreadDemoView()
    {
        return new FormThreadDemo();
    }
}