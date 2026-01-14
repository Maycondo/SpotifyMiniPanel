using Gtk;


using SpotifyMiniPanel.UI.Settings;

namespace SpotifyMiniPanel.UI.Windows
{
    public class SettingsWindow : Window
    {
        private MainWindow mainWindow;

        // ✅ CONSTRUTOR (tem que estar AQUI dentro da classe)
        public SettingsWindow(MainWindow mainWindow) : base("Settings")
        {
            this.mainWindow = mainWindow;

            SetDefaultSize(600, 700);
            SetPosition(WindowPosition.Center);
            Resizable = false;

            // Container principal
            var mainBox = new Box(Orientation.Vertical, 12);
            var label = new Label
            {
                LabelProp = "Panel",
                Halign = Align.Center,
                MarginTop = 20,
                MarginBottom = 20,
            };
            mainBox.PackStart(label, false, false, 0);
            var positionSettings = new PositionSettings();  
            mainBox.Margin = 20;

            mainBox.PackStart(positionSettings, false, false, 0);

            Add(mainBox);
            ShowAll();
        }
    }
}
