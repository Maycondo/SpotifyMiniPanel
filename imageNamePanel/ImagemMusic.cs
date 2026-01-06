using System;
using Gtk;

public class ImagemMusic : Window
{
    public ImagemMusic() : base("Imagem Music")
    {
        SetDefaultSize(300, 300);
        SetPosition(Window);

        var imagem = new Imagem("caminho/para/sua/imagem.png"); // Substitua pelo caminho da sua imagem
        imagem.Name = "customImage";

        // Container (obrigatório no GTK)
        var box = new Box(Orientation.Vertical, 10);
        box.Margin = 15;

        box.PackStart(imagem, false, false, 0);

        add(box);   

        // CSS
        var cssProvider = new CssProvider();    
        cssProvider.LoadFromData(@"
            #customImage {
                border-radius: 15px;
                border: 2px solid #1DB954;
            }");       

        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );

        ShowAll();
    }       
}
