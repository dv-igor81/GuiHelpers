using System;
using Demo.Avalonia.GUI;
using GuiHelpers.Demo.MVP;
using GuiHelpers.Demo.MVP.Views;

namespace Demo.Avalonia;

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