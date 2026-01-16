using Gtk;
using Gdk;

namespace SpotifyMiniPanel.UI.Settings
{
    public class PositionSettings : Box
    {
        private Gtk.Window _mainWindow;

        public PositionSettings(Gtk.Window mainWindow)
            : base(Orientation.Horizontal, 12)
        {
            _mainWindow = mainWindow;

            MarginTop = 12;
            MarginBottom = 12;
            MarginStart = 12;
            MarginEnd = 12;

            var label = new Label("Posição da Janela:")
            {
                Halign = Align.Start,
                Hexpand = true
            };

            var combo = new ComboBoxText();
            combo.AppendText("Canto superior direito");
            combo.AppendText("Canto superior esquerdo");
            combo.AppendText("Canto inferior esquerdo");
            combo.AppendText("Canto inferior direito");

            combo.Active = GetIndex(SpotifyMiniPanel.Settings.WindowPosition);

            combo.Changed += (_, __) =>
            {
                if (combo.ActiveText == null) return;

                SpotifyMiniPanel.Settings.WindowPosition = combo.ActiveText;
                SpotifyMiniPanel.Settings.SaveSettings();

                ApplyWindowPosition(_mainWindow);
            };

            PackStart(label, true, true, 0);
            PackStart(combo, false, false, 0);
        }

        private int GetIndex(string? value)
        {
            return value switch
            {
                "Canto superior direito" => 0,
                "Canto superior esquerdo" => 1,
                "Canto inferior esquerdo" => 2,
                "Canto inferior direito" => 3,
                _ => 3
            };
        }

        public static void ApplyWindowPosition(Gtk.Window win)
        {
            var screen = Screen.Default;
            var monitor = screen.GetMonitorGeometry(screen.PrimaryMonitor);

            int x = 0, y = 0;

            switch (SpotifyMiniPanel.Settings.WindowPosition)
            {
                case "Canto superior direito":
                    x = monitor.X + monitor.Width - 410;
                    y = monitor.Y;
                    break;

                case "Canto superior esquerdo":
                    x = monitor.X;
                    y = monitor.Y;
                    break;

                case "Canto inferior esquerdo":
                    x = monitor.X;
                    y = monitor.Y + monitor.Height - 200;
                    break;

                default:
                    x = monitor.X + monitor.Width - 410;
                    y = monitor.Y + monitor.Height - 200;
                    break;
            }

            win.Move(x, y);
        }
    }
}
