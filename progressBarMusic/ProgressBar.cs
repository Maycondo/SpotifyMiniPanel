using System;
using Gtk;

public class PlayerWindow : Window
{
    ProgressBar progressBar;

    public PlayerWindow() : base("Barra Branca")
    {
        SetDefaultSize(300, 80);
        SetPosition(WindowPosition.Center);

        // Criar ProgressBar
        progressBar = new ProgressBar();
        progressBar.Name = "customProgressBar";
        progressBar.Fraction = 0.4; // só pra testar visualmente

        // Container (obrigatório no GTK)
        var box = new Box(Orientation.Vertical, 10);
        box.Margin = 15;

        box.PackStart(progressBar, false, false, 0);

        Add(box);

        // CSS
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #customProgressBar trough {
                background-color: #333;
                border-radius: 6px;
            }

            #customProgressBar progress {
                background-color: #1DB954;
                border-radius: 6px;
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
