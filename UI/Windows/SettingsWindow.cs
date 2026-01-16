using Gtk;


using SpotifyMiniPanel.UI.Settings;

namespace SpotifyMiniPanel.UI.Windows
{
    public class SettingsWindow : Gtk.Window
    {
        private Gtk.Window _mainWindow;


        // 🔹 Construtor
        public SettingsWindow(Gtk.Window mainWindow) : base("Settings")
        {
            // 🔹 Referência para a janela principal
            _mainWindow = mainWindow;

            SetDefaultSize(600, 700);
            Resizable = false;

            // 🔹 Layout principal
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

            // 🔹 Adiciona seção de posição da janela
            mainBox.PackStart(label, false, false, 0);
            mainBox.Margin = 10;

            mainBox.PackStart(new PositionSettings(_mainWindow), false, false, 0);


            Add(mainBox);
            ShowAll();
        }
    }
}
