using System;
using Gtk;
using Gdk;



class ContainerMain : Gtk.Window
{
    public ContainerMain() : base("Spotify Mini")
    {
        
        SetDefaultSize(400, 160);
        KeepAbove = true;
        Decorated = true; 
        IconName = "spotify"; // Ícone do Spotify
        WindowPosition = Gtk.WindowPosition.Center; // Centraliza a janela
        Resizable = false;

        // Cor de fundo (preto) usando CSS
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData("window { background-color: #18181A; padding: 0; margin: 0; }");
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,    
            Gtk.StyleProviderPriority.Application
        );

    }
}


    

