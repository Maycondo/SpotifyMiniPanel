using Gtk;

namespace SpotifyMiniPanel.UI.Windows
{
    public class SettingsWindow : Window
    {
        private MainWindow mainWindow;

        // ✅ CONSTRUTOR (tem que estar AQUI dentro da classe)
        public SettingsWindow(MainWindow mainWindow) : base("Settings")
        {
            this.mainWindow = mainWindow;

            SetDefaultSize(400, 300);
            SetPosition(WindowPosition.Center);
            Resizable = false;

            // Container principal
            var mainBox = new Box(Orientation.Vertical, 12);
            mainBox.Margin = 20;
            Add(mainBox);

            var title = new Label("Configurações");
            title.Halign = Align.Start;

            mainBox.PackStart(title, false, false, 0);

            ShowAll();
        }
    }
}
