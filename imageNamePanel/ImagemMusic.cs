using Gtk;

public class ImagemMusic : Box
{
    public ImagemMusic() : base(Orientation.Vertical, 0)
    {
        var eventBox = new EventBox();
        eventBox.Name = "musicFrame";

        var image = new Image("caminho/para/imagem.png");
        image.SetSizeRequest(70, 70);

        eventBox.Add(image);
        PackStart(eventBox, false, false, 0);

        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #musicFrame {
                border-radius: 8px;
                border: 1px solid #1DB954;
                background-color: #121212;
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
