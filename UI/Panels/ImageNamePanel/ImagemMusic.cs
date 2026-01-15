using Gtk;

public class ImagemMusic : Box
{    
    // 🔹 Construtor
    public ImagemMusic() : base(Orientation.Vertical, 0)
    {
        // 🔹 Caixa com borda arredondada para a imagem
        var eventBox = new EventBox();
        eventBox.Name = "musicFrame";

        // 🔹 Imagem de exemplo (substitua pelo carregamento dinâmico conforme a música)
        var image = new Image("caminho/para/imagem.png");
        image.SetSizeRequest(70, 70);

        eventBox.Add(image);
        PackStart(eventBox, false, false, 0);

        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #musicFrame {
                border-radius: 8px;
                background-color: #121212;
                background-clip: padding-box;   
                background-size: cover;
            }
        ");

        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );


        ShowAll();
    }
}
