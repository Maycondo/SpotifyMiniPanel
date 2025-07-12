using System;
using Gtk;

public class PlayerWindow : Window  // Novo nome aqui
{
    ProgressBar progressBar;

    public PlayerWindow() : base("Barra Branca")
    {

        SetPosition(WindowPosition.Center);

        progressBar = new ProgressBar();
        progressBar.Name = "customProgressBar";  // Nome para CSS


        // Estilo do botão
        var cssProvider = new CssProvider();
            cssProvider.LoadFromData(@"
                #customProgressBar trough {
                    background-color: #333;
                    border-radius: 5px;
                }

                #customProgressBar progress {
                    background-color: #1DB954;
                    border-radius: 5px;
                }
            ");
            StyleContext.AddProviderForScreen(
                Gdk.Screen.Default,
                cssProvider,
                StyleProviderPriority.Application
            );
    }

}
