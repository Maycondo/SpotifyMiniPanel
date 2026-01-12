using Gtk;

namespace SpotifyMiniPanel.UI.Windows
{
    public class MainWindow : Window
    {
        public MainWindow() : base("Spotify Mini Panel")
        {
            SetDefaultSize(400, 160);
            KeepAbove = true;
            Decorated = true;
            IconName = "spotify";
            WindowPosition = WindowPosition.Center;
            Resizable = false;

            // ✅ DECLARAÇÃO CORRETA
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
