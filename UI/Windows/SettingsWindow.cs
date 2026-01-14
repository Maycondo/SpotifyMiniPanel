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
                Text = "Panel",
                UseMarkup = true,
                LabelProp = "<b><span size='11000'>Panel</span></b>",
                Halign = Gtk.Align.Start,
                MarginTop = 8,  
                MarginStart = 8
            };


            mainBox.PackStart(label, false, false, 0);
            var positionSettings = new PositionSettings();  
            mainBox.Margin = 10;

            mainBox.PackStart(positionSettings, false, false, 0);

            Add(mainBox);
            ShowAll();
        }
    }
}
