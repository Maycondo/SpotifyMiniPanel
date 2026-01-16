using Gtk;

namespace SpotifyMiniPanel.UI.Windows
{
    public class MainWindow : Window
    {
        // 🔹 Construto r
        public MainWindow() : base("Spotify Mini Panel")
        {
            // 🔹 Configurações básicas da janela
            SetDefaultSize(400, 160);

            // 🔹 Define a posição da janela como None para permitir controle manual
            SetPosition(WindowPosition.None);

            KeepAbove = true;
            Decorated = true;
            IconName = "spotify";
            Resizable = false;

            // 🔹 Aplica CSS para o estilo da janela
            var cssProvider = new CssProvider();
            cssProvider.LoadFromData(
                "window { background-color: #18181A; padding: 0; margin: 0; }"
            );

            StyleContext.AddProviderForScreen(
                Gdk.Screen.Default,
                cssProvider,
                StyleProviderPriority.Application
            );
        }
    }
}
