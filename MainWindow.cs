using System;
using Gtk;
using Gdk;



class MainWindow : Gtk.Window
{
    public MainWindow() : base("Spotify Mini Panel")
    {
        SetDefaultSize(350, 150);
        KeepAbove = true;
        Decorated = true; // Sem borda
        BorderWidth = 0;
        Resizable = false;

        // Cor de fundo (preto) usando CSS
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData("window { background-color: #000000; }");
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,    
            Gtk.StyleProviderPriority.Application
        );

    }
}


    

