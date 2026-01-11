using System;
using Gtk;
using Gdk;


public class ContainerSettings : Gtk.Window
{
    public ContainerSettings() : base("Spotify Mini Settings")
    {
        
        SetDefaultSize(700, 600);
        KeepAbove = true;
        Decorated = true;
        BorderWidth = 0;
        SetPosition(WindowPosition.Center);
        Resizable = false;

        // Cor de fundo (preto) usando CSS 
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData("window {background-color: #18181A; padding: 0; margin: 0;}");
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );
    }
}