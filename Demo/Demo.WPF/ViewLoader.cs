using System;
using Demo.WPF.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Views;

namespace Demo.WPF;

public class ViewLoader : IViewLoader
{
    public IIntegerDemoView CreateIntegerDemoView()
    {
        return new IntegerDemoWindow();
    }
    
    public IThreadDemoView CreateThreadDemoView()
    {
        return new ThreadDemoWindow();
    }
}